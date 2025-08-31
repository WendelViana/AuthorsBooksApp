# AuthorsBooksApp

AuthorsBooksApp is an ASP.NET MVC application (.NET Framework 4.7.2, C# 7.3) for managing authors and books. This project was developed as a technical assessment for a senior .NET position.

## Features

- List, create, and edit authors
- List, create, and edit books
- Data validation on forms
- Integration with an external API for data persistence
- User authentication

## Demo
A video demonstration of the application is available in the [Demo](./Demo/AuthorsBooksApp_Demo.mp4) folder.

## Technologies Used

- ASP.NET MVC (.NET Framework 4.7.2, C# 7.3)
- SimpleInjector (Dependency Injection)
- Newtonsoft.Json (Serialization/Deserialization)
- Bootstrap (UI and responsiveness)

## Project Structure

- **Controllers**: Handles HTTP requests and business logic
- **Models**: Data models (Author, Book, User, etc.)
- **Services**: Business services and API integration
- **Views**: Razor pages for user interaction
- **Infra**: Dependency injection and infrastructure configuration

## Getting Started

### Prerequisites

- Visual Studio 2022
- .NET Framework 4.7.2
- SQL Server (if applicable)
- Clone this repository

### Setup

1. Open the solution in Visual Studio.
2. Configure connection strings and API endpoints in `Web.config`.
3. Restore NuGet packages.

### Running the Application

- Build the solution.
- Run the project (F5).
- Access `http://localhost:<port>/` in your browser.

## Dependency Injection

Service and controller dependencies are configured using SimpleInjector in:
