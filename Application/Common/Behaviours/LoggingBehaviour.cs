    namespace Application.Common.Behaviours
{
    // The LoggingBehaviour class implements IRequestPreProcessor<TRequest> interface
    // TRequest is a generic type parameter constrained to be non-nullable
    public class LoggingBehaviour<TRequest> : IRequestPreProcessor<TRequest> where TRequest : notnull
    {
        // Private readonly fields for dependencies

        private readonly ILogger          _logger;
        private readonly IUser            _user;
        private readonly IIdentityService _identityService;

        // Constructor to initialize the dependencies
        public LoggingBehaviour(ILogger<TRequest> logger, IUser user, IIdentityService identityService)
        {
            _logger          = logger;          // Logger instance
            _user            = user;            // User instance
            _identityService = identityService; // Identity service instance
        }

        // Asynchronous method to process the request
        public async Task Process(TRequest request, CancellationToken cancellationToken)
        {
            // Get the name of the request type
            var requestName = typeof(TRequest).Name;
            // Get the user ID from the user instance, default to empty string if null
            var userId = _user.Id ?? string.Empty;
            // Initialize userName as an empty string
            string? userName = string.Empty;

            // If userId is not empty, get the userName from the identity service
            if (!string.IsNullOrEmpty(userId))
            {
                userName = await _identityService.GetUserNameAsync(userId);
            }

            // Log the request details with the logger
            _logger.LogWithTime($"CleanArchitecture Request: {requestName} {userId} {userName} {request}");
        }
    }
}
