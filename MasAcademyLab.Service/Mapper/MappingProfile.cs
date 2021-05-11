using AutoMapper;
using MasAcademyLab.Domain;
using MasAcademyLab.Service.Models;

namespace MasAcademyLab.Service.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Speaker, SpeakerModel>().ReverseMap();
            CreateMap<Talk, TalkModel>()
                .ReverseMap()
                .ForMember(t => t.Training, opt => opt.Ignore())
                .ForMember(t => t.Speaker, opt => opt.Ignore());

            CreateMap<Location, LocationModel>().ReverseMap();
            CreateMap<Training, TrainingModel>().ReverseMap();
            CreateMap<TrainingCreationModel, Training>();
            CreateMap<TrainingUpdateModel, Training>().ReverseMap();           
            CreateMap<TalkCreationModel, Talk>();
            CreateMap<TalkUpdateModel, Talk>();            
        }           
    }
}
