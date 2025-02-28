namespace Application.Features.TodoItems.Events
{
    public class TodoItemCompletedEventHandler : INotificationHandler<TodoItemCompletedEvent>
    {
        private readonly ILogger<TodoItemCompletedEventHandler> _logger;

        public TodoItemCompletedEventHandler(ILogger<TodoItemCompletedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(TodoItemCompletedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogWithTime($"CleanArchitecture Domain Event: {notification.GetType().Name}", LogLevel.Information);
            return Task.CompletedTask;
        }
    }
}
