namespace PickleballBracket.Domain;

public class Heat : BaseEntity<Heat>
{
    public List<Match> Matches { get; private set; } = new List<Match>();
    public List<Player> PlayersWithByes { get; private set; } = new List<Player>();
    public Heat() : base()
    {
    }

    /// <summary>
    /// Return's the Match that in which a player is currently playing; this method throws an exception is the player isn't in any match, or is somehow assigned to more than one match. 
    /// </summary>
    /// <param name="playerId">The id for the player.</param>
    /// <returns>The single match in which the player is currently playing.</returns>
    /// <exception cref="ArgumentException" />
    public Match GetMatchWithPlayer(int playerId)
    {
        try
        {
            return Matches.SingleOrDefault(m => m.CourtPositions.GetPlayerPosition(playerId) != null)
                ?? throw new ArgumentException("The player couldn't be found in any match.");
        }
        catch (InvalidOperationException ex)
        {
            throw new ArgumentException("The player is currently assigned to multiple matches. Unable to proceed.", ex);
        }
    }
}
