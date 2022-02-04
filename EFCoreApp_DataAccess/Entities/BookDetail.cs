using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreApp_DataAccess.Entities;
public class BookDetail
{
    public int Id { get; set; }
    public int NumberOfChapters { get; set; }
    public int NoOfPages { get; set; }
    public double Weight { get; set; }
    //Add Relationship (one to One) Foreign key
    public Book Book { get; set; } = default!;
}
