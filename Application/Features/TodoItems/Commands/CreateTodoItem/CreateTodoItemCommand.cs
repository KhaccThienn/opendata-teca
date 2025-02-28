namespace Application.Features.TodoItems.Commands.CreateTodoItem
{
    public record CreateTodoItemCommand(int ListId, string? Title) : IRequest<int>;
}
