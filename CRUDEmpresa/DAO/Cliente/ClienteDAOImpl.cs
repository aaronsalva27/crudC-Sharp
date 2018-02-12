using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUDEmpresa.EntityFramework;

namespace CRUDEmpresa.DAO.Cliente
{
    /// <summary>  
    /// Clase que implementa los métodos para hacer un crud sobre el objeto Cliente
    /// </summary>  
    class ClienteDAOImpl : ClienteDAO
    {
        /// <summary>
        /// Elimina un CLiente</summary>
        /// <param name="id"> Variable que representa la id del Cliente que queremos eliminar</param>
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

        /// <summary>
        /// Crea un nuevo usuario</summary>
        ///  <returns>
        ///  Devuelve una lista de clientes</returns>
        public void CrearCliente(clients c)
        {
            using (var context = new dbempresaEntities())
            {
                context.clients.Add(c);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Devuelve una lista con los clientes</summary>
        /// <returns>Devuelve una lista de clientes</returns>
        /// 
        public List<clients> LeerCliente()
        {
            using (var context = new dbempresaEntities())
            {
                return context.clients.ToList();
            }
        }

        /// <summary>
        /// Devuelve un cliente
        /// </summary>
        /// <param name="id">id del cliente que queremos recuperar</param>
        /// <returns>Devuelve un objeto cliente</returns>
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
