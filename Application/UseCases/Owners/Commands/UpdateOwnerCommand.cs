using Application.Common.Abstraction;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Owners.Commands
{
    public class UpdateOwnerCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public List<Guid> PropertyIds { get; set; }
    }
    public class UpdateOwnerCommandHandler : IRequestHandler<UpdateOwnerCommand, bool>
    {
        private readonly IApplicationDbContext _context;
        public UpdateOwnerCommandHandler(IApplicationDbContext context)
               => (_context) = (context);

        public async Task<bool> Handle(UpdateOwnerCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Owners
                .FindAsync(new object[] { request.Id }, cancellationToken);
            if (entity != null)
            {
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
                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
            return false;            
        }
    }
}
