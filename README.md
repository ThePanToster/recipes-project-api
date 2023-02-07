# Add an appsettings.json file containing:

```
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "RecipesDb": "Server=IP;Database=DBNAME;Port=PORT;User Id=USERNAME;Password=PASSWORD"
  }
}

```