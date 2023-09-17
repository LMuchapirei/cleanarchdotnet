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

