namespace HC_7111.Domain.Objects;

public class Library
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Slug { get; set; } = null!;
}