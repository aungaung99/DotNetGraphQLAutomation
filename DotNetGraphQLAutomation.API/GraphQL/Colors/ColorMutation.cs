using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using DotNetCrudAutomation.Data;
using DotNetCrudAutomation.Entities;
using DotNetGraphQLAutomation.API.Model;
using Microsoft.EntityFrameworkCore;

namespace DotNetGraphQLAutomation.API.GraphQL.Colors;

[ExtendObjectType("Mutation")]
public class ColorMutation
{
    public async Task<ColorPayload> CreateColor(
        DotNetAutomationDbContext dbContext,
        ColorInput input)
    {
        var color = new Color
        {
            ColorName = input.ColorName,
            Status = input.Status,
            Remark = input.Remark,
            CreatedOn = DateTime.UtcNow
        };
        dbContext.Colors.Add(color);
        await dbContext.SaveChangesAsync();
        return new ColorPayload(new DefaultResponseMessageModel { EN = "Color created successfully", MM = "" });
    }

    public async Task<ColorPayload> UpdateColor(
        DotNetAutomationDbContext dbContext,
        UpdateColorInput input)
    {
        var color = await dbContext.Colors.FindAsync(input.ColorId);
        if (color == null)
        {
            return new ColorPayload(new DefaultResponseMessageModel { EN = "Color not found", MM = "" });
        }
        color.ColorName = input.ColorName;
        color.Status = input.Status;
        color.Remark = input.Remark;
        color.UpdatedOn = DateTime.UtcNow;
        await dbContext.SaveChangesAsync();
        return new ColorPayload(new DefaultResponseMessageModel { EN = "Color updated successfully", MM = "" });
    }

    public async Task<ColorPayload> DeleteColor(
        DotNetAutomationDbContext dbContext,
        int id)
    {
        var color = await dbContext.Colors.FindAsync(id);
        if (color == null)
        {
            return new ColorPayload(new DefaultResponseMessageModel { EN = "Color not found", MM = "" });
        }
        dbContext.Colors.Remove(color);
        await dbContext.SaveChangesAsync();
        return new ColorPayload(new DefaultResponseMessageModel { EN = "Color deleted successfully", MM = "" });
    }
}
