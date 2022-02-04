using Microsoft.Extensions.Logging;

namespace business.Logging;
public static class FileLoggerExtensions
{
    public static ILoggingBuilder AddFileLogging(this ILoggingBuilder builder, string filePath)
    {
        builder.AddProvider(new FileLoggerProvider(filePath));
        return builder;
    }
}