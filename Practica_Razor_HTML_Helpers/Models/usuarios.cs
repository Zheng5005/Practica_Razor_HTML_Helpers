using System.ComponentModel.DataAnnotations;

namespace Practica_Razor_HTML_Helpers.Models
{
    public class usuarios
    {
        [Key]
        public int id_usuario { get; set; }
        public string? nombre { get; set; }
        public string? password { get; set; }
        public string? genero { get; set; }
        public string? direccion { get; set; }
        public string? Pasatiempos { get; set; }
        public string? cursos { get; set; }
        public string? Conocimientos { get; set; }
    }
}
