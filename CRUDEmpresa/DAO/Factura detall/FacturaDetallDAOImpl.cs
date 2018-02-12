using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUDEmpresa.EntityFramework;

namespace CRUDEmpresa.DAO.FacturaDetall

{
    /// <summary>
    /// Clase que implementa los métoodos para hacer un crud sobre el objeto factura_detall
    /// </summary>
    class FacturaDetallDAOImpl : FacturaDetallDAO
    {
        /// <summary>
        /// Borra una factura_detall
        /// </summary>
        /// <param name="id">id del objeto que se quiere borrar</param>
        public void BorrarFacturaDetall(int id)
        {
            using (var context = new dbempresaEntities())
            {
                try
                {
                   factura_detall fact = context.factura_detall.First(i => i.id_factura_detall == id);
                    context.factura_detall.Remove(fact);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
            }
        }

        /// <summary>
        /// Método que crea un nuevo objeto factura detall.
        /// </summary>
        /// <param name="f">objeto que se quiere crear</param>
        public void CrearFacturaDetall(factura_detall f)
        {
            using (var context = new dbempresaEntities())
            {
                context.factura_detall.Add(f);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Método que devuelve una lista de factura_detall
        /// </summary>
        /// <returns>Devuelve una lista de factura_detall</returns>
        public List<factura_detall> LeerFacturasDetall()
        {
            using (var context = new dbempresaEntities())
            {
                return context.factura_detall.ToList();
            }
        }

        /// <summary>
        /// Devuelve un objeto factura_detall
        /// </summary>
        /// <param name="id">id del objeto que se quiere recuperar</param>
        /// <returns>objeto factura_detall</returns>
        public factura_detall LeerFacturaDetall(int id)
        {
            //Querying with LINQ to Entities 
            using (var context = new dbempresaEntities())
            {
                return context.factura_detall
                                   .Where(s => s.id_factura_detall == id)
                                   .FirstOrDefault();
            }
        }
    }
}
