using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using DotNetCrudAutomation.Data;
using DotNetCrudAutomation.Entities;
using DotNetGraphQLAutomation.API.Model;
using Microsoft.EntityFrameworkCore;

namespace DotNetGraphQLAutomation.API.GraphQL.Brands;

[ExtendObjectType("Mutation")]
public class BrandMutation
{
    public async Task<BrandPayload> CreateBrand(
        DotNetAutomationDbContext dbContext,
        BrandInput input)
    {
        var brand = new Brand
        {
            BrandName = input.BrandName,
            Status = input.Status,
            Remark = input.Remark,
            CreatedOn = DateTime.UtcNow
        };
        dbContext.Brands.Add(brand);
        await dbContext.SaveChangesAsync();
        return new BrandPayload(new DefaultResponseMessageModel { EN = "Brand created successfully", MM = "" });
    }

    public async Task<BrandPayload> UpdateBrand(
        DotNetAutomationDbContext dbContext,
        UpdateBrandInput input)
    {
        var brand = await dbContext.Brands.FindAsync(input.BrandId);
        if (brand == null)
        {
            return new BrandPayload(new DefaultResponseMessageModel { EN = "Brand not found", MM = "" });
        }
        brand.BrandName = input.BrandName;
        brand.Status = input.Status;
        brand.Remark = input.Remark;
        brand.UpdatedOn = DateTime.UtcNow;
        await dbContext.SaveChangesAsync();
        return new BrandPayload(new DefaultResponseMessageModel { EN = "Brand updated successfully", MM = "" });
    }

    public async Task<BrandPayload> DeleteBrand(
        DotNetAutomationDbContext dbContext,
        int id)
    {
        var brand = await dbContext.Brands.FindAsync(id);
        if (brand == null)
        {
            return new BrandPayload(new DefaultResponseMessageModel { EN = "Brand not found", MM = "" });
        }
        dbContext.Brands.Remove(brand);
        await dbContext.SaveChangesAsync();
        return new BrandPayload(new DefaultResponseMessageModel { EN = "Brand deleted successfully", MM = "" });
    }
}
