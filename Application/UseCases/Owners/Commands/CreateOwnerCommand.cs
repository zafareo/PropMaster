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
    public class CreateOwnerCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public List<Guid> PropertyIds { get; set; }
    }
    public class CreateOwnerCommandHandler : IRequestHandler<CreateOwnerCommand, Guid>
    {
        private readonly IApplicationDbContext _context;
        public CreateOwnerCommandHandler(IApplicationDbContext context)
               => (_context) = (context);

        public async Task<Guid> Handle(CreateOwnerCommand request, CancellationToken cancellationToken)
        {
            var entity = new Owner
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                ContactNumber = request.ContactNumber,
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

            await _context.Owners.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }

}
