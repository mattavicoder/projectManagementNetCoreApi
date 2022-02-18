using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Project
{
    public class Create
    {
        public class Command: IRequest<Result<Unit>>
        {
            public Domain.Project Project {get;set;}
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(p => p.Project).SetValidator(new ProjectValidator());
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {

            private readonly DataContext context;
            public Handler(DataContext context)
            {
            this.context = context;
            }
            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                this.context.Project.Add(request.Project);
                var changes  = await this.context.SaveChangesAsync() > 0;

                if(!changes) return Result<Unit>.Failure($"Failed to Create the Project {request.Project.Name}");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}