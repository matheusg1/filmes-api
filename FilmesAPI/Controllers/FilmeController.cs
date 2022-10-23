using System;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using System.Linq;
using FilmesAPI.Data;
using FilmesAPI.Data.DTOs;
using AutoMapper;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public FilmeController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto)
        {
            Filme filme = _mapper.Map<Filme>(filmeDto);
            _context.Add(filme);
            _context.SaveChanges();
            return (CreatedAtAction(nameof(BuscaFilmesPorId), new { Id = filme.Id }, filme));   //retorna o filme na hora da criação
        }

        [HttpGet]
        public IActionResult BuscaTodosFilmes()
        {
            return Ok(_context.Filmes);
        }

        [HttpGet("{id}")]
        public IActionResult BuscaFilmesPorId(int id)
        {
           
            Filme filme = _context.Filmes.FirstOrDefault(f => f.Id.Equals(id));
            if (filme != null)
            {
                ReadFilmeDto filmeDto = _mapper.Map<ReadFilmeDto>(filme); 
                return Ok(filmeDto);
            }
            return NotFound("Id não encontrado");
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDto FilmeDto)
        {
            Filme filme = _context.Filmes.FirstOrDefault(f => f.Id.Equals(id));
            if (filme == null)
            {
                return NotFound("Id não encontrado");
            }

            _mapper.Map(FilmeDto, filme);
            _context.Update(filme);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaFilme(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(f => f.Id.Equals(id));
            if (filme == null)
            {
                return NotFound("Id não encontrado");
            }
            _context.Filmes.Remove(filme);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
