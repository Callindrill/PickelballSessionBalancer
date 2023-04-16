using PickleballBracket.Agent.Actions;

namespace PickleballBracket.Agent.Pollicies;

public class ActionExecutionChoice
{
    public IAgentAction<IActionParameters> Action { get; }
    public IActionParameters Parameters { get; }

    public ActionExecutionChoice(IAgentAction<IActionParameters> action, IActionParameters parameters)
    {
        Action = action;
        Parameters = parameters;
    }
}
