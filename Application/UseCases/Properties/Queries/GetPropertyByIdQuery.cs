using Application.Common.Abstraction;
using Application.Common.DTO;
using Application.UseCases.Roles.Queries;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Properties.Queries
{
    public class GetPropertyByIdQuery : IRequest<PropertyGetDTO>
    {
        public Guid Id { get; set; }
    }
    public class GetByIdPropertyQueryHandler : IRequestHandler<GetPropertyByIdQuery, PropertyGetDTO>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetByIdPropertyQueryHandler(IApplicationDbContext context, IMapper mapper)
               => (_context, _mapper) = (context, mapper);


        public async Task<PropertyGetDTO> Handle(GetPropertyByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Properties.FindAsync(new object[] { request.Id }, cancellationToken);
            if (entity != null)
            {
                var result = _mapper.Map<PropertyGetDTO>(entity);
                return result;
            }
            return null;
        }
    }

}

