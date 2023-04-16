namespace PickleballBracket.Domain;

public class Session : BaseEntity<Session>
{
    public int NumberOfCourts { get; set; }
    public List<Player> Players { get; private set; }
    public List<Heat> Heats { get; private set; } = new List<Heat>();
    public int NumberOfHeats => Heats.Count;

    public Session(int numberOfCourts, IEnumerable<Player> players) : base()
    {
        NumberOfCourts = numberOfCourts;
        Players = players.ToList();
    }
}