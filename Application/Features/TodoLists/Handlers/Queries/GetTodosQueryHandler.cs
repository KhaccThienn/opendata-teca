namespace Application.Features.TodoLists.Handlers.Queries
{
    public class GetTodosQueryHandler : IRequestHandler<GetTodoQuery, TodosVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper               _mapper;

        public GetTodosQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper  = mapper;
        }

        public async Task<TodosVm> Handle(GetTodoQuery request, CancellationToken cancellationToken)
        {
            return new TodosVm
            {
                PriorityLevels = Enum.GetValues(typeof(PriorityLevel))
                    .Cast<PriorityLevel>()
                    .Select(p => new LookupDto { Id = ((int)p), Title = p.ToString()})
                    .ToList(),

                Lists = await _context.TodoLists
                    .AsNoTracking()
                    .ProjectTo<TodoListDto>(_mapper.ConfigurationProvider)
                    .OrderBy(x => x.Title)
                    .ToListAsync(cancellationToken)
            };
        }
    }
}
