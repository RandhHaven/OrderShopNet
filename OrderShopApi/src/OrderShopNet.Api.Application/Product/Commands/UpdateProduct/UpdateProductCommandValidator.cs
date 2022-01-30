namespace OrderShopNet.Api.Application.Product.Commands.UpdateProduct;

using FluentValidation;

internal class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(x => x.NameProduct)
            .NotEmpty().WithMessage("Product Name not null")
            .MaximumLength(100);
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description not null")
            .MaximumLength(100);
        RuleFor(x => x.Quantity)
            .NotNull();
    }
}