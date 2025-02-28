using Application.Features.TodoItems.DTOs;

namespace Application.Features.TodoItems.Mappings
{
    public class TodoItemMapper : Profile
    {
        public TodoItemMapper()
        {
            CreateMap<TodoItem, TodoItemBriefDto>();
        }
    }
}
