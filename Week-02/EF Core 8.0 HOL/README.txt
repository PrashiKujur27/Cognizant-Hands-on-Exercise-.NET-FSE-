RetailInventory - Labs 1 to 5

Commands:
1. dotnet restore
2. dotnet tool install --global dotnet-ef   (once)
3. dotnet ef migrations add InitialCreate
4. dotnet ef database update
5. dotnet run

If preview package versions cause issues, replace them with the latest stable versions using:
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Design
