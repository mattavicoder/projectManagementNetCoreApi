using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Persistence;

namespace Application.User
{
    public class Create
    {
        // public class Command: IRequest{ public Domain.User User {get;set;}}

        // public class Handler : IRequestHandler<Command>
        // {
        //     private readonly DataContext context;

        //     public Handler(DataContext context)
        //     {
        //         this.context = context;
        //     }

        //     public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        //     {
        //         this.context.User.Add(request.User);
        //         await this.context.SaveChangesAsync();
        //         return Unit.Value;
        //     }
        // }
    }
}