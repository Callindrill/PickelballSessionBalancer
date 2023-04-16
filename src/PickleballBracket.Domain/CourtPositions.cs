namespace PickleballBracket.Domain;

public class CourtPositions
{
    private Player[] _positions;
    public Player Position1 => _positions[0];
    public Player Position2 => _positions[1];
    public Player Position3 => _positions[2];
    public Player Position4 => _positions[3];

    public CourtPositions(Player position1, Player position2, Player position3, Player position4)
    {
        _positions = new[] { position1, position2, position3, position4 };
    }

    public CourtPositions CopyWithReplacementPlayer(Player player, int playerPosition)
    {
        Player[] players = new Player[4];
        Array.Copy(_positions, players, 4);
        playerPosition--;
        players[playerPosition] = player;
        return new CourtPositions(
            players[0],
            players[1],
            players[2],
            players[3]
            );
    }

    public void SwapPlayers(int position1, int position2)
    {
        if (position1 < 1 || position1 > 4 || position2 < 1 || position2 > 4)
        {
            throw new ArgumentException("Position numbers must be between 1 and 4.");
        }

        // Adjust the position numbers to be zero-based for the array
        position1--;
        position2--;

        // Swap the players
        Player temp = _positions[position1];
        _positions[position1] = _positions[position2];
        _positions[position2] = temp;
    }

    public int? GetPlayerPosition(int playerId)
    {
        if (Position1.Id == playerId) return 1;
        if (Position2.Id == playerId) return 2;
        if (Position3.Id == playerId) return 3;
        if (Position4.Id == playerId) return 4;
        return null;
    }
}