using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUDEmpresa.EntityFramework;

namespace CRUDEmpresa.DAO.Factura
{
    class FacturaDAOImpl : FacturaDAO
    {
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

        public void CrearFactura(factura f)
        {
            using (var context = new dbempresaEntities())
            {
                context.factura.Add(f);
                context.SaveChanges();
            }
        }

        public List<factura> LeerFactura()
        {
            using (var context = new dbempresaEntities())
            {
                return context.factura.ToList();
            }
        }

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
