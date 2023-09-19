 dotnet user-secrets init --project .\BuberDinner.Api\

 the above command add a property to the csproj file of our project

 we can then target specific key in our app settings to give it a specific value of our choosing

  dotnet user-secrets set --project .\BuberDinner.Api\ "JwtSettings:Secret" "super-secret-key-from-user-secrets-from-dotnet-csproj-property-group"



  What is the Repository Pattern

  Microsoft docs:
  "Repositories are classes or components than encapsulate the logic required to access data sources"
  It is an abstraction that holds all the data access logic

  Martin Fowler
  "Mediates between the domain and data mapping layer using a collection-like interface for accessing domain objects"

Global Error Handling Approaches

1. Via middleware
2. Via exception filter attribute
3. Problem Details
4. Via error endpoint
5. Custom Problem Details Factory


Problem Details (RFC Specification)

Example

HTTP/1.1 403 Forbidden
Content-Type: application/problem+json
Content-Langauge: en

{
    "type":"https://example.com/probs/out-of-credit",
    "title":"You do not have enough credit.",
    "detail":"Your current balance is 30, but that costs 50.",
    "instance":"/account/12345/msgs/abc",
    "balance":30,
    "accounts":["/account/12345","/account/67890"]
}

[type,title,detail,instance] these are standard properties

Introduction
HTTP [RFC7230] status codees are sometimes not sufficient to convey enough information about an error to be helpful.
While humans behind Web browsers can be informed about the nature of the problem with an HTML [W3C.REC-html5-20141028] response body, non-human consumers of so-called "HTTP API's" are usually not.

This specification defines simple JSON [RFC7159] and XML [W3C.REC-xml-20081126] document formats to suit this purpose. They are designed to be reused by HTTP API's, which can identify distinct "problem types" specific to their needs.

Members
A problem details object can have the following members:
- "type" (string) - A URI reference [RFC3986] that identifies the problem type. This specification encourages that when dereferenced, it provides human-readable documentation for the problem type (e.g., using HTML [W3C.REC-html5-20141028]). When this member is not present , its valye is assumed to be "about:blank"
- "title" (string) - A short, human-readable summary of the problem type. It SHOULD NOT change from occurrence to occurrence of the problem, except for purposes of localization (e.g using proactive content negotiation; see [RFC7232],Section 3.4)
- "status" (number) - The HTTP status code ([RFC7231],Section 6) generated by the origin server for this occurrence of the problem
- "detail" (string) - A human-readable explanation specific to this occurrence of the problem
- "instance" (string) - A URI reference that identifies the specific occurrence of the problem. It may or may not yeild further information if dereferenced

Some more details

Consumers MUST use the "type" string as the primary identifier for the problem type; the "title" string is advisory and included only for users who are not aware of the semantics of the URI and do not have the ability to discover them (e.g., offline log analysis).
Consumers should not automatically dereference the type URI.
The "detail" member , if present, ought to focus on helping the client correct the problem, rather than giving debugging information
Consumers SHOULD NOT parse the "detail" member for information;
extensions are more suitable and less error-prone ways to obtain such information.

Flow control

1. Via Exceptions
2. Via OneOf
3. Via FluentResults
4. Via ErrorOr & Domain Errors

Switch over from the global error handling


CQS(Command Query Seperation)
"A command (procedure) does something but does not return a result"
A query (function or attribute) returns a result but does not change the state (Bertrand Meyer)

Example

interface IStack<T>
{
  void Push(T value); // Command
  T Peek();          // Query
T Pop();            // Doesn't have a place
}


CQRS
(Command query responsibility segregation):
"The fundamental difference is that in CQRS objects are split into two objects, one containing the Commands and one containing the Queries Greg Young"

Looking at the stack example we will have two interfaces representing the actions that either encapsulate a command or a query


interface ICommandStack<T>
{
  void Push(T value);
  T Pop();
}
// am l changing data , thus a command(Change the state)

interface IQueryStack<T>
{
  T Peek();
}

// am l querying the data, thus a query (Get a snapshot of the current state)











