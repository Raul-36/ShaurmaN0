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
        public OrderValidator(IOrderService service)
        {
            this.service = service;

            
        }
    }
}