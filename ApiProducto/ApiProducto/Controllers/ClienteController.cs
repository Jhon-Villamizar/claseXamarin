using ApiProducto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiProducto.Controllers
{
    public class ClienteController : ApiController
    {
        [HttpGet]
        public IEnumerable<Cliente> Get()
        {
            using (var context = new MiTiendaContext())
            {
                return context.Clientes.ToList();
            }
        }

        [HttpGet]
        public Cliente Get(string Nombres)
        {
            using (var context = new MiTiendaContext())
            {
                return context.Clientes.FirstOrDefault(x=> x.Nombres == Nombres);
            }
        }

        [HttpPost]
        public Cliente Post(Cliente cliente)
        {
            using (var context = new MiTiendaContext())
            {
                context.Clientes.Add(cliente);
                context.SaveChanges();
                return cliente;
            }
        }

        [HttpPut]
        public Cliente Put(Cliente cliente)
        {
            using( var context = new MiTiendaContext())
            {
                var clienteAct = context.Clientes.FirstOrDefault(x => x.id == cliente.id);
                clienteAct.Nombres = cliente.Nombres;
                clienteAct.apellidos = cliente.apellidos;
                clienteAct.Direccion = cliente.Direccion;
                clienteAct.Celular = cliente.Celular;
                clienteAct.Estracto = cliente.Estracto;
                clienteAct.FechaNacimiento = cliente.FechaNacimiento;
                context.SaveChanges();
                return cliente;
            }
        }

        [HttpDelete]
        public bool Delete(string Nombres)
        {
            using (var context = new MiTiendaContext())
            {
                var clienteDel = context.Clientes.FirstOrDefault(x => x.Nombres == Nombres);
                context.Clientes.Remove(clienteDel);
                context.SaveChanges();
                return true;

            }
        }
    }
}
