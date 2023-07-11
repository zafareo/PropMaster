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
    public class UpdateAgentCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public string ProfilePicture { get; set; }
        public List<Guid> PropertyIds { get; set; }
    }

    public class UpdateAgentCommandHandler : IRequestHandler<UpdateAgentCommand, bool>
    {
        private readonly IApplicationDbContext _context;
        public UpdateAgentCommandHandler(IApplicationDbContext context)
               => (_context) = (context);


        public async Task<bool> Handle(UpdateAgentCommand request, CancellationToken cancellationToken)
        {
            Agent? entity = await _context.Agents
                .FindAsync(new object[] { request.Id }, cancellationToken);
            if (entity != null)
            {
                entity.Name = request.Name;
                entity.ContactNumber = request.ContactNumber;
                entity.ProfilePicture = request.ProfilePicture;

                if (request.PropertyIds is not null)
                {
                    List<Property> foundProps = new();
                    foreach (var item in request.PropertyIds)
                    {
                        Property? property = await _context.Properties.FindAsync(new object[] { item });
                        foundProps.Add(property);
                    }
                    entity.Properties = foundProps;
                }

                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
            return false;
        }
    }

}
