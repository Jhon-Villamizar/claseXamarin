using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ApiProducto.Models
{
    [Table("Cliente")]
    public class Cliente
    {
        [Key]
        public int id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Nombres { get; set; }

        [MaxLength(50)]
        [Required]
        public string apellidos { get; set; }

        [MaxLength(20)]
        [Required]
        public string Direccion { get; set; }

        [MaxLength(10)]
        [Required]
        public string Celular { get; set; }

        [MaxLength(1)]
        [Required]
        public string Estracto { get; set; }

        
        [Required]
        public DateTime FechaNacimiento { get; set; }
    }
} 