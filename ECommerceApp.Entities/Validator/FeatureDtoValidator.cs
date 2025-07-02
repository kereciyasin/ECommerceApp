using ECommerceApp.Entities.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Entities.Validator
{
    public class FeatureDtoValidator : AbstractValidator<FeatureDto>
    {
        public FeatureDtoValidator()
        {
            RuleFor(x => x.Name)
               .NotEmpty().WithMessage("Name is required")
               .MaximumLength(50).WithMessage("Name cannot exceed 50 characters");

            RuleFor(x => x.ProductId)
                .GreaterThan(0).WithMessage("ProductId must be greater than zero");

        }

    }
}
