using DotNet6_Course.MyServices;

namespace DotNet6_Course;

public class MyMiddleWare
{
    private readonly RequestDelegate _next;

    public MyMiddleWare(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, IConsoleLogSerivce consoleLogSerivce)
    {
        if ( !context.Response.HasStarted)
        {
            context.Response.Headers.ContentType = "text";
        }
        await context.Response.WriteAsync("This text is from MyMiddleware ");
        consoleLogSerivce.Log("From MyMiddleware");
        await _next(context);
    } 
}