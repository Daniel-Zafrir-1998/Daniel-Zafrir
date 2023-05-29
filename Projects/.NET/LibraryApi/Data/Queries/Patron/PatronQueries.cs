public record GetAllPatronsQuery() : IQuery<List<PatronResponseModel>>;
public record GetPatronQuery(int PatronID) : IQuery<PatronResponseModel>;