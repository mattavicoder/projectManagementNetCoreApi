using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Project
{
    public class List
    {
        public class Query: IRequest<List<Domain.Project>>{}

        public class Handler : IRequestHandler<Query, List<Domain.Project>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<Domain.Project>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Project.ToListAsync();
            }
        }
    }
}