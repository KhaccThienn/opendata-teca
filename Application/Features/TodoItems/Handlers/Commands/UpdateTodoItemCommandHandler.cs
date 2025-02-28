namespace Application.Features.TodoItems.Handlers.Commands
{
    public class UpdateTodoItemCommandHandler : IRequestHandler<UpdateTodoItemCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateTodoItemCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateTodoItemCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.TodoItems.FindAsync([request.Id], cancellationToken);

            Guard.Against.NotFound(request.Id, entity);

            entity.Title = request.Title;
            entity.Done  = request.Done;

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
