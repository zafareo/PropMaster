using Application.Common.Abstraction;
using Application.Common.DTO;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Owners.Queries
{
    public class GetAllOwnersQuery : IRequest<IQueryable<OwnerGetDTO>>
    {
    }
    public class GetAllOwnersQueryHandler : IRequestHandler<GetAllOwnersQuery, IQueryable<OwnerGetDTO>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllOwnersQueryHandler(IApplicationDbContext context, IMapper mapper)
               => (_context, _mapper) = (context, mapper);


        public async Task<IQueryable<OwnerGetDTO>> Handle(GetAllOwnersQuery request, CancellationToken cancellationToken)
        {
            var entities = _context.Owners;
            var result = _mapper.ProjectTo<OwnerGetDTO>(entities);
            return await Task.FromResult(result);

        }
    }
}
