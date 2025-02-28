namespace Application.Features.TodoItems.Handlers.Commands
{
    public class UpdateTodoItemDetailCommandHandler : IRequestHandler<UpdateTodoItemDetailCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateTodoItemDetailCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Handle(UpdateTodoItemDetailCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.TodoItems.FindAsync([request.Id], cancellationToken);

            Guard.Against.NotFound(request.Id, entity);

            entity.ListId   = request.ListId;
            entity.Priority = request.Priority;
            entity.Note     = request.Note;

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
