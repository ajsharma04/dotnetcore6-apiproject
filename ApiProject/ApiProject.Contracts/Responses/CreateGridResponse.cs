namespace ApiProject.Contracts.Responses;

public record CreateGridResponse(
    Guid GridId,
    int GridX,
    int GridY,
    string GridLayout
);
