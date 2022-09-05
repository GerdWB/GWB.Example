namespace Application.Results.Tests;

using FluentAssertions;
using GWB.Example.Application.Core.Results;

public class QueryResultTests
{
    [Fact]
    public void QueryCommandFailed_Should_Contain_Error_Object()
    {
        // Arrange
        var error = new Error("Test Error");

        // Act
        var queryFailed = new QueryFailed<int>(error);

        // Assert
        queryFailed.Error.Should().NotBeNull();
        queryFailed.Error.Should().Be(error);
    }

    [Fact]
    public void QueryCommandFailed_Should_Return_False_For_Success_And_True_For_Failure()
    {
        // Arrange

        // Act
        var querySuccess = new QuerySuccess<int>(5);

        // Assert
        querySuccess.IsSuccess.Should().BeTrue();
        querySuccess.IsFailure.Should().BeFalse();
    }

    [Fact]
    public void QuerySuccess_Implicit_Conversion_Should_Work_For_Integer()
    {
        // Arrange
        var value = 42;

        // Act
        QuerySuccess<int> querySuccess = value;

        // Assert
        querySuccess.Value.Should().Be(value);
    }


    [Fact]
    public void QuerySuccess_Implicit_Conversion_Should_Work_For_ReferenceTypes()
    {
        // Arrange
        var value = new DateTime();

        // Act
        var querySuccess = (QuerySuccess<DateTime>)value;

        // Assert
        querySuccess.Value.Should().Be(value);
    }

    [Fact]
    public void QuerySuccess_Implicit_Conversion_Should_Work_For_String()
    {
        // Arrange
        var value = "42";

        // Act
        var querySuccess = (QuerySuccess<string>)value;

        // Assert
        querySuccess.Value.Should().Be(value);
    }


    [Fact]
    public void QuerySuccess_Should_Contain_Correct_Value()
    {
        // Arrange
        var value = 42;

        // Act
        var querySuccess = new QuerySuccess<int>(value);

        // Assert
        querySuccess.Value.Should().Be(value);
    }

    [Fact]
    public void QuerySuccess_Should_Return_True_For_Success_And_False_For_Failure()
    {
        // Arrange
        var error = new Error("Test Error");

        // Act
        var queryFailed = new QueryFailed<int>(error);

        // Assert
        queryFailed.IsFailure.Should().BeTrue();
        queryFailed.IsSuccess.Should().BeFalse();
    }
}