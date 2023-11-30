using MediatR;

namespace PCT.Domain.PersonalValue.Dtos;

public sealed record GetAllPersonalValueRequest : IRequest<List<GetAllPersonalValueResponse>>;