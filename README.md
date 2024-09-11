# FiscalFrontier
## Combining cutting-edge technology with modern financial practices

## Table of Contents
- [Introduction](#introduction)
- [Developers](#developers)
- [Technology Stack](#technology-stack)
- [Developer Configuration](#developer-configuration-(api))

### Introduction
Fiscal Frontiner is an accounting application designed to keep track of financial transactions. The application does the following:
* 

### Developers 
- [Diego Frausto Ramirez](https://github.com/DiegoFraR)
  - Backend Developer
  - Frontend Developer
- [Chris Kirkwood](https://github.com/cckirk)
  - Backend Developer
- [Hong Nguyen](https://github.com/hnguy126)
  - Frontend Developer
- [Riley Powell]()
  - Documentation & Video Recorder

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
1. Download the latest version of [Microsoft SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads).
2. When setting up the localhost SQL Server, ensure the instance of MSSQL is called "MSSQLSERVER01" and the Database name is "FiscalFrontierDb". This will allow the API to connect to the SQL Server hosted on your machine. 
3. Open a terminal window and navigate to a directory in which you want to place the FiscalFrontier Repository.
4. ``` git clone https://github.com/DiegoFraR/FiscalFrontier```
5. Open the FiscalFrontier API in [Visual Studio 2022](https://visualstudio.microsoft.com/vs/)
6. Build the Project to ensure dependencies and NuGet packages are installed.
7. Run the Project to let the EF Core Migrations run and seed data to be placed into the Database. 

- Once there are instrunctions on how to call submit a PR to this repository, we will do this to ensure high quality code is pushed into the repository. Please test any new code you write to ensure it works AND doesn't break any existing features (You can monkey test this for now. Towards the end, Diego will start writing Unit Tests (and E2E Tests with Playwright) to ensure things are working before getting ready to turn in the final product). This will allow fellow group members to check your code to ensure there are no glaring issues before merging it :D. 
 
