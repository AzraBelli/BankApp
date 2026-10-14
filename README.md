# Banking Credit System

A .NET Web API for a banking credit domain, built with Onion Architecture, CQRS and MediatR.

## Architecture

| Layer | Responsibility |
| --- | --- |
| BankingCreditSystem.Domain | Entities and business rules |
| BankingCreditSystem.Application | Commands, queries and handlers (CQRS + MediatR) |
| BankingCreditSystem.Persistence | Data access and repositories |
| BankingCreditSystem.WebApi | REST endpoints |
| BankingCreditSystem.Core | Shared abstractions |

## How I built it

I used Cursor as an AI pair programmer. I designed the architecture, reviewed every generated change and corrected it where needed. AI speeds up the work, but every line still needs a human check.

## Tech stack

.NET 9 · ASP.NET Core Web API · Entity Framework Core · SQL Server · MediatR · FluentValidation · AutoMapper · JWT authentication · Swagger

## Features

Individual customers, corporate customers, credit types and credit applications, each with its own commands, queries and validation.

## Run it

Requires the .NET 9 SDK and SQL Server LocalDB (included with Visual Studio).

    git clone https://github.com/AzraBelli/BankApp.git
    cd BankApp
    dotnet ef database update --project BankingCreditSystem.Persistence --startup-project BankingCreditSystem.WebApi
    dotnet run --project BankingCreditSystem.WebApi

Then open `/swagger` to try the endpoints.


