using AutoMapper;
using Checkpoint.Model;
using CheckpointAPI.Data.DTOs;

namespace CheckpointAPI.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreatePokemonDto, Pokemon>();
            CreateMap<UpdatePokemonDto, Pokemon>();
            CreateMap<Pokemon, UpdatePokemonDto>();
            CreateMap<Pokemon, ReadPokemonDto>();
        }
    }
}
