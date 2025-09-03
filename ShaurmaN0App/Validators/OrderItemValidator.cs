using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using ShaurmaN0App.Models;
using ShaurmaN0App.Services.Base;

namespace ShaurmaN0App.Validators
{

    public class OrderItemValidator : AbstractValidator<OrderItem>
    {
        private readonly IMenusService service;
        private Menus? menu;
        public OrderItemValidator(IMenusService service)
        {
            this.service = service;

            RuleFor(i => i.Coutn)
                .GreaterThan(0)
                .WithMessage("Count must be greater than zero.")
                .LessThanOrEqualTo(20)
                .WithMessage("Count must be less than or equal to 20.");



            RuleFor(i => i.MenusId)
                .NotEmpty()
                .NotNull()
                .WithMessage("Menus is required.")
                .MustAsync(async (menusId, cancellation) =>
                {
                    if (!menusId.HasValue)
                        return false;

                    menu = await service.GetByIdAsync(menusId.Value);
                    return menu != null;
                })
                .WithMessage("Menus does not exist.");


            RuleFor(i => i.Total)
                .Must((orderItem, total) =>
                {
                    if (menu == null)
                        return false;
                    return (total - (menu.Price * orderItem.Coutn)) == 0;
                })
                .WithMessage("Invalid Total.");
                
        }
    }
}