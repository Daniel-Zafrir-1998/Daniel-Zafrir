public record GetAllBooksQuery() : IQuery<List<BookResponseModel>>;
public record GetBookQuery(int BookID) : IQuery<BookResponseModel>;