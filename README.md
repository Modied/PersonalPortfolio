
# Personal Web Portfolio

## Overview

This project is a **personal web portfolio** built using **ASP.NET Core**. It features a **dashboard** for managing content and a **public UI** for visitors. The project follows a **clean architecture** approach, ensuring maintainability, scalability, and separation of concerns.

## Features

- **Areas Architecture**: Separates the **dashboard** and **public UI**.
- **MVC Pattern**: Implements the Model-View-Controller pattern.
- **Clean Architecture**: Divided into four layers:
  1. **Domain Layer**: Core entities and business rules.
  2. **Business Logic Layer**: Contains services and business logic.
  3. **Data Context Layer**: Handles database operations.
  4. **Presentation Layer**: Manages UI components.
- **Dependency Injection**: Promotes modularity and testability.
- **SOLID Principles**: Ensures a maintainable codebase.
- **Repository & Unit of Work Pattern**: Efficient data access and transaction handling.
- **AutoMapper**: Simplifies object mapping.
- Additional features are available within the project.

## Technologies Used

- **ASP.NET Core** (Web API & MVC)
- **Entity Framework Core** (Database interactions)
- **AutoMapper** (Object mapping)
- **Dependency Injection**
- **Repository & Unit of Work Patterns**
- **SOLID Principles**
- **Razor Views** (For UI rendering)
- **Bootstrap & CSS** (For frontend styling)

## Installation & Setup

1. **Clone the Repository**:

   ```sh
   git clone https://github.com/your-username/your-repository.git
   cd your-repository
   ```

2. **Setup Database**:

   - Update the `appsettings.json` with your database connection string.
   - Run migrations:
     ```sh
     dotnet ef database update
     ```

3. **Run the Project**:

   ```sh
   dotnet run
   ```

4. Open your browser and navigate to:

   - **Dashboard**: `localhost:7083/Dashboard/auth/login`
   - **Public Portfolio**: `localhost:7083/VisitorUI/`



