using DotNetGraphQLAutomation.API.Model;

namespace DotNetGraphQLAutomation.API.GraphQL.Brands;

public class BrandPayload
{
    public DefaultResponseMessageModel Response { get; set; }
    public BrandPayload(DefaultResponseMessageModel response)
    {
        Response = response;
    }
}
