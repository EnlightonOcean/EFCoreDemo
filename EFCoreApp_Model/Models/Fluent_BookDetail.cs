namespace EFCoreApp_Model.Models;
public class Fluent_BookDetail
{
    public int Id { get; set; }
    public int NumberOfChapters { get; set; }
    public int NoOfPages { get; set; }
    public double Weight { get; set; }
    public Fluent_Book FluentBook { get; set; } = default!;
}
