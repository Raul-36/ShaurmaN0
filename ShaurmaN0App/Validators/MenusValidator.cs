using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.Identity.Client;
using ShaurmaN0App.Models;
using ShaurmaN0App.Services.Base;

namespace ShaurmaN0App.Validators
{
    public class MenusValidator : AbstractValidator<Menus>
    {
        private readonly IMenusService service ;
        public MenusValidator(IMenusService service)
        {
            this.service = service;

            RuleFor(m => m.Name)
            .NotEmpty()
            .WithMessage("Name cannot be empty.")
            .MustAsync(async (name, cancellation) => !await service.NameIsTaken(name))
            .WithMessage("Name is already taken.");
            
        }
    }
}