#nullable disable
public class Book
{
    public Book()
    {
        Patrons = new HashSet<Patron>();
    }

    public int ID { get; set; }
    public string Name { get; set; }
    public int GenreID { get; set; }
    public int AuthorID { get; set; }

    public Author Author { get; set; }
    public Genre Genre { get; set; }
    public ICollection<Patron> Patrons { get; set; }
}