public record AddBookCommand(BookRequestModel BookRequest) : ICommand<BookRequestModel>;
public record UpdateBookCommand(BookRequestModel BookRequest) : ICommand<BookRequestModel>;