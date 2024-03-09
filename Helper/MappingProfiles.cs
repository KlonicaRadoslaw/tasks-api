using AutoMapper;
using Tasks.Dto;
using Tasks.Models;

namespace Tasks.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<Models.Task, TaskDto>();
            CreateMap<TaskDto, Models.Task>();
        }
    }
}
