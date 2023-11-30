using AutoMapper;
using MediatR;
using PCT.Domain.PersonalValue.Dtos;
using PCT.Domain.PersonalValue.RepositoryContracts;

namespace PCT.Application.PersonalValue.Queries;

public class GetAllPersonalValueHandler : IRequestHandler<GetAllPersonalValueRequest, List<GetAllPersonalValueResponse>>
{
    private readonly IMapper _mapper;
    private readonly IPersonalValueRepository _personalValueRepository;

    public GetAllPersonalValueHandler(IPersonalValueRepository personalValueRepository, IMapper mapper)
    {
        _personalValueRepository = personalValueRepository;
        _mapper = mapper;
    }

    public async Task<List<GetAllPersonalValueResponse>> Handle(GetAllPersonalValueRequest request,
        CancellationToken cancellationToken)
    {
        var personalValues = await _personalValueRepository.GetAll(cancellationToken);
        return _mapper.Map<List<GetAllPersonalValueResponse>>(personalValues);
    }
}