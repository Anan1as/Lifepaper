

using System.ComponentModel.DataAnnotations;

namespace Lifepaper.Models
{
    public class Usuario
    {
        [Key]
        public int UserId { get; set; }
<<<<<<< HEAD
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Correo { get; set; }
        public string? Contraseña { get; set; }
        public DateTime? FechaRegistro { get; set; }
=======
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public DateTime FechaRegistro { get; set; }
>>>>>>> 7dcdd617ab1a6807130e7ecaf8dd89cb2a22c2c5
        public string? GoogleId { get; set; }
        public string? Nacionalidad { get; set; }
    }
}
