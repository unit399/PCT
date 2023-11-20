using AutoMapper;
using MediatR;
using PCT.Application.Repositories;
using PCT.Domain.Account;

namespace PCT.Application.Account.Register;

public sealed class RegisterUserHandler : IRequestHandler<RegisterUserRequest, RegisterUserResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    
    public RegisterUserHandler(IUnitOfWork unitOfWork, IUserRepository userRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
        _mapper = mapper;
    }
    
    public async Task<RegisterUserResponse> Handle(RegisterUserRequest userRequest, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<User>(userRequest);
        _userRepository.Create(user);
        await _unitOfWork.Save(cancellationToken);

        return _mapper.Map<RegisterUserResponse>(user);
    }
}