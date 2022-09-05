namespace Application.Results.Tests;

using FluentAssertions;
using GWB.Example.Application.Core.Results;

public class CommandResultTests
{
    [Fact]
    public void CommandCommandFailed_Should_Contain_Error_Object()
    {
        // Arrange
        var error = new Error("Test Error");

        // Act
        var commandFailed = new CommandFailed(error);

        // Assert
        commandFailed.Error.Should().NotBeNull();
        commandFailed.Error.Should().Be(error);
    }

    [Fact]
    public void CommandCommandFailed_Should_Return_False_For_Success_And_True_For_Failure()
    {
        // Arrange

        // Act
        var commandFailed = new CommandFailed(new Error("Test Error"));

        // Assert
        commandFailed.IsFailure.Should().BeTrue();
        commandFailed.IsSuccess.Should().BeFalse();
    }

    [Fact]
    public void CommandSucceeded_Should_Return_True_For_Success_And_False_For_Failure()
    {
        // Arrange

        // Act
        var commandSuccessResult = new CommandSucceeded();

        // Assert
        commandSuccessResult.IsSuccess.Should().BeTrue();
        commandSuccessResult.IsFailure.Should().BeFalse();
    }
}