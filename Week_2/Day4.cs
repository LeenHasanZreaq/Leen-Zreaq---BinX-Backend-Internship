var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Simple GET endpoint
app.MapGet("/", () => "Hello Lin! Your API is running 🚀");

// GET with a route parameter
app.MapGet("/hello/{name}", (string name) => $"Hello, {name}!");

// In-memory "database" for demo purposes
var todos = new List<string> { "Learn Spring Boot", "Study cybersecurity" };

// GET all todos
app.MapGet("/todos", () => todos);

// POST a new todo
app.MapPost("/todos", (string task) =>
{
    todos.Add(task);
    return Results.Created($"/todos/{todos.Count - 1}", task);
});

app.Run();