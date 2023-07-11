using Application.Common.Abstraction;
using MediatR;

namespace Application.UseCases.Agents.Commands
{
    public class DeleteAgentCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
    public class DeleteAgentCommandHandler : IRequestHandler<DeleteAgentCommand, bool>
    {
        private readonly IApplicationDbContext _context;
        public DeleteAgentCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteAgentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Agents
                .FindAsync(new object[] { request.Id }, cancellationToken);
            if (entity is null)
                return false;
            else
            {
                _context.Agents.Remove(entity);
                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
           
        }
    }

}
