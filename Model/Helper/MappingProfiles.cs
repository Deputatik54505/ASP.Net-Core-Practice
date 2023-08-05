using AutoMapper;
using Model.Dto;
using Model.models;

namespace Model.Helper
{
    /// <summary>
    /// Mapper
    /// create mapping between entities and their DTOs
    /// </summary>
    internal class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Animal, AnimalDto>();
            CreateMap<AnimalDto, Animal>();

            CreateMap<Cell, CellDto>();
            CreateMap<CellDto, Cell>();

            CreateMap<Meal, MealDto>();
            CreateMap<MealDto, Meal>();

            CreateMap<Zookeeper,ZookeeperDto>();
            CreateMap<ZookeeperDto, Zookeeper>();
        }
    }
}
