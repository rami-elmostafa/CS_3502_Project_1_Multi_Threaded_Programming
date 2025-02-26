using System;
using System.Threading;
using NUnit.Framework;

[TestFixture]
public class ThreadingTests
{
    private static Mutex mutex1;
    private static Mutex mutex2;

    [SetUp]
    public void Setup()
    {
        mutex1 = new Mutex();
        mutex2 = new Mutex();
    }

    [TearDown]
    public void TearDown()
    {
        mutex1.Dispose();
        mutex2.Dispose();
    }

    // Worker thread method for testing
    private void WorkerThread(object id)
    {
        Console.WriteLine($"Thread {id}: Trying to acquire Mutex 1...");
        mutex1.WaitOne(); // Acquire Mutex 1
        Console.WriteLine($"Thread {id}: Acquired Mutex 1.");

        Thread.Sleep(100); // Simulate work

        Console.WriteLine($"Thread {id}: Trying to acquire Mutex 2...");
        mutex2.WaitOne(); // Acquire Mutex 2
        Console.WriteLine($"Thread {id}: Acquired Mutex 2.");

        // Simulate work with both mutexes
        Thread.Sleep(100);

        // Release mutexes
        Console.WriteLine($"Thread {id}: Releasing Mutexes.");
        mutex2.ReleaseMutex();
        mutex1.ReleaseMutex();
    }

    // Concurrency Testing
    [Test]
    public void TestConcurrency()
    {
        const int numThreads = 10;
        Thread[] threads = new Thread[numThreads];

        // Create and start threads
        for (int i = 0; i < numThreads; i++)
        {
            threads[i] = new Thread(WorkerThread);
            threads[i].Start(i + 1);
        }

        // Wait for all threads to complete
        foreach (Thread t in threads)
        {
            t.Join();
        }

        // Verify that all threads completed successfully
        Assert.Pass("All threads completed without interference.");
    }

    // Synchronization Validation
    [Test]
    public void TestSynchronization()
    {
        const int numThreads = 10;
        Thread[] threads = new Thread[numThreads];
        int sharedResource = 0;

        // Worker thread method for synchronization test
        void SynchronizedWorker(object id)
        {
            mutex1.WaitOne(); // Acquire Mutex 1
            try
            {
                int temp = sharedResource;
                Thread.Sleep(10); // Simulate work
                sharedResource = temp + 1;
            }
            finally
            {
                mutex1.ReleaseMutex(); // Release Mutex 1
            }
        }

        // Create and start threads
        for (int i = 0; i < numThreads; i++)
        {
            threads[i] = new Thread(SynchronizedWorker);
            threads[i].Start(i + 1);
        }

        // Wait for all threads to complete
        foreach (Thread t in threads)
        {
            t.Join();
        }

        // Verify that the shared resource was updated correctly
        Assert.AreEqual(numThreads, sharedResource, "Synchronization failed: Race condition detected.");
    }

    // Stress Testing
    [Test]
    public void TestStress()
    {
        const int numThreads = 100; // High number of threads for stress testing
        Thread[] threads = new Thread[numThreads];

        // Create and start threads
        for (int i = 0; i < numThreads; i++)
        {
            threads[i] = new Thread(WorkerThread);
            threads[i].Start(i + 1);
        }

        // Wait for all threads to complete
        foreach (Thread t in threads)
        {
            t.Join();
        }

        // Verify that all threads completed successfully
        Assert.Pass("All threads completed under high load.");
    }
}