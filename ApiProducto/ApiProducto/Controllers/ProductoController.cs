using ApiProducto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiProducto.Controllers
{
    public class ProductoController : ApiController
    {
        [HttpGet]
        public IEnumerable<Producto> Get()
        {
            using (var context = new MiTiendaContext())
            {
                return context.Productos.ToList();
            }
        }

        [HttpGet]
        public Producto Get(int id)
        {
            using (var context = new MiTiendaContext())
            {
                return context.Productos.FirstOrDefault(x=> x.Id == id);
            }
        }

        [HttpPost]
        public Producto Post (Producto producto)
        {
            using (var context = new MiTiendaContext())
            {
                context.Productos.Add(producto);
                context.SaveChanges();
                return producto;
            }
        }

        [HttpPut]
        public Producto Put(Producto producto)
        {
            using (var context = new MiTiendaContext())
            {
                var productoAct = context.Productos.FirstOrDefault(x => x.Id == producto.Id);
                productoAct.Cantidad = producto.Cantidad;
                productoAct.Descripcion = producto.Descripcion;
                productoAct.Nombre = producto.Nombre;
                productoAct.Imagen = producto.Imagen;
                
                context.SaveChanges();
                return producto;
            }
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            using (var context = new MiTiendaContext())
            {
                var productoDel = context.Productos.FirstOrDefault(x => x.Id == id);
                context.Productos.Remove(productoDel);
                context.SaveChanges();
                return true;
            }
        }
    }
}
