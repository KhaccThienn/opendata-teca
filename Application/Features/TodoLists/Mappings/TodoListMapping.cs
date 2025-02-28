namespace Application.Features.TodoLists.Mappings
{
    public class TodoListMapping : Profile
    {
        public TodoListMapping()
        {
            CreateMap<TodoItem, TodoItemDto>().ForMember(d => d.Priority,
                opt => opt.MapFrom(s => (int)s.Priority));
        }
    }
}
