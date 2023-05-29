public record AddGenreCommand(GenreRequestModel GenreRequest) : ICommand<GenreRequestModel>;
public record UpdateGenreCommand(GenreRequestModel GenreRequest) : ICommand<GenreRequestModel>;