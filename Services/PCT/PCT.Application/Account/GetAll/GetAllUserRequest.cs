using MediatR;
using PCT.Application.Common.Contracts;

namespace PCT.Application.Account.GetAll;

public sealed record GetAllUserRequest() : IRequest<List<GetAllUserResponse>>;