# Task 1:
Scaffold the database context and entities for a .NET project using Entity Framework Core.

## Requirements:
- Run the following command in Developer PowerShell:

```bash
dotnet ef dbcontext scaffold "Server=.;Database=DotNetAutomation;Trusted_Connection=True;TrustServerCertificate=true;" Microsoft.EntityFrameworkCore.SqlServer --output-dir Entities --namespace DotNetCrudAutomation.Entities --context-dir Data --context DotNetAutomationDbContext --context-namespace DotNetCrudAutomation.Data --data-annotations --no-onconfiguring -f --project DotNetGraphQLAutomation.API/DotNetGraphQLAutomation.API
```
