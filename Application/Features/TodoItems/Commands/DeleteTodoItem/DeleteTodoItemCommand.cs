namespace Application.Features.TodoItems.Commands.DeleteTodoItem
{
    public record DeleteTodoItemCommand(int Id) : IRequest;
}
