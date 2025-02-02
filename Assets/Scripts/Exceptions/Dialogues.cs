using System;

public class NoDialogueFlowException : Exception
{
    public NoDialogueFlowException() : base("No dialogue flow found.") {}
    public NoDialogueFlowException(string message) : base(message) {}
    public NoDialogueFlowException(string message, Exception inner) : base(message, inner) {}
}
