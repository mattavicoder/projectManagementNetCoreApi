using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.User
{
    public class List
    {
        // public class Query:IRequest<List<Domain.User>> {}

        // public class Handler : IRequestHandler<Query, List<Domain.User>>
        // {
        //     private readonly DataContext context;

        //     public Handler(DataContext context)
        //     {
        //         this.context = context;
        //     }

        //     public async Task<List<Domain.User>> Handle(Query request, CancellationToken cancellationToken)
        //     {
        //         return await this.context.User.ToListAsync();
        //     }
        // }
    }
}