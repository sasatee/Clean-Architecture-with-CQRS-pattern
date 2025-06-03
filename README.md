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

- .NET 9/8
- ASP.NET Core
- MediatR
- Entity Framework Core
- FluentValidation
- Swagger/Swashbuckle


