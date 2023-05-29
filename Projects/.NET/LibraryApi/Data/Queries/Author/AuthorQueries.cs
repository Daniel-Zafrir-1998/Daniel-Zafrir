public record GetAllAuthorsQuery() : IQuery<List<AuthorResponseModel>>;
public record GetAuthorQuery(int AuthorID) : IQuery<AuthorResponseModel>;