using PickleballBracket.Domain;

namespace PickleballBracket.Agent.Initialization;

public interface IEnvironmentInitializer
{
    PickleballEnvironment InitializeEnvironment(IList<Player> players, int numberOfCourts, int numberOfHeats);
}
