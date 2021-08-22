# Documentation

## Headers on code files.
Each code file should contain an appropriate header. An appropriate header contains a license statement and authors and might look like this:

```csharp
/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 *                                                                           *
 *   LICENSE:                                                                *
 *      mit                                                                  *
 *   AUTHORS:                                                                *
 *      D_Inventor                                                           *
 *                                                                           *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
```
 - The header is exactly 79 characters wide, including the leading and trailing `/`.
 - There are 3 spaces between the * and the title of an option.
 - There are 6 spaces between the * and the value of the option.
 - If there are multiple authors, they are separated with a comma and a space.
 - If a value exceeds the width limitation, the value should continue on the next line, leaving 4 spaces between the * and the value.

## XML Docs
This project uses XML docs to maintain documentation on types. The documentation follows a set of rules

### In general
Follow these guidlines in every xml comment:
 - Describe each (type)parameter in at most 2 short sentences. If you're unable to make up a short description, then you should probably reconsider your implementation.
 - If you mention types, methods or properties, use the appropriate tags for referencing: `<paramref>`, `<see>`, etc.
 - The summary should be at most 2 short sentences.

### Interfaces
On the interface itself, one should place an XML comment with following properties:
 - The summary follows this format: *"Any type that implements this interface can (...)"*, where (...) is replaced by what a type should do when implementing this interface.
 - The remark should contain additional information, separated using `<para></para>`.
 - If the interface is used in DI and it's relevant, provide an advice on how types that implement this interface should be registered.

On method and property declarations, one should place an XML comment with the following properties:
 - The summary follows this format: *"When implemented by a type, this [ method | property ] (...)"*, where (...) is replaced by what the method should do when implemented by a type.
 - If implementations of this interface are meant to throw particular exceptions, add these exceptions to the xml comment.

Look at this [example of a well documented interface](Rules%20%26%20Philosophy/Examples/Good%20interface.md).  
Also check out this [example of a badly documented interface](Rules%20%26%20Philosophy/Examples/Bad%20interface.md).

### Types
There are types for two different purposes: Business logic and data storage. Types for data storage are generally referred to as 'models'. Models are usually classes with only a set of simple properties. The meaning of a model should be conveyed through its name. It's therefore not mandatory to add XML documentation to models. Types for business logic DO require XML comments.

In general:
 - Types with business logic should inherit from a documented interface. Do not repeat information that is documented on the interface.
 - The summary should be at most 2 short sentences

On the type itself:
 - The summary tells how the type implements the interface, without repeating information that is already stated on the interface.
 - If no additional information can be provided over the documentation on the interface, inherit the documentation from the interface instead using `<inheritdoc />`.
 - The remark should contain additional information, separated using `<para></para>`.
 - If the type is registered in a DI container, add the scope in which the type is registered.
 - Optionally: Add a remark for the amount of memory that the type uses.

On methods and properties:
 - Inherit the documentation from the interface as much as possible using `<inheritdoc />`
 - The summary tells how the type implements the method, without repeating information that is already stated on the interface.