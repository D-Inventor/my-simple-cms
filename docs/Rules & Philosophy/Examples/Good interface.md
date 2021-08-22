```csharp
/// <summary>
/// Any type that implements this interface can search for <see cref="Bar" /> in an external source and return an instance
/// </summary>
/// <remarks>
/// <para>Implementations of this interface can have a long execution time; Avoid calling methods on this interface inside a request</para>
/// <para>Register in DI as: Singleton</para>
/// </remarks>
public interface IFoo
{
    /// <summary>
    /// When implemented by a type, this method searches for <see cref="Bar"> in an external source using the given <paramref name="id">
    /// </summary>
    /// <param name="id">The unique identifier of the instance</param>
    /// <returns>An instance of <see cref="Bar" /> with the given <paramref name="id" /></returns>
    /// <exception cref="NotFoundException">Thrown when no instance of <see cref="Bar" /> exists with the given <paramref name="id" /></exception>
    Bar FindBar(int id)
}
```

 ✔ Summaries are at most 2 short sentences long.  
 ✔ References to types and (type) parameters are referenced using proper xml tags.  
 ✔ Additional information is added in remarks, separated with `<para></para>`.  
 ✔ Advice for DI registration is provided.  
 ✔ Expected exceptions are provided.  
 ✔ All parameters are documented with at most 2 short sentences each.