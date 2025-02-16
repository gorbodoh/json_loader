using System;

public static class Logger
{
    public static void Debug(string message)
    {
        buildLog(LogLevel.DEBUG, message);
    }

    public static void Info(string message)
    {
        buildLog(LogLevel.INFO, message);
    }

    public static void Warn(string message)
    {
        buildLog(LogLevel.WARNING, message);
    }

    public static void Error(string message, string stackTrace)
    {
        buildLog(LogLevel.ERROR, message, stackTrace);
    }

    public static void Fatal(string message, string stackTrace)
    {
        buildLog(LogLevel.FATAL, message, stackTrace);
    }

    private static void buildLog(LogLevel logLevel, string message, string stackTrace = "")
    {
        LogModel logModel = new LogModel()
        {
            LogType = nameof(logLevel),
            TimeStamp = System.DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss"),
            LogMessage = message,
            StackTrace = stackTrace
        };
    }
}