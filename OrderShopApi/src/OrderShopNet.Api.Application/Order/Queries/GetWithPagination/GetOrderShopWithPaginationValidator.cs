namespace OrderShopNet.Api.Application.Order.Queries.GetWithPagination
{
    using FluentValidation;
    using OrderShopNet.Api.Core.Order.Queries.GetWithPagination;

    internal class GetOrderShopWithPaginationValidator : AbstractValidator<GetOrderShopWithPagination>
    {
        public GetOrderShopWithPaginationValidator()
        {
            RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1).WithMessage("PageNumber at least greater than or equal to 1.");

            RuleFor(x => x.PageSize)
                .GreaterThanOrEqualTo(1).WithMessage("PageSize at least greater than or equal to 1.");
        }
    }
}