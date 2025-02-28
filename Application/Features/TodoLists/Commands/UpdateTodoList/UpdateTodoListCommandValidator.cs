namespace Application.Features.TodoLists.Commands.UpdateTodoList
{
    public class UpdateTodoListCommandValidator : AbstractValidator<UpdateTodoListCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateTodoListCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.Title)
                .NotEmpty().WithMessage(string.Format(ValidationMessages.Data_Required, "Title"))
                .MaximumLength(200).WithMessage(string.Format(ValidationMessages.Data_MaxLength, "Title", 200))
                .MustAsync(BeUniqueTitle)
                .WithMessage(string.Format(ValidationMessages.Data_Unique, "Title"))
                .WithErrorCode("Unique");
        }

        public async Task<bool> BeUniqueTitle(UpdateTodoListCommand model, string title, CancellationToken cancellationToken)
        {
            return await _context.TodoLists.Where(l => l.Id != model.Id).AllAsync(l => l.Title != title, cancellationToken);
        }
    }
}
