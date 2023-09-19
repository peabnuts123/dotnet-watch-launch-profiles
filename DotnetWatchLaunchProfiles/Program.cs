var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Logs "Hello world" when run with `dotnet run`
// Logs empty string (and runs the application with all default options, such as applicationUrl)
//   when run with `dotnet watch run` because `launchSettings.json` contains a comment
Console.WriteLine($"Environment: '{Environment.GetEnvironmentVariable("MyVariable")}'");

app.MapGet("/", () => "Hello World!");

app.Run();
