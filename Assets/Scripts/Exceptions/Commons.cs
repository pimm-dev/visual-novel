using System;

public class DeprecatedApiException : Exception
{
    public DeprecatedApiException() : base("This API is deprecated. Please use the latest version.") {}
    public DeprecatedApiException(string message) : base(message) {}
    public DeprecatedApiException(string message, Exception inner) : base(message, inner) {}
}
