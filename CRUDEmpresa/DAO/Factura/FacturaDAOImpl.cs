using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUDEmpresa.EntityFramework;

namespace CRUDEmpresa.DAO.Factura

{
    /// <summary>
    /// Clase que implementa los métodos para hacer un crud sobre el objeto Factura
    /// </summary>
    class FacturaDAOImpl : FacturaDAO
    {
        /// <summary>
        /// Método que borra una Factura
        /// </summary>
        /// <param name="id">id de la factura que se quiere borrar</param>
        public void BorrarFactura(int id)
        {
            using (var context = new dbempresaEntities())
            {
                try
                {

                    factura fac = context.factura.First(i => i.n_factura == id);
                    context.factura.Remove(fac);

                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
            }
        }

        /// <summary>
        /// Método que crea una factura
        /// </summary>
        /// <param name="f">objeto factura que se quiere crear</param>
        public void CrearFactura(factura f)
        {
            using (var context = new dbempresaEntities())
            {
                context.factura.Add(f);
                context.SaveChanges();
            }
        }


        /// <summary>
        /// Método que devuelve una lista de facturas
        /// </summary>
        /// <returns>Devuelve una lista de facturas</returns>
        public List<factura> LeerFacturas()

        {
            using (var context = new dbempresaEntities())
            {
                return context.factura.ToList();
            }
        }

        /// <summary>
        /// Devuelve una factura
        /// </summary>
        /// <param name="id">id de la factura que se quiere buscar</param>
        /// <returns></returns>
        public factura LeerFactura(int id)
        {
            //Querying with LINQ to Entities 
            using (var context = new dbempresaEntities())
            {
                return context.factura
                                   .Where(s => s.n_factura == id)
                                   .FirstOrDefault();
            }
        }
    }
}
