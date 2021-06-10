# TLSTechTest

This project is about an imaaginary job listing application that shows the listed jobs using React JS framework as the rendering engine and .Net Core backed as the API.

## How to test the application

The application is build with two possible configurations, a database hosted on SQL Server as the repository or an In Memory Repository which stores the items in a list.
1. Using SQL Server
    
    In order to use database hosted on sql server, there are 2 steps that are required.
    1. Change the `ConnectionString` in `appsettings.json` file to point to the correct database.
    2. Run the Entity Framework migrations using the command `dotnet ef database update`

2. Using In Memory Repository

    In order to use the InMemoryRepository, the only step required is to change `services.AddScoped<IRepository, InMemoryJobsRepository>` to `services.AddSingleton<IRepository, SqlJobsRepository>` `Startup.cs` file

## Future Improvements

1. When time permits, the application can be improved to do better type checking on the JobType field as currently it throws an exception if a JobType other than the predefined JobTypes are entered. This can possibly be fixed (needs testing) by using `AddJsonOptions` with `JsonStringEnumConverter` in addition to `AddControllers` middleware and using JobType instead of string as datatype for JobType field in `CreateJobDto`.
2. Add more tests to React app to make sure that changes in the future do not result in breaking functionality.
3. Refactor `App` component and move some of the logic to other components or helper methods to reduce complexity.
