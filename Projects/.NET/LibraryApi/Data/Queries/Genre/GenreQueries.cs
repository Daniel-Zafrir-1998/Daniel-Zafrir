public record GetAllGenresQuery() : IQuery<List<GenreResponseModel>>;
public record GetGenreQuery(int GenreID) : IQuery<GenreResponseModel>;