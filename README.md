# ASP.NETCoreSD46IsmailiaD11

# 🔷 ASP.NET Core Web API – Employees & Departments (.NET 9)

## 📌 Project Overview

This project is an **ASP.NET Core Web API** that demonstrates building a RESTful API using:

- ASP.NET Core
- Entity Framework Core
- SQL Server
- DTO Pattern
- Routing & Route Constraints
- CRUD Operations
- Entity Relationships
- Dependency Injection
- OpenAPI Documentation

The API manages **Employees** and **Departments**, allowing clients to perform CRUD operations and retrieve relational data.

---

# 🏗 Project Structure

```
ASP.NETCoreD11
│
├── Context
│   └── AppDbContext.cs
│
├── Controllers
│   ├── EmployeesController.cs
│   ├── RelationController.cs
│   └── TestController.cs
│
├── DTOs
│   └── Employee
│       └── EmployeeReadDto.cs
│
├── Models
│   ├── Employee.cs
│   └── Department.cs
│
└── Program.cs
```

---

# ⚙ Technologies Used

- .NET 8 / ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- OpenAPI
- Scalar API Documentation
- LINQ

---

# 🗄 Database Models

## Employee Model

```csharp
public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public decimal Salary { get; set; }

    public int DepartmentId { get; set; }
    public Department? Department { get; set; }
}
```

## Department Model

```csharp
public class Department
{
    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<Employee> Employees { get; set; }
}
```

---

# 🔗 Relationship

```
Department (1) -------- (Many) Employees
```

Each **Employee belongs to one Department**.

---

# 🧠 DbContext

`AppDbContext` is responsible for database communication.

```csharp
public class AppDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Department> Departments { get; set; }
}
```

---

# 🌱 Data Seeding

Initial data is seeded inside `OnModelCreating`.

Example Departments:

| Id | Name |
|----|------|
| 1  | SD   |
| 2  | UI   |
| 3  | Mob  |
| 4  | UX   |

Example Employees:

| Id | Name | Age | Salary | DepartmentId |
|----|------|-----|--------|--------------|
| 1  | Ahmed | 26 | 1234 | 1 |
| 2  | Mohamed | 36 | 2234 | 2 |
| 3  | Sara | 46 | 4234 | 3 |

---

# 🚀 API Endpoints

Base URL:

```
https://localhost:xxxx/api
```

---

# 👨‍💻 Employees Controller

Route:

```
api/Employees
```

---

## 1️⃣ Get All Employees

```
GET /api/Employees
```

Response:

```
200 OK
```

Returns list of employees.

---

## 2️⃣ Get Employee By Id

```
GET /api/Employees/{id}
```

Example:

```
GET /api/Employees/1
```

Response:

```
200 OK
```

If not found:

```
404 Not Found
```

---

## 3️⃣ Get Employee By Name

```
GET /api/Employees/{name}
```

Example:

```
GET /api/Employees/Ahmed
```

Uses **Route Constraint**

```
{name:alpha}
```

---

# ➕ Create Employee

## Create V01

```
POST /api/Employees/CreateV01
```

Response

```
200 OK
```

---

## Create V02

```
POST /api/Employees/CreateV02
```

Response

```
201 Created
```

---

## Create V03

```
POST /api/Employees/CreateV03
```

Example

```csharp
return Created("Test", employee);
```

---

## Create V04 (Recommended)

```
POST /api/Employees/CreateV04
```

Example

```csharp
return CreatedAtAction("GetById", new { id = employee.Id }, employee);
```

Returns the location of the created resource.

---

# 🔄 Update Employee

## Update V01

```
PUT /api/Employees/UpdateV01/{id}
```

```csharp
_context.Entry(employee).State = EntityState.Modified;
```

---

## Update V02 (Recommended)

```
PUT /api/Employees/UpdateV02/{id}
```

Steps:

1. Find employee
2. Update properties
3. SaveChanges()

---

# ❌ Delete Employee

```
DELETE /api/Employees/{id}
```

Response

```
204 NoContent
```

---

# 🔗 Relations Controller

Handles queries using **Entity Relationships**.

## Get Employee With Department

```
GET /EmployeeV01/{id}
```

Example:

```csharp
Include(e => e.Department)
```

---

## Get Employee Using DTO

```
GET /EmployeeV02/{id}
```

Returns:

```
EmployeeReadDto
```

Instead of the full entity.

---

# 📦 DTO (Data Transfer Object)

```csharp
public class EmployeeReadDto
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int Age { get; set; }

    public decimal Salary { get; set; }

    public int DepartmentId { get; set; }

    public string DepartmentName { get; set; }
}
```

DTOs help:

- Hide sensitive fields
- Control API responses
- Improve performance

---

# 🧪 Test Controller

Used to test routing.

Routes:

```
GET /api/Test
GET /api/Test/{id}
GET /api/Test/{name}
```

Route constraints:

```
{id:int}
{name:alpha}
```

---

# 📚 OpenAPI Documentation

Configured in `Program.cs`:

```csharp
builder.Services.AddOpenApi();
```

Available in **Development Environment**.

---

# ⚙ Program.cs

Responsible for configuring the application.

Example:

```csharp
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("ASPNETCoreD11"));
});
```

---

# 🔌 Dependency Injection

`AppDbContext` is injected into controllers.

```csharp
private readonly AppDbContext _context;

public EmployeesController(AppDbContext context)
{
    _context = context;
}
```

---

# ▶ Running the Project

## 1️⃣ Restore packages

```
dotnet restore
```

## 2️⃣ Run migrations

```
Add-Migration InitialCreate
Update-Database
```

## 3️⃣ Run project

```
dotnet run
```

---

# 🧠 Key Concepts Demonstrated

- RESTful API Design
- Entity Framework Core
- Dependency Injection
- Route Constraints
- CRUD Operations
- DTO Pattern
- Eager Loading
- HTTP Status Codes

---

# 👨‍💻 Author

Mohamed Hatem  
Software Engineer

---
