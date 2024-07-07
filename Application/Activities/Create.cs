using Domain;
using MediatR;
using Persistence;
using SQLitePCL;

namespace Application.Activities
{
    public class Create
    {
        public class Command : IRequest
        {
            public Activity activity { get; set; }
        }


        public class Handler : IRequestHandler<Command>
        {

            private readonly DataContext _context;
            public Handler (DataContext context)
            {
                _context = context;
            }
            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
                _context.Activities.Add(request.activity);
                await _context.SaveChangesAsync();
            }

        }

    }
}