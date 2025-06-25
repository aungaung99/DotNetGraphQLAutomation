# Angular CRUD with GraphQL Prompts

## 1. Generate Angular Service for GraphQL
Generate an Angular service named `{entity}Service` that uses Apollo Angular to perform CRUD operations for the `{entity}` entity. The service should include methods for:
- getAll{EntityPlural}()
- get{Entity}ById(id: string)
- create{Entity}(input: {Entity}Input)
- update{Entity}(id: string, input: {Entity}Input)
- delete{Entity}(id: string)

## 2. Generate GraphQL Queries and Mutations
Create a TypeScript file `{entity}.graphql.ts` that exports the following GraphQL operations as gql-tagged strings:
- GET_ALL_{ENTITY_UPPER}
- GET_{ENTITY_UPPER}_BY_ID
- CREATE_{ENTITY_UPPER}
- UPDATE_{ENTITY_UPPER}
- DELETE_{ENTITY_UPPER}

## 3. Generate Angular Component
Generate a pluralized component named `{entity}s` (e.g., `brands`, `colors`). This component:
- Displays all entities in a table or list, supports delete and edit actions.
- Contains an entry dialog (within the same component) for creating and editing an entity.
- When deleting, shows a PrimeNG confirmation dialog (styled with Tailwind CSS) to confirm the delete action.

## 4. Update Routing
Add a route for the `{entity}s` component in the Angular router.

## 5. UI Integration
Use PrimeNG components for all UI elements (tables, dialogs, forms, buttons, etc.).
Apply Tailwind CSS utility classes for layout and styling enhancements alongside PrimeNG components.
