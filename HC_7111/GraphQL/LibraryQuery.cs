using HC_7111.Domain.Objects;

namespace HC_7111.GraphQL;

[QueryType]
public class LibraryQuery
{
    [UseFirstOrDefault]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Library> Library()
    {
        return Constants.Libraries.AsQueryable();
    }
}