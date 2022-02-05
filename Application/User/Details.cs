using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Persistence;

namespace Application.User
{
    public class Details
    {
        public class Query:IRequest<Domain.User> {public int Id {get;set;}}

        public class Handler : IRequestHandler<Query, Domain.User>
        {
            private readonly DataContext context;

            public Handler(DataContext context)
            {
                this.context = context;
            }

            public async Task<Domain.User> Handle(Query request, CancellationToken cancellationToken)
            {
                return await this.context.User.FindAsync(request.Id);
            }
        }
    }
}