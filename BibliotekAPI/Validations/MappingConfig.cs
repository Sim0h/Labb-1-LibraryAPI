using AutoMapper;
using LibraryAPI.Models;
using LibraryAPI.Models.DTO;

namespace LibraryAPI.Validations
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Library, LibraryCreateDTO>().ReverseMap();
            CreateMap<Library, LibraryUpdateDTO>().ReverseMap();
            CreateMap<Library, LibraryDTO>().ReverseMap();
        }
    }
}
