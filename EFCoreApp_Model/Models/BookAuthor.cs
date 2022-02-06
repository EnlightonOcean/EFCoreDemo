namespace EFCoreApp_Model.Models;
public class BookAuthor
{
    public int BookId { get; set; }
    public int AuthorId { get; set; }
    public Book Book { get; set; } = default!;
    public Author Author { get; set; } = default!;
}
