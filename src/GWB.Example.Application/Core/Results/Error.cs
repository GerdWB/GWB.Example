namespace GWB.Example.Application.Core.Results;

using System.Runtime.CompilerServices;

public class Error
{
    public Error(string message,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string sourceFilePath = "",
        [CallerLineNumber] int sourceLineNumber = 0)
    {
        Message = message;
        MemberName = memberName;
        SourceFilePath = sourceFilePath;
        SourceLineNumber = sourceLineNumber;
    }

    public Error(Exception exception,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string sourceFilePath = "",
        [CallerLineNumber] int sourceLineNumber = 0)
    {
        Exception = exception;
        MemberName = memberName;
        SourceFilePath = sourceFilePath;
        SourceLineNumber = sourceLineNumber;
        Message = exception.Message;
    }

    public string Message { get; }

    public Exception? Exception { get; }
    public string MemberName { get; }
    public string SourceFilePath { get; }
    public int SourceLineNumber { get; }
}