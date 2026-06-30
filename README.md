# how to run:

1. [Get the .NET SDK](https://dotnet.microsoft.com/download)
2. You can run the following commands:

```
cd TaskPlanner
dotnet restore
```

3. Run `dotnet run` & head to http://localhost:5078

# other info
template used: ASP.Net (Model-View-Controller)
```
dotnet new mvc -n TaskPlanner
```

Packages used:
```
dotnet add package Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.InMemory
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
```