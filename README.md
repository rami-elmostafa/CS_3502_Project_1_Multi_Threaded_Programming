# CS_3502_Project_1_Multi_Threaded_Programming (6).pdf
# Multi-Threaded Programming and IPC

## Author
**Rami Elmostafa**  
- Section 03  
- Relmost1  
- **Date:** February 28, 2025  

## Introduction
This project was created in an Operating Systems course to provide real-world scenarios and techniques, specifically focusing on multi-threading and interprocess communication (IPC).  

### Objectives:
- Develop a multi-threaded application using a language capable of accessing unsafe memory and “true” threading.
- Demonstrate IPC through pipe (`|`) implementation to showcase data communication.
- Utilize a Linux-based development environment, a LaTeX-based report, and a demonstration video.

---

## Implementation Details

### Multi-Threaded Program
The program consists of a main method that creates an array of 10 threads, each of type `WorkerThread`.  
Each thread:
1. Acquires a mutex.
2. Simulates work using `Thread.Sleep`.
3. Acquires a second mutex.
4. Simulates work with both mutexes.
5. Releases both mutexes.

**Example Code:**
```csharp
mutex1.WaitOne(); // Acquire Mutex 1
Console.WriteLine($"Thread {id}: Acquired Mutex 1.");
