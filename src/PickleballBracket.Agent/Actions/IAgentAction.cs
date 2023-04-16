namespace PickleballBracket.Agent.Actions;

public interface IAgentAction<TActionParameters> where TActionParameters : IActionParameters
{
    void Execute(TActionParameters environment);
}
