

# ASP.NET Core Web Api Template
 
This project is an Web API Open-Source Boilerplate Template that includes ASP.NET Core 5, Web API standards, clean n-tier architecture, GraphQL service, Redis, Mssql, Mongo databases and User Auditing (Identity) with a lot of best practices.

## Releases
v1.0, v2.0, v3.0

## v4.0

Follow these steps to get started with this Boilerplate Template.

### Download the Extension
Make sure Visual Studio 2019 is installed on your machine with the latest SDK.
[Download from Visual Studio Marketplace](https://marketplace.visualstudio.com/items?itemName=SinanTok.ASPNETCoreWebAPI). Install it on your machine.

Follow these Steps to get started.

![enter image description here](https://i.hizliresim.com/HCtEh0.png)

You Solution Template is Ready!

![enter image description here](https://i.hizliresim.com/o9t66ud.PNG)

### Alternatively you can also clone the [Repository](https://github.com/sinantok/aspnetcore-webapi-template).

1. Clone this Repository and Extract it to a Folder.
3. Change the Connection Strings for the "DefaultConnection" and "IdentityConnection" in the appsettings.json
2. Run the following commands on Powershell in the Projecct's Directory.
- dotnet restore
- dotnet ef database update -Context IdentityContext
- dotnet ef database update -Context ApplicationDbContext
- dotnet run (OR) Run the Solution using Visual Studio

### Swagger
You can view endpoints with swagger
![enter image description here](https://i.hizliresim.com/3jyeib7.PNG)

### HealthCheck
You can check the status of the services with HealthCheck

### Default Roles & Credentials
As soon you build and run your application, default users and roles get added to the database.

Default Roles:
- SuperAdmin
- Admin
- Moderator
- Basic

Here are the credentials for the default user.
- Email - superadmin@gmail.com  / Password - 123Pa$$word!

You can use these default credentials to generate valid JWTokens at the ../api/account/authenticate endpoint.

## Technologies
- .Net 8 WebApi
- .NET 8
- REST Standards
- GraphQL
- MSSQL
- MongoDB
- Microsoft Identity
- Redis
- SeriLog(seq)
- AutoMapper
- Smtp / Mailkit
- Swagger Open Api
- Health Checks

## Features
- [x] Net 8
- [x] N-Tier Architecture
- [x] Restful
- [x] GraphQl
- [x] Entity Framework Core - Code First
- [x] Repository Pattern - Generic
- [x] UnitOfWork
- [x] Redis Caching
- [x] Response Wrappers
- [x] Microsoft Identity with JWT Authentication
- [x] Role based Authorization
- [x] Identity Seeding
- [x] Database Seeding
- [x] Custom Exception Handling Middlewares
- [x] Serilog
- [x] Automapper
- [x] Swagger UI
- [x] Healthchecks
- [x] SMTP / Mailkit / Sendgrid Email Service
- [x] Complete User Management Module (Register / Generate Token / Forgot Password / Confirmation Mail)
- [x] User Auditing
- [ ] Pagination
- [ ] Refit
- [ ] Fluent Validation
- [ ] Unit Test
- [x] .Net 8 migration
- [x] MongoDb Operations
- [x] Docker Support `docker-compose.yml` and `Dockerfile`

## Purpose of this Project

This template project has been developed to ensure that the necessary structures are not installed over and over again when creating each new WebAPI project. In addition, the structures that should be in a WepAPI are developed with a clean architecture and up-to-date technologies.

## Prerequisites
- Visual Studio 2019 Community and above
- .NET 8 SDK and above
- Basic Understanding of Architectures and Clean Code Principles

## Give a Star ⭐️
If you found this Implementation helpful or used it in your Projects, do give it a star. Thanks!

## Licensing

sinantok/aspnetcore-webapi-template Project is licensed with the [MIT License](https://github.com/sinantok/aspnetcore-webapi-template/blob/master/LICENSE).

## About the Author
### Sinan Tok
- Github [github.com/sinantok](https://github.com/sinantok)
- Linkedin - [Sinan Tok](https://www.linkedin.com/in/sinantok/)
