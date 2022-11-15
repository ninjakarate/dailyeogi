namespace WebApi;

public class ReservedSlot
{
    public int Id { get; set; }
    public DateTimeOffset Date { get; set; }
    public int Index { get; set; }
    public string Description { get; set; } = "";
}
