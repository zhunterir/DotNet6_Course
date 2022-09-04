namespace DotNet6_Course;

public class MyMiddleWare
{
    private readonly RequestDelegate _next;

    public MyMiddleWare(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        if (!context.Response.HasStarted)
        {
            
        }

        await context.Response.WriteAsync("This text is from MyMiddleware ");
        await _next(context);
    } 
}