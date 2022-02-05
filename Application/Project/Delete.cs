using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Persistence;

namespace Application.Project
{
    public class Delete
    {
        public class Command: IRequest
        {
            public int Id {get;set;}
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
                var project = await this.context.Project.FindAsync(request.Id);

                this.context.Project.Remove(project);
                await this.context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}