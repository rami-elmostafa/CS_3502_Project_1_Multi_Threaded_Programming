using System;
using System.IO;
using System.IO.Pipes;
using System.Threading;

class Program
{
    static void Main()
    {
        using (AnonymousPipeServerStream pipeServer = new AnonymousPipeServerStream(PipeDirection.Out, HandleInheritability.Inheritable))
        using (AnonymousPipeClientStream pipeClient = new AnonymousPipeClientStream(PipeDirection.In, pipeServer.GetClientHandleAsString()))
        {
            // Create and start Producer and Consumer threads
            Thread producerThread = new Thread(() => Producer(pipeServer));
            Thread consumerThread = new Thread(() => Consumer(pipeClient));

            producerThread.Start();
            consumerThread.Start();

            producerThread.Join();
            consumerThread.Join();
        }

        Console.WriteLine("Main thread finished.");
    }

    static void Producer(AnonymousPipeServerStream pipe)
    {
        using (StreamWriter writer = new StreamWriter(pipe))
        {
            writer.AutoFlush = true;
            for (int i = 1; i <= 5; i++)
            {
                string message = $"Message {i} from Producer";
                Console.WriteLine($"Producer: Sending - {message}");
                writer.WriteLine(message);
                Thread.Sleep(1000); // Simulate work
            }
        }
    }

    static void Consumer(AnonymousPipeClientStream pipe)
    {
        using (StreamReader reader = new StreamReader(pipe))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                Console.WriteLine($"Consumer: Received - {line}");
            }
        }

        Console.WriteLine("Consumer: Finished reading.");
    }
}