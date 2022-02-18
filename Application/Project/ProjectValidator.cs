using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Project
{
    public class ProjectValidator : AbstractValidator<Domain.Project>
    {
        public ProjectValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Status).NotEmpty();
            RuleFor(p => p.Description).NotEmpty();
        }
    }
}