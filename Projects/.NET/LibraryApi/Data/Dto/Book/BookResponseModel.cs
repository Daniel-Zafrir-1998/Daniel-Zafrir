public class BookResponseModel
{
    public int ID { get; set; }
    public string Name { get; set; } = null!;
    public int GenreID { get; set; }
    public int AuthorID { get; set; }
}