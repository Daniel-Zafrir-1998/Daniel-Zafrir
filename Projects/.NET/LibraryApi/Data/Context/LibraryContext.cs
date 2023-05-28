using Microsoft.EntityFrameworkCore;
#nullable disable
public class LibraryContext : DbContext
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Patron> Patrons { get; set; }
    public DbSet<PatronBook> PatronBooks { get; set; }

    public LibraryContext(DbContextOptions<LibraryContext> options) :
    base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.ID);
            entity.Property(e => e.Description).HasMaxLength(250);
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.ID);

            entity
            .HasOne(e => e.Author)
            .WithMany(e => e.Books)
            .HasForeignKey(e => e.AuthorID);

            entity
            .HasOne(e => e.Genre)
            .WithMany(e => e.Books)
            .HasForeignKey(e => e.GenreID);

            entity
            .HasMany(e => e.Patrons)
            .WithMany(e => e.Books)
            .UsingEntity<PatronBook>();
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.ID);
        });

        modelBuilder.Entity<Patron>(entity =>
        {
            entity.HasKey(e => e.ID);

            entity
            .HasMany(e => e.Books)
            .WithMany(e => e.Patrons)
            .UsingEntity<PatronBook>();

        });
    }

}