using DotNetGraphQLAutomation.API.Model;

namespace DotNetGraphQLAutomation.API.GraphQL.Colors;

public class ColorPayload
{
    public DefaultResponseMessageModel Response { get; set; }
    public ColorPayload(DefaultResponseMessageModel response)
    {
        Response = response;
    }
}
