using System;
using System.Threading;

class Program
{
    static Mutex mutex1 = new Mutex();
    static Mutex mutex2 = new Mutex();

    static void WorkerThread(object id)
    {
        Console.WriteLine($"Thread {id}: Trying to acquire Mutex 1...");
        mutex1.WaitOne(); // Acquire Mutex 1
        Console.WriteLine($"Thread {id}: Acquired Mutex 1.");

        Thread.Sleep(500); // Simulate work

        Console.WriteLine($"Thread {id}: Trying to acquire Mutex 2...");
        mutex2.WaitOne(); // Acquire Mutex 2
        Console.WriteLine($"Thread {id}: Acquired Mutex 2.");

        // Simulate work with both mutexes
        Thread.Sleep(500);

        // Release mutexes
        Console.WriteLine($"Thread {id}: Releasing Mutexes.");
        mutex2.ReleaseMutex();
        mutex1.ReleaseMutex();
    }

    static void Main()
    {
        Console.WriteLine("Main thread started.");

        Thread[] threads = new Thread[10];

        // Create and start 10 threads
        for (int i = 0; i < 10; i++)
        {
            threads[i] = new Thread(WorkerThread);
            threads[i].Start(i + 1);
        }

        // Wait for all threads to complete
        foreach (Thread t in threads)
        {
            t.Join();
        }

        Console.WriteLine("Main thread finished.");
    }
}