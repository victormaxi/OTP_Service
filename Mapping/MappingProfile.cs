using AutoMapper;
using OTP_Application.Models;
using OTP_Application.ViewModels;

namespace OTP_Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserRegistrationVM, User>()
                .ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Email));
        }
    }
}
