using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Persistence;

namespace Application.Project
{
    public class Create
    {
        public class Command: IRequest
        {
            public Domain.Project Project {get;set;}
        }

        public class Handler : IRequestHandler<Command>
        {

            private readonly DataContext context;
            public Handler(DataContext context)
            {
            this.context = context;
            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                this.context.Project.Add(request.Project);
                await this.context.SaveChangesAsync();
                return Unit.Value;
            }
        }
    }
}