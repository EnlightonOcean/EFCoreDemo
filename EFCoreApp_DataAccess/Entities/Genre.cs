namespace EFCoreApp_DataAccess.Entities;
public class Genre
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;  
    public int DisplayOrder { get; set; }
}