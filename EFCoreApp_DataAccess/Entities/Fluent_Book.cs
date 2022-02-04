using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreApp_DataAccess.Entities;
public class Fluent_Book
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public string ISBN { get; set; } = default!;
    public double Price { get; set; }
    public int BookDetailId { get; set; }
    public Fluent_BookDetail BookDetail { get; set; } = default!;

    public Fluent_Publisher Publisher { get; set; } = default!;
    public ICollection<Fluent_BookAuthor> Authors { get; set; } = default!;
    
}
