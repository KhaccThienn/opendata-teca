namespace Application.Features.TodoLists.DTOs
{
    public class TodoListDto
    {
        public TodoListDto()
        {
            Items = Array.Empty<TodoItemDto>();
        }

        public int Id { get; init; }
        public string? Title { get; init; }
        public string? Colour { get; init; }
        public IReadOnlyCollection<TodoItemDto> Items { get; init; }

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<TodoItem, TodoListDto>();
            }
        }
    }
}
