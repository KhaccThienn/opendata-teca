using Microsoft.Extensions.Logging;
using Polly;
using System.Net;
using System.Net.Sockets;

namespace Shared.Extensions
{
    public static class HostExtensions
    {
        public static IHost EnsureNetworkConnectivity(this IHost host, IConfiguration configuration, ILogger logger)
        {
            // Ensure network connectivity
            
            var endpoint = GetEndpoint(configuration);
            logger        = logger;

            using (var tcpClient = new TcpClient())
            {
                var retries = 3;
                var polly = Policy
                    .Handle<Exception>()
                    .Retry(retries, (ex, retry) =>
                    {
                        logger.LogWithTime($"[{retry}/{retries}] - {ex.Message}", LogLevel.Warning);
                    });

                logger.LogWithTime($"Checking network, endpoint {endpoint.Host}:{endpoint.Port}");
                var result = polly.ExecuteAndCapture(() => tcpClient.Connect(endpoint.Host, endpoint.Port));

                if (result.Outcome.Equals(OutcomeType.Successful))
                    logger.LogWithTime("Network is ready.");
                else
                {
                    logger.LogWithTime($"Network check failed with exception. \n{result.FinalException}", LogLevel.Error);
                    Environment.Exit(1);
                }
            }

            return host;
        }

        /// <summary>
        /// Get endpoint from configuration
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        private static (string Host, int Port) GetEndpoint(IConfiguration configuration)
        {
            var bootstrapserver = configuration["LoggingSetting:Server"];
            var endpoint        = bootstrapserver.Split(',')[0];
            var parts           = endpoint.Split(':');
            var host            = parts[0];

            if (parts.Length == 1) return (host, 9092);
            if (!int.TryParse(parts[1], out int port))
                throw new ArgumentException("Invalid port. Value: " + parts[1]);
            return (host, port);
        }
    }
}
