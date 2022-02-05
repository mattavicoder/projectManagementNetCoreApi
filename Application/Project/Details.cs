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
        public class Query: IRequest<Domain.Project>{public int Id { get; set; }}

        public class Handler : IRequestHandler<Query, Domain.Project>
        {
            private readonly DataContext context;

            public Handler(DataContext context)
            {
                this.context = context;
            }

            public async Task<Domain.Project> Handle(Query request, CancellationToken cancellationToken)
            {
                return await this.context.Project.FindAsync(request.Id);
            }
        }
    }
}