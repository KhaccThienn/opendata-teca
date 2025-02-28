namespace Application.Features.TodoItems.Queries
{
    public class GetTodoItemsWithPaginationQueryValidator : AbstractValidator<GetTodoItemsWithPaginationQuery>
    {
        public GetTodoItemsWithPaginationQueryValidator()
        {
            RuleFor(x => x.ListId)
                .NotEmpty().WithMessage(string.Format(ValidationMessages.Data_Required, "ListId"));

            RuleFor(x => x.PageNumber)
                //.GreaterThanOrEqualTo(1).WithMessage("PageNumber at least greater than or equal to 1.");
                .GreaterThanOrEqualTo(1).WithMessage(string.Format(ValidationMessages.Data_Greater_Or_Equals, "PageNumber", 1));

            RuleFor(x => x.PageSize)
                .GreaterThanOrEqualTo(1).WithMessage("PageSize at least greater than or equal to 1.");
        }
    }
}
