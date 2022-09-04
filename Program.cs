using DotNet6_Course;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseMiddleware<MyMiddleWare>();
app.MapGet("/", () => "Hello World!");

app.Run();