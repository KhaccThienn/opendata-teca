namespace Application.Features.TodoLists.Commands.CreateTodoList
{
    public class CreateTodoListCommandValidator : AbstractValidator<CreateTodoListCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateTodoListCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage(string.Format(ValidationMessages.Data_Required, "Title"))
                .MaximumLength(200).WithMessage(string.Format(ValidationMessages.Data_MaxLength, "Title", 200))
                .MustAsync(BeUniqueTitle)
                .WithMessage(string.Format(ValidationMessages.Data_Unique, "Title"))
                .WithErrorCode("Unique");
        }

        public async Task<bool> BeUniqueTitle(string title, CancellationToken cancellationToken)
        {
            return await _context.TodoLists.AllAsync(l => l.Title != title, cancellationToken);
        }
    }
}
