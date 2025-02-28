namespace Application.Features.TodoItems.Commands.CreateTodoItem
{
    public class CreateTodoItemCommandValidator : AbstractValidator<CreateTodoItemCommand>
    {
        public CreateTodoItemCommandValidator()
        {
            RuleFor(v => v.Title)
                .NotEmpty().WithMessage(string.Format(ValidationMessages.Data_Required, "Title"))
                .MaximumLength(200)
                .WithMessage(string.Format(ValidationMessages.Data_MaxLength, "Title", 200));
        }
    }
}
