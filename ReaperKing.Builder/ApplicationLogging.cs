using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace ReaperKing.Builder
{
    public static class ApplicationLogging
    {
        public static ILogger Instance;
        
        public static ILogger Initialize<T>()
        {
            ILoggerFactory factory = LoggerFactory.Create(
                builder => builder.AddConsole(options =>
                {
                    options.IncludeScopes = true;
                })
            );
            Instance = factory.CreateLogger("ReaperKing");
            return Instance;
        }
    }
}