using ServiciosWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServiciosWeb.Controllers
{
    public class ProductoController : ApiController
    {
        [HttpGet]
        public IEnumerable<Producto> Get()
        {
            using (var context = new ProductoContext())
            {
                return context.Productos.ToList();
            }
        }

        [HttpGet]
        public Producto Get(int id)
        {
            using (var context = new ProductoContext())
            {
                return context.Productos.FirstOrDefault(x=> x.Id == id);
            }
        }

        [HttpPost]
        public Producto Post(Producto producto)
        {
            using (var context = new ProductoContext())
            {
                context.Productos.Add(producto);
                context.SaveChanges();
                return producto;
            }
        }

        [HttpPut]
        public Producto Put(Producto producto)
        {
            using (var context = new ProductoContext())
            {
                var productoActualizar = context.Productos.FirstOrDefault(x => x.Id == producto.Id);
                productoActualizar.Cantidad = producto.Cantidad;
                productoActualizar.Descripcion = producto.Descripcion;
                productoActualizar.Imagen = producto.Imagen;
                productoActualizar.Nombre = producto.Nombre;
                context.SaveChanges();
                return producto;
            }
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            using (var context = new ProductoContext())
            {
                var productoEliminar = context.Productos.FirstOrDefault(x => x.Id == id);
                context.Productos.Remove(productoEliminar);
                context.SaveChanges();
                return true;
            }
        }
    }
}
