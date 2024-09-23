# FiscalFrontier
## Combining cutting-edge technology with modern financial practices

## Table of Contents
- [Introduction](#introduction)
- [Developers](#developers)
- [Technology Stack](#technology-stack)
- [Developer Configuration](#developer-configuration-api)
- [Pull Request Workflow](#pull-request-workflow)

### Introduction
Fiscal Frontiner is an accounting application designed to keep track of financial transactions.

### Developers 
- [Diego Frausto Ramirez](https://github.com/DiegoFraR)
  - Backend Developer
  - Frontend Developer
- [Chris Kirkwood](https://github.com/cckirk)
  - Backend Developer
- [Hong Nguyen](https://github.com/hnguy126)
  - Frontend Developer
- [Riley Powell](https://github.com/Rpowell57)
  - Documentation, Video Recorder, PR Checks. 

 ### Technology Stack
- Backend
   - [C#](https://learn.microsoft.com/en-us/dotnet/csharp/)
- Frontend
  - [Angular](https://angular.dev/)
  - [TypeScript](https://www.typescriptlang.org/)
- Database
  - [Microsoft SQL Server for Development Use](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
  - [Azure SQL Database for Production](https://azure.microsoft.com/en-us/products/azure-sql/database)

### Developer Configuration (API)
- To Configure your machine to use this API, you must do the following.
1. Download the latest version of [Microsoft SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) & [SQL Server Management Studio(SSMS)](https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16). 
2. __When setting up the localhost SQL Server, ensure the instance of MSSQL is called "MSSQLSERVER01" and the Database name is "FiscalFrontierDb". This will allow the API to connect to the SQL Server hosted on your machine.__ (You may need to download two instances of MSSQL to get the 01 server).
3. Use SSMS to connect to the database to ensure it is running effectively. (ENSURE your database is set to MSSQLSERVER01, Depending on what you save your file too will change the front name. You may have DESKTOP-"NAME" or your machines name or localhost).
4. Open a terminal window and navigate to a directory in which you want to place the FiscalFrontier Repository. (Ensure you copy a specific folder path in the CMD or terminal. You'll use cd "folder path").
5. ``` git clone https://github.com/DiegoFraR/FiscalFrontier```
6. Open the FiscalFrontier API in [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) or [JetBrains Rider](https://www.jetbrains.com/rider/).
7. Build the Project to ensure dependencies and NuGet packages are installed. (NuGet Packages can be reach from the tools menu.)
8. Run Entity Framework Core migrations to ensure your database is up to date. (tools -> NuGet Packages -> Package Manager Console -> PM> Update-Database).
``` dotnet ef database update ```
9. Run the API. If all went smoothly, a new browser window will open up with [Swagger](https://learn.microsoft.com/en-us/aspnet/core/tutorials/web-api-help-pages-using-swagger?view=aspnetcore-8.0). This allows you to test the API without the need for a UI. (If youre having an issue with the localhost go to chrome://flags/ and find the Allow invalid certificates for resources loaded from localhost. Enable this, and then restart the browers and re-run the API from Microsoft visual studios).

### Developer Configuration (UI)
- To Configure your machine to use this UI, you must do the following.
1. Run the API (see [Developer Configuration (API)](#developer-configuration-api)).
2. Download [NodeJS](https://nodejs.org/en)
3. Download Angular 16.0.2 onto your machine. (If you have an existing version of angular already, uninstall it and download the correct version).
``` npm i @angular/cli@16.0.2 ``` (if this doesnt work use npm install -g @angular/cli@16.0.2)
4. Using [Visual Studio Code](https://code.visualstudio.com/), open the UI component of the project. 
5. In the terminal window in VS Code, type ``` ng serve --open ``` to launch the UI. 
 
### Pull Request Workflow
- To add new code into this repository, please use PRs and GitHub desktop to ensure code that is merged into the main branch is of a good quality. 
1. Follow the steps in [Developer Configuration](#developer-configuration-api).
2. Open [GitHub Desktop](https://github.com/apps/desktop) and open this repository in it. 
3. Create a new branch in GitHub desktop and use the following naming convention:
* PR-*High-Level-Description-Of-Code*
* Example: PR-AddedUserSettingsButtonToUI
4. Once you are ready to submit the PR, commit your branch to GitHub and submit the PR. 
- For API PRs, request any of the following reviewers:
* [Diego Frausto Ramirez](https://github.com/DiegoFraR)
* [Chris Kirkwood](https://github.com/cckirk)
* [Riley Powell](https://github.com/Rpowell57)
- For UI PRs, request any of the following reviewers:
* [Diego Frausto Ramirez](https://github.com/DiegoFraR)
* [Hong Nguyen](https://github.com/hnguy126)
* [Riley Powell](https://github.com/Rpowell57)

- Whoever checks the PR, remove any other reviewers from the PR. 

* [Video Explaination of PRs from GitHub Desktop](https://www.youtube.com/watch?v=8x6V5IOuXog)
