using Application.Common.Abstraction;
using Application.UseCases.Permissions.Commands;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Properties.Commands
{
    public class DeletePropertyCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
    public class DeletePropertyCommandHandler : IRequestHandler<DeletePropertyCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public DeletePropertyCommandHandler(IApplicationDbContext context)
               => _context = context;


        public async Task<bool> Handle(DeletePropertyCommand request, CancellationToken cancellationToken)
        {
            Property? entity = await _context.Properties.FindAsync(new object[] { request.Id }, cancellationToken);
            if (entity != null)
            {
                _context.Properties.Remove(entity);
                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
            return false;
        }
    }
}
