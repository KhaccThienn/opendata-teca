namespace Application.Features.TodoLists.Commands.DeleteTodoList
{
    public record DeleteTodoListCommand(int Id) : IRequest;
}
