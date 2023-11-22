using AutoMapper;
using STap2Go_Licenses.DTOs;
using STap2Go_Licenses.Entities;

namespace STap2Go_Licenses.Configuration;

public class LicensesMapperConfig : Profile
{
    public LicensesMapperConfig()
    {
        // Clients
        CreateMap<ClientReadDTO, Client>().ReverseMap();
        CreateMap<ClientCreateDTO, Client>().ReverseMap();
        
        // Licenses
        CreateMap<LicenseReadDTO, License>().ReverseMap();
    }
}