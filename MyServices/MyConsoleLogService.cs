namespace DotNet6_Course.MyServices
{
    public interface IConsoleLogSerivce
    {
        void Log(string message);
    }
    public class MyConsoleLogService : IConsoleLogSerivce
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
