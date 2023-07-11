using Application.Common.Abstraction;
using Application.Common.DTO;
using AutoMapper;
using MediatR;

namespace Application.UseCases.Properties.Queries
{
    public class GetAllPropertiesQuery : IRequest<IQueryable<PropertyGetDTO>>
    {
    }
    public class GetAllPropertiesQueryHandler : IRequestHandler<GetAllPropertiesQuery, IQueryable<PropertyGetDTO>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetAllPropertiesQueryHandler(IApplicationDbContext context, IMapper mapper)
              => (_context, _mapper) = (context, mapper);
        public async Task<IQueryable<PropertyGetDTO>> Handle(GetAllPropertiesQuery request, CancellationToken cancellationToken)
        {
            var entities = _context.Properties;
            var result = _mapper.ProjectTo<PropertyGetDTO>(entities);
            return await Task.FromResult(result);
        }
    }
}
