using DotNetCrudAutomation.Entities;
using DotNetGraphQLAutomation.API.Model;

namespace DotNetGraphQLAutomation.API.GraphQL.Brands;

public class BrandType : ObjectType<Brand>
{
    protected override void Configure(IObjectTypeDescriptor<Brand> descriptor)
    {
        descriptor.Field(b => b.BrandId).Type<NonNullType<IdType>>();
        descriptor.Field(b => b.BrandName).Type<StringType>();
        descriptor.Field(b => b.Status).Type<BooleanType>();
        descriptor.Field(b => b.Remark).Type<StringType>();
        // ...other fields as needed
    }
}
