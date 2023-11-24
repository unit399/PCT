using MediatR;

namespace PCT.Domain.Account.Dtos;

public sealed record GetAllUserRequest : IRequest<List<GetAllUserResponse>>;