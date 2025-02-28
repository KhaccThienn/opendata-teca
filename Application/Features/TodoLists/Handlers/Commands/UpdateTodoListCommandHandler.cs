namespace Application.Features.TodoLists.Handlers.Commands
{
    public class UpdateTodoListCommandHandler : IRequestHandler<UpdateTodoListCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateTodoListCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateTodoListCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.TodoLists.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            Guard.Against.Null(entity);

            entity.Title = request.Title;

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
