using MediatR;
using PCT.Application.Account.Register;
using PCT.Application.Repositories;
using PCT.Domain.Common.Entity;
using PCT.Domain.Common.Enum;

namespace PCT.Application.PersonalValue.Add;

public class AddPersonalValueHandler : IRequestHandler<AddPersonalValueRequest, AddPersonalValueResponse>
{
    private readonly IPersonalValueRepository _personalValueRepository;

    public AddPersonalValueHandler(IPersonalValueRepository personalValueRepository)
    {
        _personalValueRepository = personalValueRepository;
    }
    
    public async Task<AddPersonalValueResponse> Handle(AddPersonalValueRequest request, CancellationToken cancellationToken)
    {
        var userExist = await _personalValueRepository.Exist(request.Name);
        if (userExist)
            return new AddPersonalValueResponse
            {
                StatusCode = new StatusCode { Type = StatusCodeType.Error, Message = "Personal Value Already Exist" } 
            };

        var personalValue = new Domain.PersonalValue.PersonalValue(request.Name, request.Description);
        
        _personalValueRepository.Add(personalValue);
        
        return new AddPersonalValueResponse
        {
            StatusCode = new StatusCode
            {
                Type = StatusCodeType.Success, Message = "Personal Value added successfully"
            }
        };
    }
}