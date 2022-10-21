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
        
        [HttpPost]
        public void AdicionaFilme([FromBody]Filme filme)
        {
            Filmes.Add(filme);
            System.Console.WriteLine($"Filme {filme.Titulo}");
        }
    }
}
