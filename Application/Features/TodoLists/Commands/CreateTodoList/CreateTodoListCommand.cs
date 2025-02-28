namespace Application.Features.TodoLists.Commands.CreateTodoList
{
    public record CreateTodoListCommand(string? Title) : IRequest<int>;
}
