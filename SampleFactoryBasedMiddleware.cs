using DotNet6_Course;
using DotNet6_Course.MyServices;

namespace DotNet6_Course
{
    public class SampleFactoryBasedMiddleware : IMiddleware
    {
        private readonly IConsoleLogSerivce consoleLogService;

        public SampleFactoryBasedMiddleware(MyServices.IConsoleLogSerivce consoleLogService)
        {
            this.consoleLogService = consoleLogService;
        }
        private void DoSomething()
        {
            // Do some thing
            return;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            DoSomething();
            consoleLogService.Log($"Midddleware {nameof(SampleFactoryBasedMiddleware)} was executed");

        }
    }
}
public  static partial class MiddlewareExtensions
{
    public static IApplicationBuilder UseSampleFactoryBasedMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<SampleFactoryBasedMiddleware>();
        return app;
    }
}
