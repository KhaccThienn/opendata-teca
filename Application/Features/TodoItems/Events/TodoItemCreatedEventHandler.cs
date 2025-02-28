namespace Application.Features.TodoItems.Events
{
    public class TodoItemCreatedEventHandler : INotificationHandler<TodoItemCreatedEvent>
    {
        private readonly ILogger<TodoItemCreatedEventHandler> _logger;

        public TodoItemCreatedEventHandler(ILogger<TodoItemCreatedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(TodoItemCreatedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogWithTime($"CleanArchitecture Domain Event: {notification.GetType().Name}", LogLevel.Information);
            return Task.CompletedTask;
        }
    }
}
