using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PCT.Domain.PersonalValue.Dtos;
using PCT.Domain.PersonalValue.RepositoryContracts;
using PCT.WebAPI.Controllers.PersonalValue;

namespace PCT.WebAPI.UnitTest;

public class PersonalValueControllerTests
{
    private readonly Mock<IMediator> _mediatorMock;
    private readonly PersonalValueController _personalValueController;
    private readonly Mock<IPersonalValueRepository> _personalValueRepositoryMock;

    public PersonalValueControllerTests()
    {
        _mediatorMock = new Mock<IMediator>();
        _personalValueRepositoryMock = new Mock<IPersonalValueRepository>();
        _personalValueController =
            new PersonalValueController(_mediatorMock.Object, _personalValueRepositoryMock.Object);
    }

    [Fact]
    public async Task Add_ValidRequestAndAuthorizedUser_ReturnsOkResult()
    {
        // Arrange
        var addPersonalValueRequest = new AddPersonalValueRequest("PersonalValue", "Description");
        var cancellationToken = CancellationToken.None;
        var expectedResponse = new AddPersonalValueResponse();
        _mediatorMock.Setup(m => m.Send(addPersonalValueRequest, cancellationToken))
            .ReturnsAsync(expectedResponse);

        // Act
        var result = await _personalValueController.Add(addPersonalValueRequest, cancellationToken);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        Assert.Same(expectedResponse, okResult.Value);
    }

    [Fact]
    public async Task GetAll_AuthorizedUser_ReturnsOkResult()
    {
        // Arrange
        var cancellationToken = CancellationToken.None;
        var expectedResponse = new List<GetAllPersonalValueResponse>();
        _mediatorMock.Setup(m => m.Send(It.IsAny<GetAllPersonalValueRequest>(), cancellationToken))
            .ReturnsAsync(expectedResponse);

        // Act
        var result = await _personalValueController.GetAll(cancellationToken);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        Assert.Same(expectedResponse, okResult.Value);
    }
}