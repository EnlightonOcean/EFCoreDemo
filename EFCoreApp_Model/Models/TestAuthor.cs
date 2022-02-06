using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreApp_Model.Models;
///Books to Author Many to Many
public class TestAuthor
{
    public int Id { get; set; }
    public string FirstName { get; set; }=default!;
    public string LastName { get; set; }=default!;
    public DateTime BirthDate { get; set; }
    public string? Location { get; set; }
    //Many to Many Relationship
    public ICollection<TestBook> Books { get; set; }= default!;
    [NotMapped]
    public string FullName { get{
            return $"{FirstName} {LastName}";
        } 
    }
}
