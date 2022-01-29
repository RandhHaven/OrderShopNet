using FluentValidation;

namespace OrderShopNet.Api.Application.Order.Commands.UpdateOrder;

internal class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
{
    public UpdateOrderCommandValidator()
    {
        RuleFor(x => x.OrderShopId)
              .NotEmpty();
        RuleFor(x => x.Title)
            .NotEmpty();
        RuleFor(x => x.NumberOrder)
            .NotEmpty()
            .MaximumLength(100);
    }
}