using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUDEmpresa.EntityFramework;

namespace CRUDEmpresa.DAO.FacturaDetall

{
    class FacturaDetallDAOImpl : FacturaDetallDAO
    {
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

        public void CrearFacturaDetall(factura_detall f)
        {
            using (var context = new dbempresaEntities())
            {
                context.factura_detall.Add(f);
                context.SaveChanges();
            }
        }

        public List<factura_detall> LeerFacturasDetall()
        {
            using (var context = new dbempresaEntities())
            {
                return context.factura_detall.ToList();
            }
        }

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
