using Moq;
using PCT.Application.PersonalValue.Commands;
using PCT.Domain.Common.Enums;
using PCT.Domain.Common.RepositoryContracts;
using PCT.Domain.PersonalValue.Dtos;
using PCT.Domain.PersonalValue.RepositoryContracts;

namespace PCT.Application.UnitTest.PersonalValue;

public class AddPersonalValueHandlerTests
{
    private readonly AddPersonalValueHandler _addPersonalValueHandler;
    private readonly Mock<IPersonalValueRepository> _personalValueRepositoryMock;
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;

    public AddPersonalValueHandlerTests()
    {
        _personalValueRepositoryMock = new Mock<IPersonalValueRepository>();
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _addPersonalValueHandler =
            new AddPersonalValueHandler(_personalValueRepositoryMock.Object, _unitOfWorkMock.Object);
    }

    [Fact]
    public async Task Handle_WithNewPersonalValue_ReturnsSuccessResponse()
    {
        // Arrange
        var request = new AddPersonalValueRequest("Value 1", "Description 1");

        var cancellationToken = CancellationToken.None;

        _personalValueRepositoryMock.Setup(m => m.Exist(request.Name))
            .ReturnsAsync(false)
            .Verifiable();

        // Act
        var response = await _addPersonalValueHandler.Handle(request, cancellationToken);

        // Assert
        _personalValueRepositoryMock.Verify();

        Assert.Equal(StatusCodeType.Success, response.StatusCode.Type);
        Assert.Equal("Personal Value added successfully", response.StatusCode.Message);
    }

    [Fact]
    public async Task Handle_WithExistingPersonalValue_ReturnsErrorResponse()
    {
        // Arrange
        var request = new AddPersonalValueRequest("Value 1", "Description 1");

        var cancellationToken = CancellationToken.None;

        _personalValueRepositoryMock.Setup(m => m.Exist(request.Name))
            .ReturnsAsync(true)
            .Verifiable();

        // Act
        var response = await _addPersonalValueHandler.Handle(request, cancellationToken);

        // Assert
        _personalValueRepositoryMock.Verify();

        Assert.Equal(StatusCodeType.Error, response.StatusCode.Type);
        Assert.Equal("Personal Value Already Exist", response.StatusCode.Message);
    }
}