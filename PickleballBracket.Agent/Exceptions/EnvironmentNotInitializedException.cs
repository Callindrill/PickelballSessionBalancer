using System.Runtime.Serialization;

namespace PickleballBracket.Agent.Exceptions;

[Serializable]
internal class PickleballEnvironmentNotInitializedException : Exception
{
    public PickleballEnvironmentNotInitializedException() : base("The pickleball environment was not initialized properly.")
    {
    }

    public PickleballEnvironmentNotInitializedException(string? message) : base(message)
    {
    }

    public PickleballEnvironmentNotInitializedException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected PickleballEnvironmentNotInitializedException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}