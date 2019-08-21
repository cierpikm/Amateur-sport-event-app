using AutoMapper;
using ServerCode.Model.DTOs;
using ServerCode.Model.DTOs.ChatDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCode.Model.Mappings
{
    public class MappingAdvertisement: Profile
    {
        public MappingAdvertisement()
        {
            CreateMap<User, UserDTO>();
            CreateMap<Advertisement, AdvertisementDTO>()
                .ForMember(c=> c.EagerMembers, o=> o.MapFrom(c=>c.EagerMembers.Select(d=>d.User)))
                .ForMember(c => c.UserDTO, o => o.MapFrom(d => d.User));
            CreateMap<User, UserProfileDTO>();
            CreateMap<Event, EventDTO>();
            CreateMap<User, UserChatDTO>();
            CreateMap<Message, MessageDTO>()
                .ForMember(c => c.Reciver, o => o.MapFrom(d => d.Reciver))
                .ForMember(c => c.Sender, o => o.MapFrom(d => d.Sender));
            CreateMap<Chat, ChatDTO>()
                .ForMember(c => c.Owner, o => o.MapFrom(d => d.Owner))
                .ForMember(c => c.Reciver, o => o.MapFrom(d => d.Reciver))
                .ForMember(c => c.Messages, o => o.MapFrom(c => c.Messages));
            CreateMap<Advertisement, Advertisement>()
               .ForMember(c => c.Id, o => o.Ignore())
               .ForMember(c => c.Localization, o => o.Ignore())

               .ForMember(c => c.UserId, o => o.Ignore())
               ;
        }
    }
}
