# Clean Architecture with CQRS Pattern

This project demonstrates a robust implementation of the Clean Architecture pattern combined with CQRS (Command Query Responsibility Segregation) using .NET. It features a modular structure with clear separation of concerns, MediatR for CQRS, and Entity Framework Core for data access.

## Features

- **Clean Architecture**: Separation of Domain, Application, Infrastructure, and API layers.
- **CQRS Pattern**: Distinct command and query models for handling data operations.
- **MediatR**: In-process messaging for decoupled request handling.
- **Entity Framework Core**: Database access and migrations.
- **RESTful API**: CRUD operations for Product entities.
- **Validation**: FluentValidation for command/query validation.
- **Swagger/OpenAPI**: Interactive API documentation.

## Project Structure

- `Domain`: Core business models and repository interfaces.
- `Application`: CQRS handlers, commands, queries, and validation.
- `Infrastructure`: Data access implementations and database context.
- `API`: ASP.NET Core Web API exposing endpoints.

## Getting Started

1. **Clone the repository**
2. **Restore dependencies**:  
   `dotnet restore`
3. **Apply migrations & update database** (if needed)
4. **Run the API**:  
   `dotnet run --project CleanArchitecureWithCQRSandMediator.API`
5. **Explore the API**:  
   Navigate to `/swagger` for interactive documentation.

## Example Endpoints

- `GET /api/product` - List all products
- `GET /api/product/{id}` - Get product by ID
- `POST /api/product` - Create a new product
- `PUT /api/product/{id}` - Update a product
- `DELETE /api/product/{id}` - Delete a product

## Technologies

- .NET 7/8
- ASP.NET Core
- MediatR
- Entity Framework Core
- FluentValidation
- Swagger/Swashbuckle

---

## Project Overview (for your CV)

**Clean Architecture with CQRS Pattern (.NET, MediatR, EF Core)**  
Designed and implemented a modular web API using Clean Architecture principles and the CQRS pattern. The solution features:

- **Layered architecture**: Clear separation between Domain, Application, Infrastructure, and API layers.
- **CQRS with MediatR**: Commands and queries are handled via MediatR, promoting decoupled and testable code.
- **Entity Framework Core**: Used for data persistence and migrations.
- **RESTful API**: Exposes endpoints for managing products, including full CRUD operations.
- **Validation and Error Handling**: Integrated FluentValidation and custom middleware for robust request validation and exception handling.
- **API Documentation**: Swagger/OpenAPI for easy API exploration and testing.

*This project demonstrates best practices in modern .NET backend development, scalable architecture, and advanced patterns like CQRS.* 
