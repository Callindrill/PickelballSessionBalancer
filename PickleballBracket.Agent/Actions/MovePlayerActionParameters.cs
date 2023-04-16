using PickleballBracket.Domain;

namespace PickleballBracket.Agent.Actions;

public class MovePlayerActionParameters : IActionParameters
{
    public PickleballEnvironment CurrentEnvironment { get; set; }
    public int PlayerId { get; set; }
    public int TargetMatchId { get; set; }
    public int TargetCourtPosition { get; set; }

    public MovePlayerActionParameters(PickleballEnvironment currentEnvironment)
    {
        CurrentEnvironment = currentEnvironment;
    }
}
