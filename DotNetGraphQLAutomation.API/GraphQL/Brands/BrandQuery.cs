using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using DotNetCrudAutomation.Data;
using DotNetCrudAutomation.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotNetGraphQLAutomation.API.GraphQL.Brands;

[ExtendObjectType("Query")]
public class BrandQuery
{
    [UsePaging]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Brand> GetBrands(DotNetAutomationDbContext dbContext, string? filter = null, string? sort = null)
    {
        var query = dbContext.Brands.AsQueryable();
        if (!string.IsNullOrWhiteSpace(filter))
        {
            query = query.Where(b => b.BrandName != null && b.BrandName.Contains(filter));
        }
        if (!string.IsNullOrWhiteSpace(sort))
        {
            query = sort.ToLower() switch
            {
                "name_desc" => query.OrderByDescending(b => b.BrandName),
                _ => query.OrderBy(b => b.BrandName),
            };
        }
        return query;
    }

    public Task<Brand?> GetBrandById(DotNetAutomationDbContext dbContext, int id)
    {
        return dbContext.Brands.FirstOrDefaultAsync(b => b.BrandId == id);
    }
}
