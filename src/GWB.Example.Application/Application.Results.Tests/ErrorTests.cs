namespace Application.Results.Tests;

using System.Runtime.CompilerServices;
using FluentAssertions;
using GWB.Example.Application.Core.Results;

public class ErrorTests
{
    private static int GetCurrentSourceFileLineNumber([CallerLineNumber] int sourceLineNumber = 0) => sourceLineNumber;

    private static string GetThisFilePath([CallerFilePath] string path = null) => path;

    private static string GetThisMemberName([CallerMemberName] string memberName = null) => memberName;


    [Fact]
    public void Error_With_Exception_Should_Contain_CallerMemberName_CallerFilePath_And_CallerLineNumber()
    {
        // Arrange
        var exception = new ArgumentException("ArgumentException");

        // Act
        var lineNumber = GetCurrentSourceFileLineNumber(); // Do not separate this two lines
        var error = new Error(exception);

        // Assert
        error.MemberName.Should().Be(GetThisMemberName());
        error.SourceFilePath.Should().Be(GetThisFilePath());
        error.SourceLineNumber.Should().Be(lineNumber + 1);
        error.Exception.Should().BeSameAs(exception);
    }

    [Fact]
    public void Error_With_Exception_Should_Contain_Message_From_Exception()
    {
        // Arrange
        var exception = new ArgumentException("ArgumentException");

        // Act
        var error = new Error(exception);

        // Assert
        error.Exception.Should().NotBeNull();
        error.Exception.Should().BeSameAs(exception);
        error.Message.Should().NotBeNull();
        error.Message.Should().BeSameAs(exception.Message);
    }


    [Fact]
    public void Error_With_Message_Should_Contain_CallerMemberName_CallerFilePath_And_CallerLineNumber()
    {
        // Arrange
        var message = "The error message for this test!";

        // Act
        var lineNumber = GetCurrentSourceFileLineNumber(); // Do not separate this two lines
        var error = new Error(message);

        // Assert
        error.MemberName.Should().Be(GetThisMemberName());
        error.SourceFilePath.Should().Be(GetThisFilePath());
        error.SourceLineNumber.Should().Be(lineNumber + 1);
    }

    [Fact]
    public void Error_With_Message_Should_Contain_The_Correct_Message()
    {
        // Arrange
        var message = "The error message for this test!";

        // Act
        var error = new Error(message);

        // Assert
        error.Message.Should().BeSameAs(message);
    }
}