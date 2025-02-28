namespace Application.Features.TodoItems.Commands.UpdateTodoItemDetail
{
    public record UpdateTodoItemDetailCommand(int Id, int ListId, PriorityLevel Priority, string? Note) : IRequest;
}
