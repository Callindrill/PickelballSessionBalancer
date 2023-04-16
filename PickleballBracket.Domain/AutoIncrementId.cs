namespace PickleballBracket.Domain;

/// <summary>
/// A thread-safe and type-independent auto-incrementing id class
/// </summary>
/// <typeparam name="T"></typeparam>
/// <remarks>
/// A separate static field exists for each constructed static type. In this way, we have a thread-safe auto-incrementor for every type, T, that we wish to identify that all increment independently of one another.
/// </remarks>
internal static class AutoIncrementId<T>
{
    private static int _Id;

    /// <summary>
    /// Gets the next available Id for this auto incrementor. This method is thread-safe.
    /// </summary>
    /// <returns>The next available integer for the underlying type.</returns>
    public static int NextId()
    {
        return Interlocked.Increment(ref _Id);
    }
}
