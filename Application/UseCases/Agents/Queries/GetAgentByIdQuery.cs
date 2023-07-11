using Application.Common.Abstraction;
using Application.Common.DTO;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Agents.Queries
{
    public class GetAgentByIdQuery : IRequest<AgentGetDTO>
    {
        public Guid Id { get; set; }
    }

    public class GetAgentByIdQueryHandler : IRequestHandler<GetAgentByIdQuery, AgentGetDTO>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAgentByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
               => (_context, _mapper) = (context, mapper);


        public async Task<AgentGetDTO> Handle(GetAgentByIdQuery request, CancellationToken cancellationToken)
        {
            Agent? agent = await _context.Agents
                  .FindAsync(new object[] { request.Id }, cancellationToken);
            if (agent != null)
            {
                var result = _mapper.Map<AgentGetDTO>(agent);
                return result;
            }
            return null;          
        }
    }
}
