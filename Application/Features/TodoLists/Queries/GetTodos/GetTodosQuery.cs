namespace Application.Features.TodoLists.Queries.GetTodos
{
    [Authorize]
    public record GetTodoQuery : IRequest<TodosVm>;

}
