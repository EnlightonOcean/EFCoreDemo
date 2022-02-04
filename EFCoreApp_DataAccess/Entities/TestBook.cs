using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreApp_DataAccess.Entities;
public class TestBook
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    [MaxLength(15)]
    public string ISBN { get; set; } = default!;
    public double Price { get; set; }

    //Many to Many Relationship
    public ICollection<TestAuthor> Authors { get; set; }= default!;
}
