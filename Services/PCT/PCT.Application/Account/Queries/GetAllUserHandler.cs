using AutoMapper;
using MediatR;
using PCT.Domain.Account.Dtos;
using PCT.Domain.Account.RepositoryContracts;

namespace PCT.Application.Account.Queries;

public sealed class GetAllUserHandler : IRequestHandler<GetAllUserRequest, List<GetAllUserResponse>>
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public GetAllUserHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<List<GetAllUserResponse>> Handle(GetAllUserRequest request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAll(cancellationToken);
        return _mapper.Map<List<GetAllUserResponse>>(users);
    }
}