using Application.Common.Abstraction;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Owners.Commands
{
    public class DeleteOwnerCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
    public class DeleteOwnerCommandHandler : IRequestHandler<DeleteOwnerCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public DeleteOwnerCommandHandler(IApplicationDbContext context)
               => _context = context;

        public async Task<bool> Handle(DeleteOwnerCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Owners
                .FindAsync(new object[] { request.Id }, cancellationToken);
            if (entity != null)
            {
                _context.Owners.Remove(entity);
                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
            return false;   
        }
    }
}
