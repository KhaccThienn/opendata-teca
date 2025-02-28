namespace Application.Features.TodoItems.Commands.UpdateTodoItem
{
    public class UpdateTodoItemCommandValidator : AbstractValidator<UpdateTodoItemCommand>
    {
        public UpdateTodoItemCommandValidator()
        {
            RuleFor(v => v.Title)
                .NotEmpty().WithMessage(string.Format(ValidationMessages.Data_Required, "Title"))
                .MaximumLength(200)
                .WithMessage(string.Format(ValidationMessages.Data_MaxLength, "Title", 200));
        }
    }
}
