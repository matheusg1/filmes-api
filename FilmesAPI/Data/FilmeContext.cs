using FilmesAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FilmesAPI.Data
{
    public class FilmeContext : DbContext
    {
        public FilmeContext(DbContextOptions<FilmeContext> opt) : base(opt)
        {
        }
        public DbSet<Filme> Filmes { get; set; }
    }
}
