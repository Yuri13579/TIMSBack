using FluentValidation;

namespace TIMSBack.Application.TodoItems.Commands.CreateTodoItem
{
    public class CreateTodoItemCommandValidator : AbstractValidator<CreateTodoItemCommand>
    {
        public CreateTodoItemCommandValidator()
        {
            RuleFor(v => v.Title)
                .MaximumLength(50)
                .NotEmpty();
        }
    }
}
