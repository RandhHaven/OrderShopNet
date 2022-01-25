using FluentValidation;

namespace OrderShopNet.Api.Application.Product.Commands.UpdateProduct;

internal class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(x => x.NameProduct)
            .NotEmpty().WithMessage("Product Name not null")
            .MaximumLength(100);
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Descriptionnot null")
            .MaximumLength(100);
        RuleFor(x => x.Quantity)
            .NotNull();
    }
}
