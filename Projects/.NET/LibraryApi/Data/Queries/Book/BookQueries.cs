using MediatR;

public record GetAllBooksQuery() : IQuery<List<Book>>;