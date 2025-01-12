# Product Application
This is a simple Product Application  using ASP.NET Core 8 with the Entity Framework Core and a repository pattern. The application manages products, including CRUD operations and stock management. The API also includes unit tests for the `ProductController`.


## Prerequisites

Before you begin, ensure you have the following installed on your system:

- [.NET SDK 8.0]
- [Visual Studio 2022 or later]
- [SQL Server Express]

## Setting up the Project

1. **Clone the repository**:
   git clone  "Repo link"

2. Install Dependencies: 
   dotnet restore
3.Install Entity Framework Core CLI Tools (if not already installed):
   dotnet tool install --global dotnet-ef
4.Configure Database Connection:
   A.Open the appsettings.json file in the ProductApplication project.

   B.Ensure the connection string to your database is correctly set under  the ConnectionStrings section:
 {
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=ProductManagement;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
Replace localhost and ProductManagement with your database server and database name.

5.Create the Database:Run below command in pacage manager console
 dotnet ef migrations add InitialCreate
dotnet ef database update


6.Run the application and test with swagger.

Technologies Used

ASP.NET Core 8: Web API framework
Entity Framework Core 8: ORM for database interaction
SQL Server: Database server
NUnit: Unit testing framework
Moq: Mocking library for unit testing
Swagger/OpenAPI: API documentation and testing interface (already available)