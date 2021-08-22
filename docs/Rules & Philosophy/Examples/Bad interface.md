```csharp
/// <summary>
/// This interface lets you search for Bar in external sources. The interface is called upon by the framework while saving content to enrich a generic model for indexing purposes.
/// </summary>
/// <remarks>
/// Implementations of this interface can have a long execution time; Avoid calling methods on this interface inside a request
/// </remarks>
public interface IFoo
{
    /// <summary>
    /// When implemented by a type, this method searches for Bar in an external source using the given id
    /// </summary>
    /// <returns>An instance of Bar with the given id</returns>
    /// <exception cref="NotFoundException">Thrown when no instance of Bar exists with the given id</exception>
    Bar FindBar(int id)
}
```

 ❌ The summary on the interface is longer than 2 short sentences and contains contextual information that is more fit for a remark.  
 ❌ references to parameters or types are not documented with the appropriate xml tags.  
 ❌ not all parameters on the method are documented in the xml comment.  
 ❌ remarks are not enclosed in `<para></para>` tags.