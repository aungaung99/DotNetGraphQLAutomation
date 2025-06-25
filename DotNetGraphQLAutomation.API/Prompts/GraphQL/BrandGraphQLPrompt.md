# Brand GraphQL Implementation Prompt

## Folder Structure

```
GraphQL/
└── Brands/
    ├── BrandQuery.cs
    ├── BrandMutation.cs
    ├── BrandType.cs
    ├── BrandInput.cs
    └── BrandPayload.cs
```

## Requirements

### 1. CRUD Operations

- **Queries**:  
  - List all brands (with filtering and sorting support).
  - Get a single brand by ID.

- **Mutations**:  
  - Create a brand (POST).
  - Update a brand (PUT).
  - Delete a brand (DELETE).

### 2. Return Type for Mutations

- All mutation actions (POST, PUT, DELETE) must return a `DefaultResponseMessageModel` as the payload, wrapped in a `BrandPayload` type.

### 3. Filtering and Sorting

- The list brands query must support:
  - **Filtering**: By brand name (partial match).
  - **Sorting**: By brand name (asc/desc).

### 4. File Responsibilities

- **BrandQuery.cs**:  
  - Defines GraphQL queries for brands, including filtering and sorting.

- **BrandMutation.cs**:  
  - Defines GraphQL mutations for create, update, and delete actions, returning `BrandPayload`.

- **BrandType.cs**:  
  - GraphQL type definition for the Brand entity.

- **BrandInput.cs**:  
  - Input types for create and update mutations.

- **BrandPayload.cs**:  
  - Payload type for mutation responses, wrapping `DefaultResponseMessageModel`.

---

## Example Query & Mutation

### Query (with filtering and sorting)
```
query {
  brands(filter: "Acme", sort: "name_desc") {
    id
    name
  }
}
```

### Mutation (Create)
```
mutation {
  createBrand(input: { name: "NewBrand" }) {
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
