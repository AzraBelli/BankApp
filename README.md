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


