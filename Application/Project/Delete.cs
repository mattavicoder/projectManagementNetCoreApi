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
        public class Command: IRequest<Result<Unit>>
        {
            public int Id {get;set;}
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
                var project = await this.context.Project.FindAsync(request.Id);

                this.context.Project.Remove(project);
                var changes  = await this.context.SaveChangesAsync() > 0;

                if(!changes) return Result<Unit>.Failure("Failed to Delete the Project");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}