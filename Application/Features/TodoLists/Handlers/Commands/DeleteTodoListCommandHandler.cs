namespace Application.Features.TodoLists.Handlers.Commands
{
    public class DeleteTodoListCommandHandler : IRequestHandler<DeleteTodoListCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteTodoListCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(DeleteTodoListCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.TodoLists.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            Guard.Against.Null(entity);

            _context.TodoLists.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
