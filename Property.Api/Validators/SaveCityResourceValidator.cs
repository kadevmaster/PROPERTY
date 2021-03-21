using FluentValidation;
using Property.Api.Resources;

namespace Property.Api.Validators
{
    public class SaveCityResourceValidator : AbstractValidator<SaveCityResource>
    {
        public SaveCityResourceValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}
