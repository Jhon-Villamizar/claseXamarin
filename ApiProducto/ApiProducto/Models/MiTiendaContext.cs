using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ApiProducto.Models
{
    public class MiTiendaContext : DbContext
    {
        public MiTiendaContext() : base("MiTiendaConnection")
        {
            
        }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
    }
}