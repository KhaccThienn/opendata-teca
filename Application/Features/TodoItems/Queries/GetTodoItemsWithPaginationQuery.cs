namespace Application.Features.TodoItems.Queries
{
    public record GetTodoItemsWithPaginationQuery(int ListId, int PageNumber = 1, int PageSize = 10) : IRequest<PaginatedList<TodoItemBriefDto>>;
}
