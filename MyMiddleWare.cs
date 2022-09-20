namespace DotNet6_Course;

public class MyMiddleWare
{
    private readonly RequestDelegate _next;

    public MyMiddleWare(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if ( !context.Response.HasStarted)
        {
            context.Response.Headers.ContentType = "text";
        }
        await context.Response.WriteAsync("This text is from MyMiddleware ");
    } 
}