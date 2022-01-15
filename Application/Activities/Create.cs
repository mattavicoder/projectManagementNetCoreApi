using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class Create
    {
        public class Command: IRequest
        {
            public Activity Acitivity { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
        private readonly DataContext context;
            public Handler(DataContext context)
            {
            this.context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                request.Acitivity.Id = Guid.NewGuid();
                
                this.context.Activities.Add(request.Acitivity);

                await this.context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}