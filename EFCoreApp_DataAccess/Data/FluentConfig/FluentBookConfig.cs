using EFCoreApp_DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCoreApp_DataAccess.Data.FluentConfig;
public class FluentBookConfig : IEntityTypeConfiguration<Fluent_Book>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Fluent_Book> builder)
    {
       builder
            .Property(x => x.ISBN)
            .HasMaxLength(15);
        //One to one relatiionship    
        builder
            .HasOne<Fluent_BookDetail>(x => x.BookDetail)
            .WithOne(x => x.FluentBook)
            .HasForeignKey<Fluent_Book>(x => x.BookDetailId);
        //One to many relationship
        builder
            .HasOne<Fluent_Publisher>(x => x.Publisher)
            .WithMany(s => s.FluentBooks);
        
    }
}
