using AutoMapper;
using WebApiTutorial.DTO;
using WebApiTutorial.Models;

namespace WebApiTutorial.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Pokemon, PokemonDTO>();
            CreateMap<Category, CategoryDTO>();
            CreateMap<Country, CountryDTO>();
        }
    }
}
