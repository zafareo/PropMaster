using Application.Common.Abstraction;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Properties.Commands
{
    public class CreatePropertyCommand : IRequest<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Uri Location { get; set; }
        public string ImageUrl { get; set; }
        public bool IsRent { get; set; }
        public Guid OwnerId { get; set; } // Foreign key to Owner
        public List<Guid> AgentsId { get; set; } // Many-to-many relationship with Agent
    }
    public class CreatePropertyCommandHandler : IRequestHandler<CreatePropertyCommand, Guid>
    {
        private readonly IApplicationDbContext _context;
        public CreatePropertyCommandHandler(IApplicationDbContext context)
               => (_context) = (context);

        public async Task<Guid> Handle(CreatePropertyCommand request, CancellationToken cancellationToken)
        {
            var entity = new Property
            {
                Title = request.Title,
                Description = request.Description,
                Price = request.Price,
                Location = request.Location,
                ImageUrl = request.ImageUrl,
                IsRent = request.IsRent,
                OwnerId = request.OwnerId,
                
            };
            if (request.AgentsId is not null)
            {
                List<Agent> FounAgent = new();
                foreach (var item in request.AgentsId)
                {
                    Agent? agent = await _context.Agents.FindAsync(new object[] { item });
                    FounAgent.Add(agent);
                }
                entity.Agents = FounAgent;
            }

            await _context.Properties.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }

}
