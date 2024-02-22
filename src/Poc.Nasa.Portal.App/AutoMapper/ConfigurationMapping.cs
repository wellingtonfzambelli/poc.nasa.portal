using AutoMapper;
using Poc.Nasa.Portal.App.Nasa.AstronomyPicture.GetPictureOfTheDay;
using Poc.Nasa.Portal.Domain.Models.PictureOfTheDayAggregate;
using Poc.Nasa.Portal.Integration.NasaPortal;

namespace Poc.Nasa.Portal.App.AutoMapper;

public sealed class ConfigurationMapping : Profile
{
    public ConfigurationMapping()
    {
        CreateMap<GetPictureOfTheDayResponseClientDto, AstronomyPictureOfTheDayResponseDto>()
            .ForMember(dest => dest.Hdurl, opt => opt.MapFrom(src => src.Hdurl))
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
            .ForMember(dest => dest.Copyright, opt => opt.MapFrom(src => src.Copyright))
            .ForMember(dest => dest.Explanation, opt => opt.MapFrom(src => src.Explanation))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Url, opt => opt.MapFrom(src => src.Url));

        CreateMap<PictureOfTheDay, AstronomyPictureOfTheDayResponseDto>()
            .ForMember(dest => dest.Hdurl, opt => opt.MapFrom(src => src.HdUrl))
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.PictureDate))
            .ForMember(dest => dest.Copyright, opt => opt.MapFrom(src => src.Copyright))
            .ForMember(dest => dest.Explanation, opt => opt.MapFrom(src => src.Explanation))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Url, opt => opt.MapFrom(src => src.Url));
    }
}