using AutoMapper;
using Moq;
using PCT.Application.Account.Queries;
using PCT.Domain.Account.Dtos;
using PCT.Domain.Account.Entities;
using PCT.Domain.Account.RepositoryContracts;

namespace PCT.Application.UnitTest.Account;

public class GetAllUserHandlerTests
{
    private readonly GetAllUserHandler _getAllUserHandler;
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IUserRepository> _userRepositoryMock;

    public GetAllUserHandlerTests()
    {
        _userRepositoryMock = new Mock<IUserRepository>(MockBehavior.Strict);
        _mapperMock = new Mock<IMapper>(MockBehavior.Strict);
        _getAllUserHandler = new GetAllUserHandler(_userRepositoryMock.Object, _mapperMock.Object);
    }

    [Fact]
    public async Task Handle_ReturnsListOfUsers()
    {
        // Arrange
        var request = new GetAllUserRequest();
        var cancellationToken = CancellationToken.None;
        var users = new List<User>
        {
            new() { Id = "6CA80708-B814-4853-868F-1C4EA765E37A", Email = "okan1@okan.com" },
            new() { Id = "F30B8C33-F680-4E09-BC56-A9490826F3EA", Email = "okan2@okan.com" },
            new() { Id = "C203E5B9-9144-48F7-8EE0-3CFF71215F8D", Email = "okan3@okan.com" }
        };
        var expectedResponse = new List<GetAllUserResponse>
        {
            new() { Id = Guid.Parse("6CA80708-B814-4853-868F-1C4EA765E37A"), Email = "okan1@okan.com" },
            new() { Id = Guid.Parse("F30B8C33-F680-4E09-BC56-A9490826F3EA"), Email = "okan2@okan.com" },
            new() { Id = Guid.Parse("C203E5B9-9144-48F7-8EE0-3CFF71215F8D"), Email = "okan3@okan.com" }
        };

        _userRepositoryMock.Setup(m => m.GetAll(cancellationToken))
            .ReturnsAsync(users)
            .Verifiable();

        _mapperMock.Setup(m => m.Map<List<GetAllUserResponse>>(users))
            .Returns(expectedResponse)
            .Verifiable();

        // Act
        var response = await _getAllUserHandler.Handle(request, cancellationToken);

        // Assert
        _userRepositoryMock.Verify();
        _userRepositoryMock.VerifyNoOtherCalls();

        _mapperMock.Verify();
        _mapperMock.VerifyNoOtherCalls();

        Assert.Equal(expectedResponse, response);
    }
}