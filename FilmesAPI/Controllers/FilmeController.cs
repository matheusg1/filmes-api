using System;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using System.Linq;
using FilmesAPI.Data;

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
        public IActionResult AdicionaFilme([FromBody] Filme filme)
        {
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
                return Ok(filme);
            }
            return NotFound("Id não encontrado");
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaFilme(int id, [FromBody] Filme filmeNovo)
        {
            Filme filme = _context.Filmes.FirstOrDefault(f => f.Id.Equals(id));
            if (filme == null)
            {
                return NotFound("Id não encontrado");
            }
            filme.Titulo = filmeNovo.Titulo;
            filme.Genero = filmeNovo.Genero;
            filme.Duracao = filmeNovo.Duracao;
            filme.Diretor = filmeNovo.Diretor;
            _context.Update(filme);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaFilme(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(f => f.Id == id);
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
