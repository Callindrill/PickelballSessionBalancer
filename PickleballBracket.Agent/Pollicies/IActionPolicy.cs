using PickleballBracket.Agent.Actions;
using PickleballBracket.Domain;

namespace PickleballBracket.Agent.Pollicies;

public interface IActionPolicy
{
    ActionExecutionChoice ChooseAction(PickleballEnvironment environment, IEnumerable<IAgentAction<IActionParameters>> availableActions);
}
