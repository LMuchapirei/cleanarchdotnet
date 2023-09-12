 dotnet user-secrets init --project .\BuberDinner.Api\

 the above command add a property to the csproj file of our project

 we can then target specific key in our app settings to give it a specific value of our choosing

  dotnet user-secrets set --project .\BuberDinner.Api\ "JwtSettings:Secret" "super-secret-key-from-user-secrets-from-dotnet-csproj-property-group"