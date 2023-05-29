public record AddPatronCommand(PatronRequestModel PatronRequest) : ICommand<PatronRequestModel>;
public record UpdatePatronCommand(PatronRequestModel PatronRequest) : ICommand<PatronRequestModel>;