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

**Architecture:**

![PlantUML diagram](https://cdn-0.plantuml.com/plantuml/png/fLTXRzem4FtEhx3QBvig_i0qJUqeLIkL5ZNGbMeISfqZjUROsTc1LHF_VNQiW04J8ED3st3llVETNtpkfJOKJPcB3XL2BNB-Xykiqoae-qKp86SzAbWfg558xbN66Hcej1HmHiu5pzxDcoYXyxT3x8S9gZMv1isG5uRF8J7KS6quqyGZtEU2z5HUb0OIcXV2OMHACRs6ERTe9NU1GrMKeeeT1X-ZDm0Q8_ukASBZx9hFPe0W6UXTq3D5JcreD_AQC8N--sKdQCSzbq3n2J84hUroefsm7HUmZGnmGuIKCpEvGPNtxJfNTIs3JFL6sTWJw5AOZLHzH8K3gqopZSBkT58o1ZhypjFrJeQn1doceeGRXJar1d0ZnP2YXaS95MG8w0fg2DlYSrhdw2oRB3UMt90HQAE9tLNou9vh0tw0iwspe5-bfpY49xZ0OTTDxxasZxDgRNhw1AP4gVTWFtq-HV9AY5T0TKZKOOuLxkU5-N3gjMQrkPPzx6ipjNNoD5He09-Y6o-vWL7XJidm_xLR2pwK-HlWGHN_JljcLSuO0BM2JglcUSWUue1hpMLc4rhlqnmCu37vN1RtbbTDR2HOPDovBX03-_P5677z-C5KkyU9-4wkLEA4-iWwJjwlCPHljSY4vl3IlaP7dxIdkwrxkPBfP4WvjX4Oo_uSvCiaQjBuKDZQcfNdLWLCchbtSdwOlTmyPvr0mdFtia7w0zuIm3bWTVBM1-_kr9Z69aNWqiIWRKgph-F2qHbpchARtjipfDlz5h_NnA7Rcnb5HPPlSSrDRSriBcBVyBK2n2kGgwBOlV5v7mnK2aAldvyvB8B7df86bH20sdKsV7PByl1OmEl68h4g8i38HaGmaMRkQKTVfjsHwjfVmLraAEZ70crVjYuaP7qXMKjOwaZP7-7DX5m40DlnCRSkpc34ZO3fdLx7d3lZ-ERhGktmda84PlpbhbciUO96Ht1zjsoxIZ-LMwiEWBOir0_TTjnjVvseKf_2bVtsS_t_4tjjv4mScleBkHsDXWukd4D_Id8BD1MWDVcEQg6zmPbGPKhE0xE-ynG8uyW4UEi615B_HRusfBEwbo3JCXV_0000)

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

![](C:\Users\ramie\Pictures\Screenshots\Screenshot 2025-02-26 194514.png)

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



## Final Video Presentation

[Project Presentation on Youtube](https://youtu.be/T_Ve5JAHcIY) 
