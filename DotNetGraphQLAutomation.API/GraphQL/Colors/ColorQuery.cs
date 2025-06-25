using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using DotNetCrudAutomation.Data;
using DotNetCrudAutomation.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotNetGraphQLAutomation.API.GraphQL.Colors;

[ExtendObjectType("Query")]
public class ColorQuery
{
    [UsePaging]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Color> GetColors(DotNetAutomationDbContext dbContext, string? filter = null, string? sort = null)
    {
        var query = dbContext.Colors.AsQueryable();
        if (!string.IsNullOrWhiteSpace(filter))
        {
            query = query.Where(c => c.ColorName != null && c.ColorName.Contains(filter));
        }
        if (!string.IsNullOrWhiteSpace(sort))
        {
            query = sort.ToLower() switch
            {
                "name_desc" => query.OrderByDescending(c => c.ColorName),
                _ => query.OrderBy(c => c.ColorName),
            };
        }
        return query;
    }

    public Task<Color?> GetColorById(DotNetAutomationDbContext dbContext, int id)
    {
        return dbContext.Colors.FirstOrDefaultAsync(c => c.ColorId == id);
    }
}
