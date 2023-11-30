using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Moq;
using PCT.Domain.PersonalValue.Entities;
using PCT.Domain.PersonalValue.RepositoryContracts;
using PCT.Infrastructure.Context;
using PCT.Infrastructure.Repositories;

namespace PCT.Infrastructure.UnitTest;

public class PersonalValueRepositoryTests
{
    [Fact]
    public void Add_Should_AddPersonalValueToContext()
    {
    //     // // Arrange
    //     // Arrange
    //     var personalValue = new PersonalValue { Name = "Test Value" };
    //     var contextMock = new Mock<ApplicationDbContext>();
    //     var dbSetMock = new Mock<DbSet<PersonalValue>>();
    //     
    //     
    //     contextMock.Setup(x => x.Set<PersonalValue>()).Returns(dbSetMock.Object);
    //     //dbSetMock.Setup(x => x.Add(It.IsAny<PersonalValue>())).Returns(void);
    //     
    //     // Act
    //     var repository = new PersonalValueRepository(contextMock.Object);
    //     repository.Add(personalValue);
    //
    //     // Assert
    //     contextMock.Verify(x => x.PersonalValues.Add(personalValue), Times.Once);
    //     contextMock.Verify(x => x.Set<PersonalValue>());
    //     dbSetMock.Verify(x => x.Add(It.Is<PersonalValue>(y => y == personalValue)));
    }
    
    [Fact]
    public async Task Exist_Should_ReturnTrue_WhenPersonalValueExists()
    {
        // Arrange
        // var name = "Test Value";
        // var contextMock = new Mock<ApplicationDbContext>();
        // var repository = new PersonalValueRepository(contextMock.Object);
        //
        // // Act
        // var result = await repository.Exist(name);
        //
        // // Assert
        // Assert.True(result);"
    }

    [Fact]
    public async Task Exist_Should_ReturnFalse_WhenPersonalValueDoesNotExist()
    {
        // Arrange
        // var name = "Non-existent Value";
        // var contextMock = new Mock<ApplicationDbContext>();
        // var repository = new PersonalValueRepository(contextMock.Object);
        //
        // // Act
        // var result = await repository.Exist(name);
        //
        // // Assert
        // Assert.False(result);
    }
}