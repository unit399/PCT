using AutoMapper;
using Moq;
using PCT.Application.PersonalValue.Queries;
using PCT.Domain.PersonalValue.Dtos;
using PCT.Domain.PersonalValue.RepositoryContracts;

namespace PCT.Application.UnitTest.PersonalValue;

public class GetAllPersonalValueHandlerTests
{
    private readonly GetAllPersonalValueHandler _getAllPersonalValueHandler;
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IPersonalValueRepository> _personalValueRepositoryMock;

    public GetAllPersonalValueHandlerTests()
    {
        _personalValueRepositoryMock = new Mock<IPersonalValueRepository>(MockBehavior.Strict);
        _mapperMock = new Mock<IMapper>(MockBehavior.Strict);
        _getAllPersonalValueHandler =
            new GetAllPersonalValueHandler(_personalValueRepositoryMock.Object, _mapperMock.Object);
    }

    [Fact]
    public async Task Handle_ReturnsListOfPersonalValues()
    {
        // Arrange
        var request = new GetAllPersonalValueRequest();
        var cancellationToken = CancellationToken.None;
        var personalValues = new List<Domain.PersonalValue.Entities.PersonalValue>
        {
            new() { Id = Guid.Parse("6CA80708-B814-4853-868F-1C4EA765E37A"), Name = "Value 1", Description = "Desc 1" },
            new() { Id = Guid.Parse("7BA80708-B814-4853-868F-1C4EA765E37A"), Name = "Value 2", Description = "Desc 2" },
            new() { Id = Guid.Parse("8DA80708-B814-4853-868F-1C4EA765E37A"), Name = "Value 3", Description = "Desc 3" }
        };
        var expectedResponse = new List<GetAllPersonalValueResponse>
        {
            new() { Id = Guid.Parse("6CA80708-B814-4853-868F-1C4EA765E37A"), Name = "Value 1", Description = "Desc 1" },
            new() { Id = Guid.Parse("7BA80708-B814-4853-868F-1C4EA765E37A"), Name = "Value 2", Description = "Desc 2" },
            new() { Id = Guid.Parse("8DA80708-B814-4853-868F-1C4EA765E37A"), Name = "Value 3", Description = "Desc 3" }
        };

        _personalValueRepositoryMock.Setup(m => m.GetAll(cancellationToken))
            .ReturnsAsync(personalValues)
            .Verifiable();

        _mapperMock.Setup(m => m.Map<List<GetAllPersonalValueResponse>>(personalValues))
            .Returns(expectedResponse)
            .Verifiable();

        // Act
        var response = await _getAllPersonalValueHandler.Handle(request, cancellationToken);

        // Assert
        _personalValueRepositoryMock.Verify();
        _personalValueRepositoryMock.VerifyNoOtherCalls();

        _mapperMock.Verify();
        _mapperMock.VerifyNoOtherCalls();

        Assert.Equal(expectedResponse, response);
    }
}