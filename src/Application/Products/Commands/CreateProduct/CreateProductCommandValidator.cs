using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace TIMSBack.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.ProductId).NotEmpty();
            RuleFor(x => x.Name).MaximumLength(50).NotEmpty();
        }
    }
}
