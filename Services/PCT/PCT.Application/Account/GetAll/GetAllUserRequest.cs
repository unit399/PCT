using MediatR;

namespace PCT.Application.Account.GetAll;

public sealed record GetAllUserRequest : IRequest<List<GetAllUserResponse>>;