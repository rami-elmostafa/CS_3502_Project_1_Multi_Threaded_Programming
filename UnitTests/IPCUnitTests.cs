using System;
using System.IO;
using System.IO.Pipes;
using System.Text;
using System.Threading;
using NUnit.Framework;

[TestFixture]
public class PipeCommunicationTests
{
    private AnonymousPipeServerStream _pipeServer;
    private AnonymousPipeClientStream _pipeClient;

    [SetUp]
    public void Setup()
    {
        // Create the server and client pipes
        _pipeServer = new AnonymousPipeServerStream(PipeDirection.Out, HandleInheritability.Inheritable);
        _pipeClient = new AnonymousPipeClientStream(PipeDirection.In, _pipeServer.GetClientHandleAsString());
    }

    [TearDown]
    public void TearDown()
    {
        // Dispose of the pipes
        _pipeServer.Dispose();
        _pipeClient.Dispose();
    }

    [Test]
    public void TestDataIntegrity()
    {
        // Arrange
        string jsonData = "{\"name\":\"John\", \"age\":30, \"city\":\"New York\"}";
        string receivedData = null;
        ManualResetEvent consumerFinished = new ManualResetEvent(false); // Signal for consumer completion

        // Producer thread
        Thread producerThread = new Thread(() =>
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(_pipeServer))
                {
                    writer.AutoFlush = true;
                    writer.WriteLine(jsonData);
                }
            }
            catch (Exception ex)
            {
                Assert.Fail($"Producer threw an exception: {ex.Message}");
            }
        });

        // Consumer thread
        Thread consumerThread = new Thread(() =>
        {
            try
            {
                using (StreamReader reader = new StreamReader(_pipeClient))
                {
                    receivedData = reader.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Assert.Fail($"Consumer threw an exception: {ex.Message}");
            }
            finally
            {
                consumerFinished.Set(); // Signal that the consumer has finished
            }
        });

        // Act
        producerThread.Start();
        consumerThread.Start();

        producerThread.Join();
        consumerFinished.WaitOne(); // Wait for the consumer to finish

        // Assert
        Assert.AreEqual(jsonData, receivedData, "Data integrity check failed: Sent and received data do not match.");
    }

    [Test]
    public void TestErrorHandling()
    {
        // Arrange
        bool exceptionThrown = false;

        // Producer thread
        Thread producerThread = new Thread(() =>
        {
            using (StreamWriter writer = new StreamWriter(_pipeServer))
            {
                writer.AutoFlush = true;
                writer.WriteLine("Test Message");
                _pipeServer.Dispose(); // Force pipe closure
            }
        });

        // Consumer thread
        Thread consumerThread = new Thread(() =>
        {
            using (StreamReader reader = new StreamReader(_pipeClient))
            {
                try
                {
                    while (true)
                    {
                        string line = reader.ReadLine();
                        if (line == null) break;
                    }
                }
                catch (IOException)
                {
                    exceptionThrown = true;
                }
            }
        });

        // Act
        producerThread.Start();
        consumerThread.Start();

        producerThread.Join();
        consumerThread.Join();

        // Assert
        Assert.IsTrue(exceptionThrown, "Error handling check failed: Expected IOException was not thrown.");
    }

    [Test]
    public void TestPerformanceBenchmarking()
    {
        // Arrange
        const int dataSize = 1024 * 1024; // 1 MB of data
        byte[] data = new byte[dataSize];
        new Random().NextBytes(data); // Fill with random data
        byte[] receivedData = new byte[dataSize];
        int bytesRead = 0;

        // Producer thread
        Thread producerThread = new Thread(() =>
        {
            using (var writer = new BinaryWriter(_pipeServer))
            {
                writer.Write(data);
            }
        });

        // Consumer thread
        Thread consumerThread = new Thread(() =>
        {
            using (var reader = new BinaryReader(_pipeClient))
            {
                bytesRead = reader.Read(receivedData, 0, dataSize);
            }
        });

        // Act
        var startTime = DateTime.UtcNow;
        producerThread.Start();
        consumerThread.Start();

        producerThread.Join();
        consumerThread.Join();
        var endTime = DateTime.UtcNow;

        // Assert
        Assert.AreEqual(dataSize, bytesRead, "Performance check failed: Not all data was transmitted.");
        CollectionAssert.AreEqual(data, receivedData, "Performance check failed: Sent and received data do not match.");

        // Output performance metrics
        var elapsedTime = endTime - startTime;
        double throughput = dataSize / elapsedTime.TotalSeconds; // Bytes per second
        Console.WriteLine($"Throughput: {throughput / 1024 / 1024:F2} MB/s");
        Console.WriteLine($"Latency: {elapsedTime.TotalMilliseconds:F2} ms");
    }
}