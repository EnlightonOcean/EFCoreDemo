namespace EFCoreApp_Model.Models;
//Publisher to Book one to many
public class Fluent_Publisher
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Location { get; set; } = default!;
 
    public ICollection<Fluent_Book> FluentBooks { get; set; } = default!;
}
