using System;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using System.Linq;
using FilmesAPI.Data;
using FilmesAPI.Data.DTOs;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private FilmeContext _context;

        public FilmeController(FilmeContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto)
        {
            Filme filme = new Filme { 
                Titulo = filmeDto.Titulo,
                Genero = filmeDto.Genero,
                Duracao = filmeDto.Duracao,
                Diretor = filmeDto.Diretor,
            };
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
                ReadFilmeDto filmeDto = new ReadFilmeDto
                {
                    Id = filme.Id,
                    Titulo = filme.Titulo,
                    Diretor = filme.Diretor,
                    Genero = filme.Genero,
                    Duracao = filme.Duracao,
                    HoraDaConsulta = DateTime.Now
                };
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
            filme.Titulo = FilmeDto.Titulo;
            filme.Genero = FilmeDto.Genero;
            filme.Duracao = FilmeDto.Duracao;
            filme.Diretor = FilmeDto.Diretor;
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
