using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Persistence;

namespace Application.User
{
    public class Edit
    {
        // public class Command: IRequest{public Domain.User User {get;set;}}

        // public class Handler : IRequestHandler<Command>
        // {
        //     private readonly DataContext context;
        //     private readonly IMapper mapper;

        //     public Handler(DataContext context, IMapper mapper)
        //     {
        //         this.context = context;
        //         this.mapper = mapper;
        //     }

        //     public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        //     {
        //         var user = await this.context.User.FindAsync(request.User.Id);
        //         this.mapper.Map(request.User, user);

        //         await this.context.SaveChangesAsync();
        //         return Unit.Value;
        //     }
        // }
    }
}