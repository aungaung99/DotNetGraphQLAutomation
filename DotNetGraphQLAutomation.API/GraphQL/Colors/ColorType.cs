using DotNetCrudAutomation.Entities;
using HotChocolate.Types;

namespace DotNetGraphQLAutomation.API.GraphQL.Colors;

public class ColorType : ObjectType<Color>
{
    protected override void Configure(IObjectTypeDescriptor<Color> descriptor)
    {
        descriptor.Field(c => c.ColorId).Type<NonNullType<IdType>>();
        descriptor.Field(c => c.ColorName).Type<StringType>();
        descriptor.Field(c => c.Status).Type<BooleanType>();
        descriptor.Field(c => c.Remark).Type<StringType>();
        // ...other fields as needed
    }
}
