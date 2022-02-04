namespace EFCoreApp_DataAccess.Entities;
///Books to Author Many to Many
public class Fluent_Author
{
    public int Id { get; set; }
    public string FirstName { get; set; }=default!;
    public string LastName { get; set; }=default!;
    public DateTime BirthDate { get; set; }
    public string? Location { get; set; }
    public string FullName { get{
            return $"{FirstName} {LastName}";
        } 
    }
    public ICollection<Fluent_BookAuthor> Books { get; set; } = default!;
}
