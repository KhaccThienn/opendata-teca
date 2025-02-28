namespace Application.Features.TodoLists.Commands.UpdateTodoList
{
    public record UpdateTodoListCommand(int Id, string? Title) : IRequest;
}
