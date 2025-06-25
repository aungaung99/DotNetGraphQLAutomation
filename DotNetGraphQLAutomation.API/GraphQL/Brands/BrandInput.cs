namespace DotNetGraphQLAutomation.API.GraphQL.Brands;

public class BrandInput
{
    public string BrandName { get; set; } = string.Empty;
    public bool Status { get; set; }
    public string? Remark { get; set; }
}

public class UpdateBrandInput : BrandInput
{
    public int BrandId { get; set; }
}
