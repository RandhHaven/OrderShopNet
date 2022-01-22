namespace OrderShopNet.Api.Application.Order.Commands.CreateOrder
{
    using FluentValidation;

    internal class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.NumberOrder)
                .NotEmpty()
                .MaximumLength(100);
        }
    }
}
