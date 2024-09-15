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
2. __When setting up the localhost SQL Server, ensure the instance of MSSQL is called "MSSQLSERVER01" and the Database name is "FiscalFrontierDb". This will allow the API to connect to the SQL Server hosted on your machine.__ 
3. Use SSMS to connect to the database to ensure it is running effectively. 
4. Open a terminal window and navigate to a directory in which you want to place the FiscalFrontier Repository.
5. ``` git clone https://github.com/DiegoFraR/FiscalFrontier```
6. Open the FiscalFrontier API in [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) or [JetBrains Rider](https://www.jetbrains.com/rider/).
7. Build the Project to ensure dependencies and NuGet packages are installed.
8. Run Entity Framework Core migrations to ensure your database is up to date.
``` dotnet ef database update ```
9. Run the API. If all went smoothly, a new browser window will open up with [Swagger](https://learn.microsoft.com/en-us/aspnet/core/tutorials/web-api-help-pages-using-swagger?view=aspnetcore-8.0). This allows you to test the API without the need for a UI. 

### Developer Configuration (UI)
- To Configure your machine to use the UI associated with the API (FiscalFrontierUI), you must do the following:
1. Install [NodeJS](https://nodejs.org/en)
2. We will be using [Angular 16.0.2](https://v16.angular.io/docs). Install this version by running this command in your CLI:
``` npm install -g @angular/cli@16.0.2```
3. Verify installation of correct version by running: 
``` ng version```
4. Once the API is running (see [Developer Configuration (API)](#developer-configuration-api)), run the UI by nagivating to the folder with the UI project and running:
``` ng serve --open ```
 
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
