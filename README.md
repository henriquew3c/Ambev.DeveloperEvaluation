# Prototype Sales API

Implementation of a Restfull API prototype for sales handling.

## Tech Stack

Technologies in this project:

Backend:
- **.NET 8.0**: A free, cross-platform, open source developer platform for building many different types of applications.
  - Git: https://github.com/dotnet/core
- **C#**: A modern object-oriented programming language developed by Microsoft.
  - Git: https://github.com/dotnet/csharplang

Testing:
- **xUnit**: A free, open source, community-focused unit testing tool for the .NET Framework.
  - Git: https://github.com/xunit/xunit

Databases:
- **PostgreSQL**: A powerful, open source object-relational database system.
  - Git: https://github.com/postgres/postgres
- **MongoDB**: A general purpose, document-based, distributed database.
  - Git: https://github.com/mongodb/mongo
 
## Frameworks

Frameworks in this project:

Backend:
- **Mediator**: A behavioral design pattern that helps reduce chaotic dependencies between objects. It allows loose coupling by encapsulating object interaction.
  - Git: https://github.com/jbogard/MediatR
- **Automapper**: A convention-based object-object mapper that simplifies the process of mapping one object to another.
  - Git: https://github.com/AutoMapper/AutoMapper

Testing:
- **Faker**: A library for generating fake data for testing purposes, allowing for more realistic and diverse test scenarios.
  - Git: https://github.com/bchavez/Bogus
- **NSubstitute**: A friendly substitute for .NET mocking libraries, used for creating test doubles in unit testing.
  - Git: https://github.com/nsubstitute/NSubstitute

Database:
- **EF Core**: Entity Framework Core, a lightweight, extensible, and cross-platform version of Entity Framework, used for data access and object-relational mapping.
  - Git: https://github.com/dotnet/efcore

## Instructions for use

1) Run docker compose to iniciate the conteiners
2) Run the command update-database to create tables in database. If it doesn't work look the appsettings conection string. By default the port postgresql 5432 is exposed.
3) Use swagger (or another toool) to create your user. Post to /api/Users.
4) Use swagger to get jwt token via auth endpoint. The JWT token is necessary to access the restricted endpoints.
   
