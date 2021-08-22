# Handling content
To use this cms to its full potential, it's important to understand the thought process behind content handling. Here's an explanation of what you should and shouldn't do with content.

## Contexts
There are two different types of context in which you might be handling content, each with an appropriate interface.

### IDocumentInfo
At some point in the code, you know you have a document, but you don't know exactly what type it is at compile time. The `IDocumentInfo` interface gives access to a content item's metadata, but not to values of the document itself. The `IDocumentInfo` also contains the type of the content that belongs with it.

Things you should do with `IDocumentInfo`:  
 ✔ Read the metadata  
 ✔ Pass as parameter to views  
 ✔ Store in and read from models

Things you shouldn't do with `IDocumentInfo`:  
 ❌ Cast to `IDocumentWrapper<TDocument>`

### IDocumentWrapper&lt;TDocument&gt;
At other parts of the code, you know exactly what type the document is at compile time. The `IDocumentWrapper<TDocument>` inherits from `IDocumentInfo` and provides, in addition to the content item's metadata, an instance of the content in a model of type `TDocument`.

Things you should do with `IDocumentWrapper<TDocument>`:  
 ✔ Read the metadata  
 ✔ Read the document values  
 ✔ Pass as parameter to views  
 ✔ Cast to `IDocumentInfo`  
 ✔ Cast to `IDocumentWrapper<TOtherDocument>` if `TDocument` inherits or implements `TOtherDocument`

Things you shouldn't do with `IDocumentWrapper<TDocument>`:  
 ❌ Cast to `IDocumentWrapper<TOtherDocument>` if `TDocument` does not inherit or implement `TOtherDocument`

## Content Flow
Content is created whenever the flow needs it. Creation of content follows this pattern:
 1) Content is requested using a set of arguments (url, id or some other identifying property)
 2) A set of matchers evaluate the arguments to find a matching document description.
 3) A description of this content is obtained as an object of type `IDocumentInfo`.
 4) Custom code can optionally be executed to enrich this model with additional resources.
 5) The content matching the description is obtained as an object of type `IDocumentWrapper<TDocument>`.
 6) Custom code can optionally be executed to enrich this model with additional resources.
 7) Depending if the request at step one has a type or not, this model is returned either as `IDocumentInfo` or as `IDocumentWrapper<TDocument>`