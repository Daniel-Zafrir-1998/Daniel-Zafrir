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

    public virtual Author Author { get; set; }
    public virtual Genre Genre { get; set; }
    public virtual ICollection<Patron> Patrons { get; set; }
}