using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using ShaurmaN0App.Models;
using ShaurmaN0App.Services.Base;

namespace ShaurmaN0App.Validators
{

    public class OrderValidator : AbstractValidator<Order>
    {
        private readonly IOrderService service;
        private readonly IValidator<OrderItem> orderItemValidator;
        public OrderValidator(IOrderService service, IValidator<OrderItem> orderItemValidator)
        {
            this.service = service;
            this.orderItemValidator = orderItemValidator;

            RuleFor(o => o.Date)
            .NotEmpty()
            .WithMessage("Date is required.");

            RuleFor(o => o.OrderItems)
            .NotEmpty()
            .WithMessage("Order must have at least one item.")
            .ForEach(item =>
            {
                item.SetValidator(orderItemValidator);
            });

            RuleFor(o => o.Total)
            .Must((order, total) =>
            {
                var sum = order.OrderItems.Sum(i => i.Total);
                return (total - sum) == 0;
            })
            .WithMessage("Total does not match sum of order items.");
        }
    }
}