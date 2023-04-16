namespace PickleballBracket.Domain;

public class Match : BaseEntity<Match>
{
    public Court Court { get; set; }
    public CourtPositions CourtPositions { get; set; }

    public Match(Court court, CourtPositions positions) : base()
    {
        Court = court;
        CourtPositions = positions;
    }

    public Player GetPlayerAtPosition(int courtPosition)
    {
        return courtPosition switch
        {
            1 => CourtPositions.Position1,
            2 => CourtPositions.Position2,
            3 => CourtPositions.Position3,
            4 => CourtPositions.Position4,
            _ => throw new ArgumentOutOfRangeException($"The court position was not between 1 and 4 inclusive."),
        };
    }
}
