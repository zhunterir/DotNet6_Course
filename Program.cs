using DotNet6_Course;
using DotNet6_Course.MyServices;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IConsoleLogSerivce, MyConsoleLogService>();
builder.Services.AddTransient<SampleFactoryBasedMiddleware>();
var app = builder.Build();
IHostApplicationLifetime lifeTime = app.Lifetime;
var myHostConfi = new MyHostConfiguation(lifeTime) ;
myHostConfi.ConfigureServer();
app.Map("/Branch1", BranchOne); // for branching when request path starts with specific part
app.MapWhen(context => context.Request.Query.ContainsKey("Name"),
    appBuilder => NameBranch(appBuilder));
app.UseWhen(context => context.Request.Path.StartsWithSegments(new PathString("/Branch3")),
    app => Branch3(app));
app.UseMiddleware<MyMiddleWare>();
app.UseSampleFactoryBasedMiddleware();

app.Run();

static void BranchOne(IApplicationBuilder app)
{
    app.Run(async (context) =>
    {
        await context.Response.WriteAsync("From Br1");
    });
}
static void NameBranch(IApplicationBuilder app)
{
    app.Run(async (context) =>
    {
        await context.Response
        .WriteAsync($"From Branch Name with name = {context.Request.Query["Name"]}");
    });
}
static void Branch3(IApplicationBuilder app)
{
    app.Run(async (context) =>
    {
        await context.Response.WriteAsync("From Br3");
    });

}

public class MyHostConfiguation
{
    private readonly IHostApplicationLifetime lifetime;

    public MyHostConfiguation(IHostApplicationLifetime lifetime)
    {
        this.lifetime = lifetime;
    }
    public void ConfigureServer()
    {
        lifetime.ApplicationStarted.Register(() =>
        {
            Debug.WriteLine("Application was started hoooraaa. (just a life time test)");
        });
        lifetime.ApplicationStopping.Register(() =>
        {
            Debug.WriteLine("Apllicatiion is stopping ( just a life time test)");
        });
        lifetime.ApplicationStopped.Register(() =>
        {
            Debug.WriteLine("Apllicatiion was stopped ( just a life time test)");
        });
    }
}