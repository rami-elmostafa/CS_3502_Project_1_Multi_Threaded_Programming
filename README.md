# CS_3502_Project_1_Multi_Threaded_Programming 

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

##  Table of Contents

- [Environment](#environment) 
- [Executing the Web Application](#executing-the-web-application)
- [Executing Unit Tests](#executing-unit-tests) 
- [Final Video Presentation](#final-video-presentation) 

*Team Members*: Rami Elmostafa

## Environment 

This is a application requires a Linux Environment to be set up, as well as .NET SDK.

To prepare your environment to execute this application:

 1. [Install the latest .NET runtime (net8.0) for your system.](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) 

 2. [Install Git](https://git-scm.com/downloads) 

 3. Ensure .NET 8.0 and Git were successfully installed:   

    Open a terminal window:

    - Windows (Command Prompt) https://www.wikihow.com/Open-the-Command-Prompt-in-Windows
    - Mac OS (Terminal) https://support.apple.com/en-kg/guide/terminal/apd5265185d-f365-44cb-8b09-71a064a42125/mac#:~:text=Terminal%20for%20me-,Open%20Terminal,%2C%20then%20double%2Dclick%20Terminal
    - Linux This will be specific to your Linux distribution. Google for help if you cannot find your Terminal.

  4. From your command line or terminal, type `dotnet --version`. Assuming dotnet is properly installed, you will see something like the following: (windows example)

     ![Screenshot 2024-12-01 152613](https://github.com/user-attachments/assets/37c85f53-0451-4a63-8c90-191a62d43105)


    6. From your command line or terminal, type `git --version`. Assuming `git` is properly installed, you will see something like the following: (macOS terminal example)[![image-20240822072904716](https://github.com/jeff-adkisson/swe-3643-fall-2024/raw/main/homework/homework-1-assets/image-20240822072904716.png)](https://github.com/jeff-adkisson/swe-3643-fall-2024/blob/main/homework/homework-1-assets/image-20240822072904716.png) 

#### To Set Up Linux Environment: 
To complete this project, you will need to set up a Linux-based development environment. The setup process will depend on your current operating system and hardware capabilities. Below are the recommended options:

Virtualization Options
If your hardware supports virtualization, you can choose one of the following methods to run a Linux environment:

Hyper-V (Windows): A built-in virtualization tool available on Windows Pro or Education editions. Enable it through Turn Windows features on or off.

VirtualBox (Cross-platform): A free and open-source virtualization tool that works on Windows, macOS, and Linux.

VMware Workstation Player (Cross-platform): A robust option for virtualization, free for non-commercial use.

Windows Subsystem for Linux (WSL)
If you are using Windows 10 or later, you can use WSL to run a Linux environment without a virtual machine. Follow these steps:

Enable WSL by running the command: wsl --install.

Install a Linux distribution, such as Ubuntu, from the Microsoft Store.

For macOS Users
For those using ARM-based Macs (e.g., Apple Silicon), consider:

UTM: A virtualization tool optimized for ARM-based Macs.

Parallels Desktop: A commercial virtualization tool that supports Linux on macOS.

Choosing a Linux Distribution
If this is your first time working with Linux, I recommend using Ubuntu, as it is beginner-friendly and well-documented. However, if you are already familiar with Linux, I encourage you to explore another distribution, such as:

Fedora: Known for its cutting-edge features and strong community support.

Debian: A stable and reliable distribution popular for development.

Arch Linux: For advanced users looking for complete customization and control.

Reference: Chris Regan, Kennesaw State University, Operating Systems Project 1 Requirments.

## Executing the Multi-Threaded and IPC Apps

1. Clone the Repository: In command line, enter the following 

   - `git clone https://github.com/rami-elmostafa/CS_3502_Project_1_Multi_Threaded_Programming.git`

2. Navigate to repository folder

3. Restore Dependencies (NuGet for Blazor application): In the command line or terminal, enter the following

   - `dotnet restore`

4. Build the Application: In the command line or terminal, enter the following

   - `dotnet build`

5. Run the Application: After building the project, you can run the Blazor application by typing the following In the command line or terminal

   - `dotnet run`

     You should see output similar to this: 

    ![Screenshot 2024-12-01 163325](https://github.com/user-attachments/assets/5274b4dc-3435-4685-a04c-753dce109c77)


5. After the application starts, launch a browser and connect to http://localhost:5206

   **TROUBLE SHOOTING: **

   - If you see the following error, something is already running on the application's HTTP port. Free up the port, then try again:
     `Unhandled IO exception: Failed to bind to https://127.0.0.1:5206: address already in use.`

## Executing Unit Tests

1. (If already cloned skip to step 3) Clone the Repository: In command line, enter the following 

   - `git clone https://github.com/rami-elmostafa/CS_3502_Project_1_Multi_Threaded_Programming.git`

2. Navigate to repository folder: In the command line, enter the following

   - `cd CS_3502_Project_1_Multi_Threaded_Programming/UnitTests`

     *Tip: To go return to previous directory in windows command line, use `cd ../`*

3. To run the tests, enter the following to the command line or terminal

   - `dotnet test`

     

     **The output should look like the following:**

     ```bash 
     $ dotnet test
     
     Starting test execution, please wait...
     A total of 1 test files matched the specified pattern.
     Starting test execution, please wait...
     A total of 1 test files matched the specified pattern.
     
     {All 
     
     Tests}
     
     Passed!  - Failed:     0, Passed:   22, Skipped:     0, Total:   22, Duration: 39 ms - UnitTests.dll (net8.0)
     ```


 
