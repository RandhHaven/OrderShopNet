using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderShopNet.Api.Core.Order.Commands.UpdateOrder
{
    internal class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.NumberOrder)
                .NotEmpty()
                .MaximumLength(100);
        }
    }
}
