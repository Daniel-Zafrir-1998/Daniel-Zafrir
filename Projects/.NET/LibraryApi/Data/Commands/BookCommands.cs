using MediatR;

public record AddBookCommand(BookRequestModel BookRequest) : ICommand<BookRequestModel>;