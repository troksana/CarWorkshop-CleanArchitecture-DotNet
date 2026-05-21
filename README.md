# Car Workshop Management System (.NET / ASP.NET Core MVC)

A modern, enterprise-grade web application designed for car workshop orchestration. Built using **Modern .NET** and adhering strictly to the principles of **Clean Architecture** and **Domain-Driven Design (DDD)**.

## Architecture Layers

* **CarWorkshop.Domain:** Core business logic, aggregate roots, entities, and value objects. Completely decoupled from external frameworks.
* **CarWorkshop.Application:** Application logic, use-case implementations, DTO mappings, and orchestrations.
* **CarWorkshop.Infrastructure:** Data persistence layer, Entity Framework Core integration, database migrations, and external service configurations.
* **CarWorkshop.MVC:** Presentation layer built with ASP.NET Core MVC, handling routing, controllers, razor views, and user interactions.

## Tech Stack

* **Framework:** .NET 8 / ASP.NET Core MVC
* **Persistence:** Entity Framework Core (SQL Server / In-Memory)
* **Design Patterns:** Repository Pattern, Clean Architecture isolation, Dependency Injection.
* **Frontend:** Razor Views, HTML5, CSS3, Bootstrap.
