#nullable disable
public class Genre
{
    public Genre()
    {
        Books = new HashSet<Book>();
    }
    public int ID { get; set; }
    public string Name { get; set; }
    public virtual ICollection<Book> Books { get; set; }
}