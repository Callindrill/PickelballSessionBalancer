using PickleballBracket.Domain;

namespace PickleballBracket.Agent.Actions;

public interface IActionParameters
{
    PickleballEnvironment CurrentEnvironment { get; }
}
