# .NET To Do List with JWT

A .NET Core Web API application that manages users and todo tasks, protecting endpoints with JWT.


## Commands used for database migration

Run the following commands in the root directory to execute Entity Framework migrations.

```sh
dotnet ef migrations add InitialCreate -p TodoList.Infrastructure/ -s TodoList.Api/
dotnet ef database update -p TodoList.Infrastructure/ -s TodoList.Api/
```