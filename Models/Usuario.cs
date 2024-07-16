using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lifepaper.Models
{
    public class Usuario
    {
        [Key]
        public int UserId { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Correo { get; set; }
        public string? Contraseña { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public string? GoogleId { get; set; }
        public string? Nacionalidad { get; set; }
    }
}