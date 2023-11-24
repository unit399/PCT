using MediatR;

namespace PCT.Application.PersonalValue.Add;

public sealed record AddPersonalValueRequest(string Name, string Description) : IRequest<AddPersonalValueResponse>;