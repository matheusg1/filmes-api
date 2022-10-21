using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models
{
    public class Filme
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Diretor { get; set; }
        public string Genero { get; set; }

        [Range(1, 600, ErrorMessage = "A duração é de no mínimo {1} e máximo {2}")]
        public int Duracao { get; set; }
    }
}
