using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreApp_Model.Models;
public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    [MaxLength(15)]
    public string ISBN { get; set; } = default!;
    public double Price { get; set; }
    // public int RelatedToId { get; set; }
    // public Category RelatedTo { get; set; } = default!;
    //Add Relationship (One to One) Foregign Key
    //Comment ForeignKey tag to make foreign Key as nullable
    [ForeignKey("BookDetail")]
    public int? BookDetailId { get; set; }
    public BookDetail BookDetail { get; set; }= default!;

    //Add Relationship (One to One) Foregign Key
    public Publisher Publisher { get; set; }= default!;

    //Many to Many Relationship
    public ICollection<BookAuthor> BookAuthors { get; set; }= default!;
}
