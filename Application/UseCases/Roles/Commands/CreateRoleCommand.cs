using Application.Common.Abstraction;
using AutoMapper;
using Domain.IdentityEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Roles.Commands
{
    public class CreateRoleCommand : IRequest<Guid>
    {
        public string Name { get; init; }
        public List<Guid>? PermissionIds { get; init; }
    }
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, Guid>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateRoleCommandHandler(IApplicationDbContext context, IMapper mapper)
               => (_context, _mapper) = (context, mapper);


        public async Task<Guid> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {



            var entity = new Role
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
            };

            if (request.PermissionIds is not null)
            {
                List<Permission> foundPermissions = new();
                foreach (var item in request.PermissionIds)
                {
                    var permisson = await _context.Permissions.FindAsync(new object[] { item });
                    foundPermissions.Add(permisson);
                }
                entity.Permissions = foundPermissions;
            }
            await _context.Roles.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }

}
