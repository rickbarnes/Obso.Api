namespace Domain.Board;

public sealed class BoardEntity
{
    public Guid BoardId { get; set; }

    public string Name { get; set; }

    public Guid TenantId { get; set; }
}