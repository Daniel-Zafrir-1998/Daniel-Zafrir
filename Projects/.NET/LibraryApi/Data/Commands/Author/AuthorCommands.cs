public record AddAuthorCommand(AuthorRequestModel AuthorRequest) : ICommand<AuthorRequestModel>;
public record UpdateAuthorCommand(AuthorRequestModel AuthorRequest) : ICommand<AuthorRequestModel>;