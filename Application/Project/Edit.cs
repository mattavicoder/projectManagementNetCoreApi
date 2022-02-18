using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Project
{
    public class Edit
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
            private readonly IMapper mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                this.context = context;
                this.mapper = mapper;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var project = await this.context.Project.FindAsync(request.Project.Id);

                if(project == null) return null;
                
                this.mapper.Map(request.Project, project);

                var changes = await this.context.SaveChangesAsync() > 0;

                if(!changes) return Result<Unit>.Failure("Failed to Update the Project Details");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}