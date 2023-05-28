#nullable disable

public class Patron
{
    public Patron()
    {
        Books = new HashSet<Book>();
    }
    public int ID { get; set; }
    public string PhoneNumber { get; set; }
    public virtual ICollection<Book> Books { get; set; }

}