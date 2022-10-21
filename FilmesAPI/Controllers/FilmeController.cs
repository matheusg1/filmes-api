using System;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController
    {
        private static List<Filme> Filmes = new();
        private static int id = 0;

        [HttpPost]
        public void AdicionaFilme([FromBody]Filme filme)
        {
            filme.Id = id++;
            Filmes.Add(filme);
            Console.WriteLine($"Filme {filme.Titulo}");
        }
        
        [HttpGet]
        public IEnumerable<Filme> VerFilmes()
        {
            return Filmes;
        }
    }
}
