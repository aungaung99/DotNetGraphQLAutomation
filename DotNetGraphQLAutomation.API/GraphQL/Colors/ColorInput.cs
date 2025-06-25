namespace DotNetGraphQLAutomation.API.GraphQL.Colors;

public class ColorInput
{
    public string ColorName { get; set; } = string.Empty;
    public bool Status { get; set; }
    public string? Remark { get; set; }
}

public class UpdateColorInput : ColorInput
{
    public int ColorId { get; set; }
}
