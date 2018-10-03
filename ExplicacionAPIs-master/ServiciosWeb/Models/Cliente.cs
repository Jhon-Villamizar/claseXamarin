using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ServiciosWeb.Models
{
    [Table("Cliente")]
    public class Cliente
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Nombres { get; set; }

        [MaxLength(50)]
        [Required]
        public string Apellidos { get; set; }

        [MaxLength(20)]
        public string Direccion { get; set; }

        [MaxLength(10)]
        [Required]
        public string Celular { get; set; }

        [MaxLength(1)]
        [Required]
        public string Estrato { get; set; }

        public DateTime FechaNacimiento { get; set; }
    }
}