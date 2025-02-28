namespace Application.Features.TodoLists.Commands.PurgeTodoLists
{
    [Authorize(Roles = Roles.Admin)]
    [Authorize(Policy = Policies.CanPurge)]
    public record PurgeTodoListsCommand : IRequest;
}
