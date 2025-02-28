namespace Application.Features.TodoItems.Commands.UpdateTodoItem
{
    public record UpdateTodoItemCommand(int Id, string? Title, bool Done) : IRequest;
}
