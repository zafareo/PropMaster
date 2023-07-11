using Application.Common.Abstraction;
using Domain.IdentityEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Permissions.Commands
{
    public class UpdatePermissionCommand : IRequest<bool>
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
    }
    public class UpdatePermissionCommandHandler : IRequestHandler<UpdatePermissionCommand, bool>
    {
        private IApplicationDbContext _context;

        public UpdatePermissionCommandHandler(IApplicationDbContext context)
               => (_context) = (context);


        public async Task<bool> Handle(UpdatePermissionCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Permissions.FindAsync(new object[] { request.Id }, cancellationToken);
            if (entity != null)
            {
                entity.Name = request.Name;
                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
           return false;
        }
    }
}
