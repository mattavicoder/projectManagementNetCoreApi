using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain;

namespace Application.AutoMapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Activity, Activity>();
            CreateMap<Domain.Project, Domain.Project>();
            //CreateMap<Domain.User, Domain.User>();
            CreateMap<UserTasks, UserTasks>();
        }
    }
}