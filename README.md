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

Packages/tools used:
(if you havent already installed)
```
dotnet tool install --global dotnet-ef
```

```
dotnet add package Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
```