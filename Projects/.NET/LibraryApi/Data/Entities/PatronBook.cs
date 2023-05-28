#nullable disable

public class PatronBook
{
    public int PatronID { get; set; }
    public int BookID { get; set; }

    public virtual Patron Patron { get; set; }
    public virtual Book Book { get; set; }
}