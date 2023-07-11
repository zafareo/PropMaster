using Application.Common.Abstraction;
using Application.Common.DTO;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Agents.Queries
{
    public class GetAllAgentQuery : IRequest<IQueryable<AgentGetDTO>>
    {

    }
    public class GetAllAgentQueryHandler : IRequestHandler<GetAllAgentQuery, IQueryable<AgentGetDTO>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetAllAgentQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IQueryable<AgentGetDTO>> Handle(GetAllAgentQuery request, CancellationToken cancellationToken)
        {
            var entities = _context.Agents;
            var result = _mapper.ProjectTo<AgentGetDTO>(entities);
            return await Task.FromResult(result);
        }
    }
}
