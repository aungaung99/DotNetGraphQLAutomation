# Color GraphQL Implementation Prompt

## Folder Structure
GraphQL/
└── Colors/
    ├── ColorQuery.cs
    ├── ColorMutation.cs
    ├── ColorType.cs
    ├── ColorInput.cs
    └── ColorPayload.cs

## Requirements

### 1. CRUD Operations

- **Queries**:  
  - List all colors (with filtering and sorting support).
  - Get a single color by ID.
  - add these attributes [UsePaging] [UseFiltering] [UseSorting]

- **Mutations**:  
  - Create a color (POST).
  - Update a color (PUT).
  - Delete a color (DELETE).

### 2. Return Type for Mutations

- All mutation actions (POST, PUT, DELETE) must return a `DefaultResponseMessageModel` as the payload, wrapped in a `ColorPayload` type.

### 3. Filtering and Sorting

- The list colors query must support:
  - **Filtering**: By color name (partial match).
  - **Sorting**: By color name (asc/desc).

### 4. File Responsibilities

- **ColorQuery.cs**:  
  - Defines GraphQL queries for colors, including filtering and sorting.
  - Add this attribute [ExtendObjectType("Query")]

- **ColorMutation.cs**:  
  - Defines GraphQL mutations for create, update, and delete actions, returning `ColorPayload`.
  - Mutations should accept `DotNetAutomationDbContext dbContext` as a service parameter (no `[UseDbContext]` or `[ScopedService]` attributes).
  - Use [Service] for mutation methods to inject the database context.
  - Add this attribute [ExtendObjectType("Mutation")]

- **ColorType.cs**:  
  - GraphQL type definition for the Color entity.

- **ColorInput.cs**:  
  - Input types for create and update mutations.

- **ColorPayload.cs**:  
  - Payload type for mutation responses, wrapping `DefaultResponseMessageModel`.

### 5. Add in Program.cs
- Register the GraphQL types and mutations in `Program.cs`
- Ensure the GraphQL endpoint is set up correctly.
- Use the following code snippet to register the types and mutations:
```csharp
builder.Services
    .AddGraphQLServer()
    .AddQueryType(d => d.Name("Query"))
    .AddMutationType(d => d.Name("Mutation"))
    .AddType<ColorType>()
    .AddTypeExtension<ColorQuery>()
    .AddTypeExtension<ColorMutation>()
    .AddFiltering() // Enable filtering if not already included
    .AddSorting()
    .AddProjections();
```

## Example Query & Mutation

### Query (with filtering and sorting)
```graphql
query {
  colors(filter: "Red", sort: "name_desc") {
    id
    name
  }
}
```
### Mutation (Create)
```graphql
mutation {
  createColor(input: { name: "NewColor" }) {
    response {
      success
      message
    }
  }
}
```
---

## Notes

- Use dependency injection for data access.
- Ensure all mutations return a `DefaultResponseMessageModel` in the payload.
- Use best practices for GraphQL in .NET 9.

---
