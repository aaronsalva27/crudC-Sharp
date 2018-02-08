using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUDEmpresa.EntityFramework;

namespace CRUDEmpresa.DAO.Cliente
{
    class ClienteDAOImpl : ClienteDAO
    {
        public void BorrarCliente(int id)
        {
            using (var context = new dbempresaEntities())
            {
                try
                {
                    clients clt = context.clients.First(i => i.id_client == id);
                    context.clients.Remove(clt);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
            }
        }

        public void CrearCliente(clients c)
        {
            using (var context = new dbempresaEntities())
            {
                context.clients.Add(c);
                context.SaveChanges();
            }
        }

        public List<clients> LeerCliente()
        {
            using (var context = new dbempresaEntities())
            {
                return context.clients.ToList();
            }
        }

        public clients LeerCliente(int id)
        {
            //Querying with LINQ to Entities 
            using (var context = new dbempresaEntities())
            {
                return context.clients
                                   .Where(s => s.id_client == id)
                                   .FirstOrDefault();
            }
        }
    }
}
