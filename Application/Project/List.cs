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
        public class Query: IRequest<Result<List<Domain.Project>>>{}

        public class Handler : IRequestHandler<Query, Result<List<Domain.Project>>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<List<Domain.Project>>> Handle(Query request, CancellationToken cancellationToken)
            {
                return Result<List<Domain.Project>>.Success(await _context.Project.ToListAsync());
            }
        }
    }
}