namespace PickleballBracket.Domain;

public class Player : BaseEntity<Player>
{
    public string Name { get; set; }

    public Player(string name) : base()
    {
        Name = name;
    }
}