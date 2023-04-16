namespace PickleballBracket.Domain;

public class PickleballEnvironment
{
    public Session Session { get; }

    public PickleballEnvironment(Session session)
    {
        Session = session;
    }

    public void MovePlayer(int playerId, int targetMatchId, int targetCourtPosition)
    {
        // Find the heat that the match is in -- we won't be moving the player between heats ever.
        var heat = Session.Heats.FirstOrDefault(h => h.Matches.Any(m => m.Id == targetMatchId)) ??
            throw new ArgumentException("The target match could not be found within a heat.");

        Match targetMatch = heat.Matches.Single(m => m.Id == targetMatchId);
        
        Player? playerToMove = null;
        Match? sourceMatch = null;
        if (heat.PlayersWithByes.Any(p => p.Id == playerId))
        {
            // the player currently has a Bye, so we need to take them out of the byes and put the displaced player in.
            playerToMove = heat.PlayersWithByes.First(p => p.Id == playerId);
            heat.PlayersWithByes.Remove(playerToMove);

            var displacedPlayer = targetMatch.GetPlayerAtPosition(targetCourtPosition);
            heat.PlayersWithByes.Add(displacedPlayer);

            // Get the new court positinos and assign them back to the match.
            targetMatch.CourtPositions = targetMatch.CourtPositions.CopyWithReplacementPlayer(playerToMove, targetCourtPosition);
        }
        else
        {
            // the player should currently be in a match. We'll need to find that. If it's null, or they're in two or more matches, we have a problem somewhere.
            sourceMatch = heat.GetMatchWithPlayer(playerId);
            var currentPlayerPosition = sourceMatch.CourtPositions.GetPlayerPosition(playerId)!.Value;

            if (sourceMatch == targetMatch)
            {
                // the player is already in the match we're moving them to, so they should just be moving to a new position.
                targetMatch.CourtPositions.SwapPlayers(targetCourtPosition, currentPlayerPosition);
            }
            else
            {
                // we need to get new court positions for the source and target match to ensure we're still valid when we're done swapping.
                var displacedPlayer = targetMatch.GetPlayerAtPosition(targetCourtPosition);
                playerToMove = sourceMatch.GetPlayerAtPosition(currentPlayerPosition);

                var targetCourtPositions = targetMatch.CourtPositions.CopyWithReplacementPlayer(playerToMove, targetCourtPosition);
                var sourceCourtPositions = sourceMatch.CourtPositions.CopyWithReplacementPlayer(displacedPlayer, currentPlayerPosition);

                targetMatch.CourtPositions = targetCourtPositions;
                sourceMatch.CourtPositions = sourceCourtPositions;

            }
        }
    }
}
