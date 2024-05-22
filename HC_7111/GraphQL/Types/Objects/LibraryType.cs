using HC_7111.Domain.Objects;

namespace HC_7111.GraphQL.Types.Objects;

[ObjectType<Library>]
public static partial class LibraryType
{
    static partial void Configure(IObjectTypeDescriptor<Library> descriptor)
    {
        descriptor
            .ImplementsNode()
            .IdField(p => p.Id);
    }
}
