using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Persistence;

namespace Application.User
{
    public class Delete
    {
        public class Command : IRequest { public int Id { get; set; } }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext context;

            public Handler(DataContext context)
            {
                this.context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                // var user = await this.context.User.FindAsync(request.Id);
                // this.context.User.Remove(user);
                // await this.context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}