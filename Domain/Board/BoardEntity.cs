namespace Domain.Board;

public sealed class BoardEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public int BackgroundType { get; set; }

    public string BackgroundColor { get; set; }

    public string BackgroundImageUrl { get; set; }

    public List<string> ColumnIds { get; set; }

    public string OwnerId { get; set; }

    public List<string> UserIds { get; set; }

    public Guid TenantId { get; set; }
}