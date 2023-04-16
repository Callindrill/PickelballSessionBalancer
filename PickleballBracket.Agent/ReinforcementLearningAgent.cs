using PickleballBracket.Agent.Actions;
using PickleballBracket.Agent.Exceptions;
using PickleballBracket.Agent.Initialization;
using PickleballBracket.Agent.Pollicies;
using PickleballBracket.Domain;

namespace PickleballBracket.Agent;

public class ReinforcementLearningAgent
{
    private readonly IEnvironmentInitializer _optimizationInitializer;
    private readonly IEnumerable<IAgentAction<IActionParameters>> _actions;
    private readonly IActionPolicy _actionPolicy;
    private PickleballEnvironment? _currentState;

    public ReinforcementLearningAgent(IEnvironmentInitializer optimizationInitializer, IEnumerable<IAgentAction<IActionParameters>> actions, IActionPolicy actionPolicy)
    {
        _optimizationInitializer = optimizationInitializer;
        _actions = actions;
        _actionPolicy = actionPolicy;
    }

    public void InitializeEnvironment(IList<Player> players, int numberOfCourts, int numberOfHeats)
    {
        _currentState = _optimizationInitializer.InitializeEnvironment(players, numberOfCourts, numberOfHeats);
    }

    public PickleballEnvironment TakeAction()
    {
        //Ensure that the environment has been initialized before taking actions
        if (_currentState == null)
        {
            throw new PickleballEnvironmentNotInitializedException();
        }

        // Choose the action and its parameters based on the current environment.
        ActionExecutionChoice executionChoice = _actionPolicy.ChooseAction(_currentState, _actions);

        // Execute the chosen action with its corresponding parameters.
        executionChoice.Action.Execute(executionChoice.Parameters);

        return _currentState;
    }
}