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

namespace Application.UseCases.Owners.Queries
{
    public class GetOwnerByIdQuery : IRequest<OwnerGetDTO>
    {
        public Guid Id { get; set; }
    }
    public class GetOwnerByIdQueryHandler : IRequestHandler<GetOwnerByIdQuery, OwnerGetDTO>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetOwnerByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
               => (_context, _mapper) = (context, mapper);


        public async Task<OwnerGetDTO> Handle(GetOwnerByIdQuery request, CancellationToken cancellationToken)
        {
            Owner? entity = await _context.Owners.FindAsync(new object[] { request.Id }, cancellationToken);
            if (entity != null)
            {
                var result = _mapper.Map<OwnerGetDTO>(entity);
                return result;
            }
            return null;
        }
    }
}
