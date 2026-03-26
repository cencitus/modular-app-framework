using ModularApp.Services;

public class ConsoleLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine("[Логи] " + message);
    }
}