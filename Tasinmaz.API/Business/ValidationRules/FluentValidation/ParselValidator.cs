using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ParselValidator:AbstractValidator<Parsel>
    {
        public ParselValidator()
        {
            //RuleFor(p => p.Adres).NotEmpty();
            //RuleFor(p => p.Il).MinimumLength(2);
            RuleFor(p => p.Il).NotEmpty();
           
        }
    }
}
