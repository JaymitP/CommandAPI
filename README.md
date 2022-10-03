# Command REST API

A simple RESTful web API created with **ASP.NET Core 6.0**. The API communicates with a database to provide CLI commands and their descriptions. The API provides 6 (CRUD) endpoints to create, read, update and delete resources.

To accelerate my learning of core .NET functionalities and good practices, I followed the [.NET Core 3.1 MVC REST API Tutorial](https://www.youtube.com/watch?v=fmvcAzHpsk8) by Les Jackson.\
I decided to use **.NET Core 6** instead of .NET Core 3.1 since it has improved features and performance.\
Additionally I used **PostgresSQL** instead of MSSQL since it is more frequently used with Node.js which I am currently learning

- REST principles and HTTP response status codes
- **Dependency injection**
- **Entity Framework Core** for DbContext and migrations
- **Repository design pattern**
- **PostgresSQL** & **pgAdmin**
- **Swagger UI** based RESTful Web API specification\
- **Postman** for testing API endpoints

### API Endpoints on Swagger UI:

![image](https://user-images.githubusercontent.com/85488637/193468655-1c4af4b5-974f-4477-ae66-a83c094101bc.png)

### Architecture used

#### Diagram by Les Jackson

![image](https://user-images.githubusercontent.com/85488637/193469077-48e31aef-d373-4653-acc9-17de81019d64.png)

## List of dotnet commands used

### For future reference

1. dotnet build
   - Builds project and its dependencies - used to test if project builds correctly
2. dotnet watch run
   - Runs source code and hot reloads on changes
3. dotnet add package [package]
   - Adds or updates a package reference in a project file.
4. dotnet tool install --global dotnet-ef
   - Installs the Entity Framework Core command-line tools
5. dotnet ef migrations add [name]
   - Adds a new migration, which is a snapshot of the current model
6. dotnet ef migrations remove>
   - Removes the last migration
7. dotnet ef database update
   - Applies pending migrations to the database
