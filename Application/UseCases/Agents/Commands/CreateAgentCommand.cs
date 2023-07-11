using Application.Common.Abstraction;
using Domain.Entities;
using Domain.IdentityEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Agents.Commands
{
    public class CreateAgentCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public string ProfilePicture { get; set; }
        public List<Guid> PropertyIds { get; set; }
    }

    public class CreateAgentCommandHandler : IRequestHandler<CreateAgentCommand, Guid>
    {
        private readonly IApplicationDbContext _context;
        public CreateAgentCommandHandler(IApplicationDbContext context)
               => (_context) = (context);



        public async Task<Guid> Handle(CreateAgentCommand request, CancellationToken cancellationToken)
        {
            var entity = new Agent
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                ContactNumber = request.ContactNumber,
                ProfilePicture = request.ProfilePicture,

            };
            if (request.PropertyIds is not null)
            {
                List<Property> foundprops = new();
                foreach (var item in request.PropertyIds)
                {
                    Property? property = await _context.Properties.FindAsync(new object[] { item });
                    foundprops.Add(property);
                }
                entity.Properties = foundprops;
            }
            await _context.Agents.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;

        }
    }
}
