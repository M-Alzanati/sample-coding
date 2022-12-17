# Example Coding Task Task Template

This template should be used for coding tasks of Example.

Three projects are included in this solution:
- Example.CodingTask.Host: A .NET Core 6 Web Application
- Example.CodingTask.Data: A .NET Core 6 class library which includes the first implementation of DB Context and User table.
- Example.CodingTask.Core: A .NET Core 6 class library which includes models and dtos.
- Example.CodingTask.Service: A .NET Core 6 class library which includes services.
- Example.CodingTask.Utilities: A .NET Core 6 class library which includes the Hash Service.

Database initialization has been implemented and configured in startup.

Basic authentication has been implemented and wired to the User table in DbContext.

An example API controller has been implemented as PingController which includes two GET methods, one without Authorization and the other one with Authorization.

By default, db connection string is configured for SQL Express. This can be changed in appSettings.Development.json .

Following users are provisioned during startup:

|UserName|Password|
|-|-|
|User1|Password1|
|User2|Password2|

**Build FrontEnd**
```bash
$ npm install
$ ng serve
```
**Build Backend**
```bash
$ cd Backend/src
$ dotnet ef database update --project "Example.CodingTask.Data/Example.CodingTask.Data.csproj"
$ Open visual studio and run
```
**Build Backend With Docker**
```bash
$ cd Backend/src
$ docker build -t codingtaskimage .
$ docker run -d -p 44337:80 -p 44338:443 --name codingtaskapi codingtaskimage
```

```
**Build FrontEnd With Docker**
```bash
$ docker build -t codingtaskangularapp .
$ docker run -d -it -p 4200:80/tcp --name angular-app codingtaskangularapp
```

### Change connection string in DefaultConnection in Example.CodingTask.Data/appsettings

### Change connection string in DefaultConnection in Example.CodingTask.Host/appsettings.Development
________________________
## Connection string format:
Server=ip, port;Database=name;Trusted_Connection=False;User Id=user_id;Password=user_password;

**Please note if the the database is not working, follow this url to enable remote connection https://medium.com/@vedkoditkar/connect-to-local-ms-sql-server-from-docker-container-9d2b3d33e5e9**