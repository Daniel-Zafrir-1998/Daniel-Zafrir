#nullable disable

public class PatronBook
{
    public int PatronID { get; set; }
    public int BookID { get; set; }

    public Patron Patron { get; set; }
    public Book Book { get; set; }
}