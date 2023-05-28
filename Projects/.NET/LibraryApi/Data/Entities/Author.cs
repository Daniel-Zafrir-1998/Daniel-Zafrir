#nullable disable
public class Author
{
    public Author()
    {
        Books = new HashSet<Book>();
    }
    public int ID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public virtual ICollection<Book> Books { get; set; }
}