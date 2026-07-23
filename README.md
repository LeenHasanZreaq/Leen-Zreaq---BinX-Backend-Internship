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