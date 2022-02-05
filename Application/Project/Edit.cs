using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Persistence;

namespace Application.Project
{
    public class Edit
    {
        public class Command: IRequest
        {
            public Domain.Project Project {get;set;} 
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext context;
            private readonly IMapper mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                this.context = context;
                this.mapper = mapper;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var project = await this.context.Project.FindAsync(request.Project.Id);
                
                this.mapper.Map(request.Project, project);

                await this.context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}