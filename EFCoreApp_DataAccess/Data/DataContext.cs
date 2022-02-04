using EFCoreApp_DataAccess.Data.FluentConfig;
using EFCoreApp_DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
namespace EFCoreApp_DataAccess.Data;
public class DataContext: DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Genre> Genres{ get; set; } = default!;
    public DbSet<Book> Books{ get; set; } = default!;
    public DbSet<BookDetail> BookDetails{ get; set; } = default!;
    public DbSet<Author> Authors{ get; set; } = default!;
    public DbSet<Publisher> Publishers{ get; set; } = default!;
    public DbSet<BookAuthor> BookAuthors { get; set; } = default!;
    public DbSet<Fluent_BookDetail> Fluent_BookDetails { get; set; } = default!;
    public DbSet<Fluent_Book> Fluent_Books { get; set; } = default!;
    public DbSet<Fluent_Author> Fluent_Authors { get; set; } = default!;
    public DbSet<Fluent_BookAuthor> Fluent_BookAuthor { get; set; } = default!;
    public DbSet<Fluent_Publisher> Fluent_Publishers { get; set; } = default!;

    public DbSet<TestAuthor> TestAuthors { get; set; } = default!;
    public DbSet<TestBook> TestBooks { get; set; } = default!;

    public DbSet<Category> Categories { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder){
        //Fluent API Composite Key
        modelBuilder.Entity<BookAuthor>()
            .HasKey(x => new{x.AuthorId, x.BookId});
        //modelBuilder.Entity<Fluent_BookDetail>()
        
        modelBuilder.Entity<Fluent_Author>()
            .Ignore(x => x.FullName);
            
        modelBuilder.ApplyConfiguration(new FluentBookConfig());
            
        //Many to many relationship
        modelBuilder.Entity<Fluent_BookAuthor>()
            .HasKey( x => new { x.BookId,x.AuthorId });
        modelBuilder.Entity<Fluent_BookAuthor>()
            .HasOne<Fluent_Book>(x => x.Book)
            .WithMany(x => x.Authors)
            .HasForeignKey(x => x.BookId);

        modelBuilder.Entity<Fluent_BookAuthor>()
            .HasOne<Fluent_Author>(x => x.Author)
            .WithMany(x => x.Books)
            .HasForeignKey(x => x.AuthorId);
        //shadow property
        modelBuilder.Entity<TestBook>()
            .Property<DateTime>("CreatedDate");
        modelBuilder.Entity<TestBook>()
            .Property<DateTime>("UpdatedDate");
        // modelBuilder.Entity<TestBook>()
        //     .Property<DateTime>("CreatedDate")
        //     .HasDefaultValue(DateTime.UtcNow);
            
    }

    
}
