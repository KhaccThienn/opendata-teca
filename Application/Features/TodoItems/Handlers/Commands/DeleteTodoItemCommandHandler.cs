using Application.Features.TodoItems.Commands.DeleteTodoItem;

namespace Application.Features.TodoItems.Handlers.Commands
{
    public class DeleteTodoItemCommandHandler
    {
        private readonly IApplicationDbContext _context;

        public DeleteTodoItemCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(DeleteTodoItemCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.TodoItems.FindAsync([request.Id], cancellationToken);

            Guard.Against.NotFound(request.Id, entity);

            _context.TodoItems.Remove(entity);

            entity.AddDomainEvent(new TodoItemDeletedEvent(entity));

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
