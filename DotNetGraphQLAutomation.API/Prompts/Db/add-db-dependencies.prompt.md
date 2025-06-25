
# Task 2:
Ensure that the `global using Microsoft.EntityFrameworkCore;` statement exists in the project.

# Requirements:
1. Check if the file `Global.cs` exists in the project root or main project folder.
2. If it exists:
   - Add the line `global using Microsoft.EntityFrameworkCore;` if it's not already included.
3. If it does **not** exist:
   - Create a new file named `Global.cs` in the main project folder.
   - Add the following content:

```csharp
global using Microsoft.EntityFrameworkCore;
```

-----

# Task 3:
In `Program.cs`, register the project's DbContext using SQL Server.

# Requirements:
- Detect the class in the project that inherits from `DbContext`
- Add the following code before `var app = builder.Build();`:

```csharp
builder.Services.AddDbContext<DbContextClassName>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
```

----

# Task 4:
Ensure that the `global using ProjectName.Data` statement exists in the project.

# Requirements:
1. Check if the file `Global.cs` exists in the project root or main project folder.
2. If it exists:
   - Add the line `global using ProjectName.Data` if it's not already included.
3. If it does **not** exist:
   - Create a new file named `Global.cs` in the main project folder.
   - Add the following content:

```csharp
global using ProjectName.Data;
```