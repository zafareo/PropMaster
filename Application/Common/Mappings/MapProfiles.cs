using Application.Common.DTO;
using AutoMapper;
using Domain.Entities;
using Domain.IdentityEntities;

namespace Application.Common.Mappings
{
    public class MapProfiles : Profile
    {
        public MapProfiles()
        {
            CreateMap<AgentGetDTO, Agent>().ReverseMap();
            CreateMap<PermissionGetDTO, Permission>().ReverseMap();
            CreateMap<PropertyGetDTO, Property>().ReverseMap();
            CreateMap<OwnerGetDTO, Owner>().ReverseMap();
            CreateMap<UserGetDTO, User>().ReverseMap();
            CreateMap<RoleGetDTO, Role>().ReverseMap();
        }
    }
}
