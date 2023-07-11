using Application.Common.Abstraction;
using Application.UseCases.Roles.Commands;
using Domain.Entities;
using Domain.IdentityEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Properties.Commands
{
    public class UpdatePropertyCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Uri Location { get; set; }
        public string ImageUrl { get; set; }
        public bool IsRent { get; set; }
        public Guid OwnerId { get; set; } // Foreign key to Owner
        public List<Guid> AgentsId { get; set; }
    }

    public class UpdatePropertyCommandHandler : IRequestHandler<UpdatePropertyCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public UpdatePropertyCommandHandler(IApplicationDbContext context)
               => (_context) = (context);

        public async Task<bool> Handle(UpdatePropertyCommand request, CancellationToken cancellationToken)
        {

            Property? entity = await _context.Properties
                .FindAsync(new object[] { request.Id }, cancellationToken);
            if (entity != null)
            {
                entity.Title = request.Title;
                entity.Description = request.Description;
                entity.Price = request.Price;
                entity.Location = request.Location;
                entity.ImageUrl = request.ImageUrl;
                entity.IsRent = request.IsRent;
                entity.OwnerId = request.OwnerId;

                if (request.AgentsId is not null)
                {
                    List<Agent> FoundAgent = new();
                    foreach (var item in request.AgentsId)
                    {
                        Agent? agent = await _context.Agents.FindAsync(new object[] { item });
                        FoundAgent.Add(agent);
                    }
                    entity.Agents = FoundAgent;
                }

                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
            return false;
        }
    }
}
