# 📚 Week 1 Summary

## 2.1 Value Types vs Reference Types
- Learned the difference between **Value Types** (`int`, `bool`, `struct`) and **Reference Types** (`class`, `string`, `array`).
- Value types store the actual data and are copied by value.
- Reference types store a reference to an object in memory, so multiple variables can point to the same object.
- Understanding this difference helps avoid unexpected bugs when working with objects.

---

## 2.2 Variables, Type Inference, and Naming
- Learned how to declare variables using explicit types.
- Learned to use the `var` keyword for type inference.
- Understood that `var` is still strongly typed; the compiler determines the type at compile time.
- Used meaningful variable names to improve code readability and maintainability.

---

## 2.3 Control Flow
Learned how to control program execution using:
- `if` / `else`
- `switch`
- `switch` expressions
- `for`
- `foreach`
- `while`

Also learned when each control structure is most appropriate.

---

## 2.4 Nullable Reference Types
- Learned how nullable reference types improve code safety.
- Understood the difference between:
  ```csharp
  string name;
  string? name;
  ```
- Used null checks to prevent `NullReferenceException`.
- Learned how the compiler warns about potential null-related issues before runtime.

---

# 3. Object-Oriented Programming (OOP)

## 3.1 Classes, Records, and Structs

### Classes
- Learned that classes are reference types.
- Used classes to represent objects with both data and behavior.

### Records
- Learned that records are designed for immutable data.
- Understood that records compare objects by value instead of by reference.

### Structs
- Learned that structs are value types.
- Used structs for small, lightweight data structures.

---

## 3.2 Encapsulation and Access Modifiers
- Learned the concept of encapsulation to protect object data.
- Used access modifiers:
  - `public`
  - `private`
  - `protected`
  - `internal`
- Used properties to safely expose class data while keeping fields private.

---

## 3.3 Inheritance and Interfaces

### Inheritance
- Learned how a derived class inherits members from a base class.
- Used inheritance to model "is-a" relationships.

Example:
```
Admin : User
```

### Interfaces
- Learned that interfaces define contracts without implementation.
- Implemented interfaces in multiple classes to provide common functionality.
- Understood why interfaces provide greater flexibility than deep inheritance hierarchies.

---

## 3.4 Polymorphism
- Learned how polymorphism allows code to work with different object types through a common base class or interface.
- Understood how this improves flexibility, extensibility, and maintainability.

---

# 4. Collections and LINQ

## 4.1 Choosing the Right Collection

Learned when to use different collections:

### List<T>
- Ordered collection for general-purpose data storage.

### Dictionary<TKey, TValue>
- Fast key-value lookups.

### HashSet<T>
- Stores unique elements without duplicates.

---

## 4.2 LINQ
Learned how to query and manipulate collections using LINQ.

Common methods:
- `Where()`
- `Select()`
- `OrderBy()`
- `OrderByDescending()`
- `First()`
- `FirstOrDefault()`
- `Any()`
- `Count()`

Learned both LINQ styles:

### Method Syntax
```csharp
users.Where(u => u.IsActive)
     .Select(u => u.Name);
```

### Query Syntax
```csharp
from u in users
where u.IsActive
select u.Name;
```

---

## 4.3 Async / Await
- Learned how asynchronous programming works in C#.
- Created asynchronous methods using `async` and `await`.
- Used `Task` to represent asynchronous operations.
- Understood why asynchronous programming improves application responsiveness and scalability.

---

## 4.4 Exception Handling
Learned how to handle runtime errors using:

```csharp
try
{
    // Code
}
catch
{
    // Handle exception
}
finally
{
    // Cleanup code
}
```

- Used `try` to wrap risky code.
- Used `catch` to handle exceptions.
- Used `finally` for cleanup operations that should always execute.

---

# 5. Git & GitHub

## 5.1 Git Fundamentals
Learned the basic Git workflow:

```bash
git init
git status
git add .
git commit -m "message"
git push
git pull
```

Understood that every commit represents a snapshot of the project.

---

## 5.2 Feature Branch Workflow
- Learned to create and work on feature branches instead of committing directly to `main`.

Example:

```bash
git checkout -b feature/week1
```

- Learned how feature branches support collaboration and keep the main branch stable.

---

## 5.3 Writing Good Commit Messages
Learned to write clear and descriptive commit messages.

Examples:

```text
Add student model
Implement LINQ examples
Fix null reference exception
Refactor user service
```

Avoid vague messages like:

```text
update
fix
stuff
```

---

## 5.4 Pull Requests
- Learned how to create a Pull Request after completing work on a feature branch.
- Included a clear description of the implemented changes.
- Understood the importance of code review before merging into the `main` branch.

---

# ✅ Skills Gained

During Week 1, I gained practical experience with:

- C# Fundamentals
- Value Types vs Reference Types
- Variables and Type Inference
- Control Flow
- Nullable Reference Types
- Object-Oriented Programming (OOP)
- Classes, Records, and Structs
- Encapsulation
- Inheritance
- Interfaces
- Polymorphism
- Collections
- LINQ
- Asynchronous Programming (Async/Await)
- Exception Handling
- Git Fundamentals
- Feature Branch Workflow
- Writing Meaningful Commit Messages
- Pull Requests







# Week 2 — Advanced C# & ASP.NET Core Foundations 🚀

## 📌 Overview

During Week 2, I moved from basic C# fundamentals into advanced C# concepts and started building real ASP.NET Core Web APIs.

The focus was understanding how modern .NET applications are structured, how data is processed efficiently, how asynchronous operations work, and how HTTP requests travel through the ASP.NET Core pipeline.

This week covered:

- Advanced C# type system
- Generics and reusable code
- Advanced LINQ operations
- Async/Await and concurrency
- ASP.NET Core Web API architecture
- Routing and HTTP verbs
- Middleware pipeline
- Dependency Injection
- Building and testing REST APIs

---

# 🧠 Topics Learned

## 1. Advanced C# Generics

### What are Generics?

Generics allow creating reusable classes and methods while maintaining type safety.

Before generics, developers used `object` collections which required casting and could cause runtime errors.

Example:

```csharp
List<int> numbers = new();
List<string> names = new();
```

The compiler knows the exact type stored in each collection.

---

## Generic Classes

Created reusable generic components:

```csharp
public class Repository<T> where T : class
{
    private readonly List<T> items = new();

    public void Add(T item)
    {
        items.Add(item);
    }

    public IReadOnlyList<T> GetAll()
    {
        return items.AsReadOnly();
    }
}
```

### Concepts Practiced:

- Type parameters `<T>`
- Generic constraints
- Reusable architecture
- Type safety

---

# 2. Advanced Collections

Learned the difference between:

| Interface | Usage |
|-|-|
| IEnumerable<T> | Read-only iteration |
| IReadOnlyList<T> | Read-only list with index access |
| IList<T> | Full modification |

Best practice:

> Return the least powerful interface needed.

Example:

```csharp
IEnumerable<User> GetUsers()
```

is better than:

```csharp
List<User> GetUsers()
```

because it prevents unnecessary modifications.

---

# 3. Advanced LINQ

LINQ is used to query and transform collections.

## Deferred Execution

LINQ queries do not execute immediately.

Example:

```csharp
var result = users.Where(x => x.Age > 18);
```

The query runs only when:

```csharp
foreach(var user in result)
```

or:

```csharp
result.ToList();
```

---

## GroupBy

Used for grouping data.

Example:

Grouping orders by customer:

```csharp
var orders =
ordersList
.GroupBy(o => o.CustomerId)
.Select(g => new
{
    Customer = g.Key,
    Total = g.Sum(x => x.Amount)
});
```

---

## Join

Combining related collections.

Example:

Customers + Orders:

```csharp
var result =
customers.Join(
orders,
c => c.Id,
o => o.CustomerId,
(c,o)=> new
{
    c.Name,
    o.Amount
});
```

---

## SelectMany

Used for flattening nested collections.

Example:

Before:

```
Customer
   |
   Orders
      |
      Items
```

After SelectMany:

```
Item
Item
Item
```

---

# 4. Async/Await & Concurrency

Learned how asynchronous programming improves application performance.

## Task

Represents an operation that will complete in the future.

Example:

```csharp
public async Task<string> GetDataAsync()
{
    await Task.Delay(1000);

    return "Finished";
}
```

---

## Async All The Way

Avoid:

```csharp
var result = GetDataAsync().Result;
```

Correct:

```csharp
var result = await GetDataAsync();
```

---

## Task.WhenAll

Running multiple operations concurrently.

Example:

```csharp
var task1 = GetUsersAsync();
var task2 = GetOrdersAsync();
var task3 = GetProductsAsync();

await Task.WhenAll(task1,task2,task3);
```

Instead of waiting:

```
Task1 → Task2 → Task3

3 seconds
```

They run together:

```
Task1
Task2
Task3

1 second
```

---

## CancellationToken

Used to stop long-running operations.

Example:

```csharp
public async Task ProcessAsync(
CancellationToken token)
{
    await Task.Delay(5000, token);
}
```

---

# 5. ASP.NET Core Web API

Created the first Web API project.

Architecture:

```
Client
 |
HTTP Request
 |
Middleware Pipeline
 |
Routing
 |
Controller
 |
Service
 |
Response
```

---

# 6. Controllers & Routing

Created API endpoints using Controllers.

Example:

```csharp
[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{

}
```

---

## HTTP Methods

| Method | Purpose |
|-|-|
| GET | Retrieve data |
| POST | Create data |
| PUT | Update data |
| DELETE | Remove data |

Example:

```
GET /api/books

GET /api/books/5

POST /api/books

DELETE /api/books/5
```

---

# 7. Minimal APIs

Learned creating endpoints directly in Program.cs.

Example:

```csharp
app.MapGet("/books",
() =>
{
    return books;
});
```

Compared with Controllers:

| Controllers | Minimal APIs |
|-|-|
| Better for large projects | Good for small APIs |
| Organized structure | Less code |
| Easier testing | Faster development |

---

# 8. Middleware Pipeline

Middleware is a chain that every HTTP request passes through.

Example:

```
Request

 ↓

HTTPS Middleware

 ↓

Authentication

 ↓

Authorization

 ↓

Controller

 ↓

Response
```

---

Created custom middleware:

```csharp
public class LoggingMiddleware
{
    private readonly RequestDelegate next;

    public LoggingMiddleware(RequestDelegate next)
    {
        this.next = next;
    }


    public async Task Invoke(HttpContext context)
    {
        Console.WriteLine(
        context.Request.Path);

        await next(context);
    }
}
```

---

# 9. Dependency Injection (DI)

Learned how ASP.NET Core manages dependencies.

Instead of:

```csharp
var service = new BookService();
```

We inject:

```csharp
public BooksController(
IBookService service)
{
    _service = service;
}
```

---

## Service Lifetimes

| Lifetime | Description |
|-|-|
| Transient | New instance every request |
| Scoped | One instance per HTTP request |
| Singleton | One instance for whole application |

Example:

```csharp
builder.Services
.AddScoped<IBookService,BookService>();
```

---

# 🛠️ Project 1: Generic Repository & LINQ Analyzer

## Description

A C# console application demonstrating:

- Generic Repository Pattern
- Generic Constraints
- Advanced LINQ
- Grouping
- Joining
- SelectMany
- Deferred Execution


## Features

✅ Add entities dynamically  
✅ Search using predicates  
✅ Group data  
✅ Join related collections  
✅ Flatten nested objects  


## Technologies

- C#
- .NET SDK
- LINQ

---

## Project Structure

```
GenericRepositoryProject

│
├── Models
│   ├── Customer.cs
│   ├── Order.cs
│
├── Repository
│   └── Repository.cs
│
├── Services
│   └── LinqService.cs
│
└── Program.cs
```

---

# 🛠️ Project 2: Book Management REST API

## Description

A complete ASP.NET Core Web API for managing books.

The project applies:

- Controllers
- Routing
- Middleware
- Dependency Injection
- Services
- DTO pattern
- Async operations


---

## Features

### Books API

```
GET /api/books

GET /api/books/{id}

POST /api/books

PUT /api/books/{id}

DELETE /api/books/{id}
```

---

## Architecture

```
BookAPI

│
├── Controllers
│     └── BooksController.cs
│
├── Services
│     ├── IBookService.cs
│     └── BookService.cs
│
├── DTOs
│     └── BookDTO.cs
│
├── Models
│     └── Book.cs
│
├── Middleware
│     └── LoggingMiddleware.cs
│
└── Program.cs
```

---

# Testing

Used:

- Swagger
- Postman


Tested:

✅ GET Requests  
✅ POST Requests  
✅ PUT Requests  
✅ DELETE Requests  


---

# GitHub Deliverables

Completed:

✅ Generic Repository implementation

✅ LINQ exercises

✅ Async concurrency demo

✅ ASP.NET Core Web API

✅ Controllers

✅ Minimal APIs

✅ Middleware

✅ Dependency Injection


---

# Skills Gained

After completing Week 2:

- Ability to design reusable C# components
- Understanding LINQ data processing
- Writing asynchronous code correctly
- Building REST APIs with ASP.NET Core
- Understanding request lifecycle
- Applying Dependency Injection
- Structuring backend projects professionally


---

# Next Step 🚀

Week 3 will extend these foundations by adding:

- Entity Framework Core
- SQL Server
- Database relationships
- Authentication
- Advanced REST API design
- Real data persistence



# Week 3 — Backend & REST API Development

During this week, I learned how to design, build, test, and document a complete RESTful API using ASP.NET Core, Entity Framework Core, and SQL Server.

### What I Learned

* **REST API Design**

  * Understanding REST principles and stateless architecture.
  * Designing clean resource-based endpoints using HTTP verbs.
  * Applying proper resource naming and nested resources.
  * Using HTTP status codes correctly.
  * Understanding API versioning.

* **Database Design & Normalization**

  * Designing relational database schemas.
  * Applying **1NF, 2NF, and 3NF**.
  * Working with Primary Keys, Foreign Keys, and relationships.
  * Designing one-to-many and many-to-many relationships.
  * Choosing appropriate SQL Server data types.

* **Entity Framework Core**

  * Configuring EF Core with SQL Server.
  * Creating Entity classes and `DbContext`.
  * Using Code-First development.
  * Creating and applying database migrations.
  * Managing database connection strings and configuration securely.

* **CRUD Operations**

  * Implementing **Create, Read, Update, and Delete** operations.
  * Using asynchronous EF Core methods such as `ToListAsync()` and `SaveChangesAsync()`.
  * Handling validation and `404 Not Found` cases.
  * Understanding EF Core change tracking and `AsNoTracking()`.

* **API Testing with Postman**

  * Creating and organizing Postman collections.
  * Testing both successful and error scenarios.
  * Using Postman environments and variables.
  * Writing basic automated tests for API responses.
  * Documenting API endpoints and expected responses.

### Technologies & Tools

`C#` · `ASP.NET Core` · `Entity Framework Core` · `SQL Server` · `REST API` · `Postman` · `Docker` · `Git & GitHub`

### Outcome

By the end of the week, I was able to design a normalized database, build a RESTful API connected to SQL Server using EF Core, implement complete CRUD functionality, and test the API systematically using Postman.




# Week 4 — Authentication, Identity & Input Validation

During Week 4, I learned and implemented the main security components required to secure an ASP.NET Core Web API.

## What I Learned

* **ASP.NET Core Identity**

  * Integrated ASP.NET Core Identity with Entity Framework Core.
  * Implemented user registration using `UserManager`.
  * Learned how Identity securely hashes and stores passwords using PBKDF2.
  * Worked with users and roles.

* **JWT Authentication**

  * Learned the structure of JSON Web Tokens (JWT) and claims.
  * Implemented a login endpoint that issues JWT access tokens.
  * Configured JWT Bearer Authentication in ASP.NET Core.
  * Learned about token expiration and refresh tokens.
  * Learned how to securely manage JWT signing keys and avoid exposing secrets in source control.

* **Authorization & Role-Based Access Control**

  * Protected API endpoints using the `[Authorize]` attribute.
  * Implemented role-based authorization using roles such as `User` and `Admin`.
  * Learned the difference between `401 Unauthorized` and `403 Forbidden`.
  * Learned about claims-based and policy-based authorization.
  * Tested protected endpoints using Postman and Bearer Tokens.

* **Input Validation with FluentValidation**

  * Compared DataAnnotations with FluentValidation.
  * Created validators for Create and Update request models.
  * Implemented business validation rules.
  * Integrated FluentValidation into the ASP.NET Core request pipeline.
  * Returned structured validation errors using `ValidationProblemDetails`.
  * Tested validation rules individually using Postman.

* **API Security & Hardening**

  * Implemented **Rate Limiting** to reduce brute-force and denial-of-service attempts.
  * Configured **CORS** to control which origins can access the API.
  * Learned about security headers such as **HTTPS, HSTS, and Content-Security-Policy**.
  * Learned how Entity Framework Core uses parameterized queries to help prevent SQL Injection.
  * Reviewed raw SQL usage and learned how unsafe string interpolation can bypass these protections.

## Technologies & Tools

`C#` • `.NET` • `ASP.NET Core Identity` • `JWT` • `Entity Framework Core` • `FluentValidation` • `SQL Server` • `Postman` • `CORS` • `Rate Limiting` • `HTTPS/HSTS`

## Outcome

By the end of Week 4, I learned how to transform a basic CRUD REST API into a more secure API by implementing authentication, authorization, input validation, and security hardening.


# Week 5 — Testing & Error Handling

## Overview

During Week 5, I learned and practiced automated testing, mocking, integration testing, global exception handling, and structured error responses using ASP.NET Core and .NET 10.

---

## Day 1 — Unit Testing

Learned how to write unit tests using **xUnit** and test business logic independently.

### Example

```csharp
[Fact]
public void CalculateFinalPrice_ReturnsCorrectPrice()
{
    var calculator = new ProductCalculator();

    var result = calculator.CalculateFinalPrice(100m, 20);

    Assert.Equal(80m, result);
}
```

Topics:

* xUnit
* `[Fact]`
* Assertions
* Testing success and failure cases

---

## Day 2 — Mocking with Moq

Learned how to replace external dependencies such as repositories with mocks.

### Example

```csharp
var mockRepo = new Mock<IOrderRepository>();

mockRepo
    .Setup(r => r.GetByIdAsync(1))
    .ReturnsAsync(new Order
    {
        Id = 1,
        Total = 99.99m
    });

var service = new OrderService(mockRepo.Object);

var result = await service.GetOrderTotalAsync(1);

Assert.Equal(99.99m, result);
```

Also practiced:

```csharp
mockRepo.Verify(
    r => r.GetByIdAsync(1),
    Times.Once);
```

And mocking exceptions:

```csharp
mockRepo
    .Setup(r => r.GetByIdAsync(1))
    .ThrowsAsync(
        new InvalidOperationException("Database error"));
```

---

## Day 3 — Integration Testing

Learned how to test the complete ASP.NET Core pipeline using `WebApplicationFactory`.

### Example

```csharp
var response =
    await _client.GetAsync("/api/orders/1");

Assert.Equal(
    HttpStatusCode.OK,
    response.StatusCode);
```

Also tested:

* GET endpoint happy path
* Not Found response
* Response body
* EF Core In-Memory database
* Protected endpoints and authentication

---

## Day 4 — Global Exception Handling

Implemented centralized exception handling using custom middleware.

Instead of adding `try/catch` to every endpoint, exceptions are handled in one place.

### Example

```csharp
try
{
    await _next(context);
}
catch (Exception ex)
{
    _logger.LogError(ex, "Unhandled exception");

    context.Response.StatusCode = 500;

    await context.Response.WriteAsJsonAsync(
        new ProblemDetails
        {
            Title = "An unexpected error occurred.",
            Status = 500
        });
}
```

Learned:

* Global Exception Middleware
* `ProblemDetails`
* HTTP 500 responses
* Structured logging
* Avoiding sensitive error information in API responses

---

## Day 5 — Testing Strategy

Learned how to prioritize testing based on risk and complexity.

High-priority areas include:

* Business logic
* Authentication
* Money calculations
* Complex conditions
* Previously fixed bugs

### Example

```csharp
[Fact]
public void CalculateFinalPrice_ThrowsException_WhenPriceIsNegative()
{
    var calculator = new ProductCalculator();

    Assert.Throws<ArgumentException>(
        () => calculator.CalculateFinalPrice(-100m, 20));
}
```

Also practiced running the complete test suite:

```bash
dotnet test
```

---

## Technologies Used

* C#
* .NET 10
* ASP.NET Core
* xUnit
* Moq
* Entity Framework Core
* WebApplicationFactory
* ProblemDetails
* Git & GitHub

## Week 5 Outcome

By the end of Week 5, I gained practical experience in **unit testing, mocking, integration testing, global exception handling, structured logging, and test strategy**, creating a strong testing foundation for the Phase 3 project.



