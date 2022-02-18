using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Persistence;

namespace Application.Project
{
    public class Details
    {
        public class Query: IRequest<Result<Domain.Project>>{public int Id { get; set; }}

        public class Handler : IRequestHandler<Query, Result<Domain.Project>>
        {
            private readonly DataContext context;

            public Handler(DataContext context)
            {
                this.context = context;
            }

            public async Task<Result<Domain.Project>> Handle(Query request, CancellationToken cancellationToken)
            {
                var project = await this.context.Project.FindAsync(request.Id);

                if(project == null) return null;
                return Result<Domain.Project>.Success(project);
            }
        }
    }
}