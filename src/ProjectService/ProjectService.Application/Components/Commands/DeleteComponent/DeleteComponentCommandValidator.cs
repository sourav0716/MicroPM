using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace ProjectService.Application.Components.Commands.DeleteComponent
{
    public class DeleteComponentCommandValidator : AbstractValidator<DeleteComponentCommand>
    {
        public DeleteComponentCommandValidator()
        {
             RuleFor(x => x.ProjectId).NotEmpty().WithMessage("Project Id is required.");
             RuleFor(x => x.Name).NotEmpty().WithMessage("Component Id is required.");
        }
    }
}