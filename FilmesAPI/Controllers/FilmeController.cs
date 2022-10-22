using System;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using System.Linq;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private static List<Filme> filmes = new();
        private static int id = 0;

        [HttpPost]
        public IActionResult AdicionaFilme([FromBody]Filme filme)
        {
            filme.Id = ++id;
            filmes.Add(filme);
            Console.WriteLine($"Filme {filme.Titulo}");
            return (CreatedAtAction(nameof(BuscaFilmesPorId), new { Id = filme.Id }, filme));   //retorna o filme na hora da criação
        }
        
        [HttpGet]
        public IActionResult BuscaTodosFilmes()
        {
            return Ok(filmes);
        }

        [HttpGet("{id}")]
        public IActionResult BuscaFilmesPorId(int id)
        {
            Filme filme =  filmes.FirstOrDefault(f => f.Id == id);
            if (filme != null)
            {
                return Ok(filme);
            }
            return NotFound("Id Não encontrado");
        }
    }
}
