namespace PickleballBracket.Domain;

public abstract class BaseEntity<T> : IEquatable<BaseEntity<T>>
{
    public int Id { get; protected set; }

    protected BaseEntity()
    {
        Id = AutoIncrementId<T>.NextId();
    }

    public bool Equals(BaseEntity<T>? other)
    {
        if (other is null) 
            return false;
        return EqualsInternal(other);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) 
            return false;
        if (obj is not BaseEntity<T> other)
            return false;
        return EqualsInternal(other);
    }

    private bool EqualsInternal(BaseEntity<T> other)
    {
        if (ReferenceEquals(this, other)) return true;
        return Id == other.Id;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(typeof(T), Id);
    }

    public static bool operator ==(BaseEntity<T>? left, BaseEntity<T>? right)
    {
        if (left is null)
            return Equals(left, right);
        return left.Equals(right);
    }

    public static bool operator !=(BaseEntity<T>? left, BaseEntity<T>? right)
    {
        if (left is null)
            return !Equals(left, right);
        return !left.Equals(right);
    }
}
