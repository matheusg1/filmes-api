using AutoMapper;
using FilmesAPI.Data.DTOs;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles
{
    public class FilmeProfile : Profile
    {
        public FilmeProfile()
        {
            CreateMap<CreateFilmeDto, Filme>(); //Ao criar o objeto, o Id não é passado
            CreateMap<Filme, ReadFilmeDto>();   //Na leitura do filme, o Id não é mostrado
            CreateMap<UpdateFilmeDto, Filme>(); //Na alteração o Id também não é passado
        }
    }
}
