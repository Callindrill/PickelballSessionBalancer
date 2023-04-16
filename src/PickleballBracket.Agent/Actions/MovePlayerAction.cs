namespace PickleballBracket.Agent.Actions;

public class MovePlayerAction : IAgentAction<MovePlayerActionParameters>
{
    public void Execute(MovePlayerActionParameters parameters)
    {
        parameters.CurrentEnvironment.MovePlayer(
            parameters.PlayerId,
            parameters.TargetMatchId,
            parameters.TargetCourtPosition
        );
    }
}
