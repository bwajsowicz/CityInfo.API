using CityInfo.API.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Validators
{ 
    public class PointsOfIntrestsForCreationValidator : AbstractValidator<PointsOfInterestForCreationDTO>
    {
        public PointsOfIntrestsForCreationValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(50);
            RuleFor(x => x.Description)
                .NotEmpty()
                .MaximumLength(200)
                .NotEqual(x => x.Name)
                .WithMessage("Description should be different from the name.");
        }
    }
}
