using MediatR;
using PCT.Domain.Common.Entities;
using PCT.Domain.Common.Enums;
using PCT.Domain.Common.RepositoryContracts;
using PCT.Domain.PersonalValue.Dtos;
using PCT.Domain.PersonalValue.RepositoryContracts;

namespace PCT.Application.PersonalValue.Commands;

public class AddPersonalValueHandler : IRequestHandler<AddPersonalValueRequest, AddPersonalValueResponse>
{
    private readonly IPersonalValueRepository _personalValueRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AddPersonalValueHandler(IPersonalValueRepository personalValueRepository, IUnitOfWork unitOfWork)
    {
        _personalValueRepository = personalValueRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<AddPersonalValueResponse> Handle(AddPersonalValueRequest request,
        CancellationToken cancellationToken)
    {
        var exist = await _personalValueRepository.Exist(request.Name);
        if (exist)
            return new AddPersonalValueResponse
            {
                StatusCode = new StatusCode { Type = StatusCodeType.Error, Message = "Personal Value Already Exist" }
            };

        var personalValue = new Domain.PersonalValue.Entities.PersonalValue
        {
            Name = request.Name,
            Description = request.Description
        };

        _personalValueRepository.Add(personalValue);
        await _unitOfWork.Save(cancellationToken);

        return new AddPersonalValueResponse
        {
            StatusCode = new StatusCode
            {
                Type = StatusCodeType.Success, Message = "Personal Value added successfully"
            }
        };
    }
}