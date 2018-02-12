using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUDEmpresa.EntityFramework;

namespace CRUDEmpresa.DAO.Detall
{
    class DetallDAOImpl : DetallDAO
    {
        public void BorrarDetall(int id)
        {
            using (var context = new dbempresaEntities())
            {
                try
                {
                    factura_detall fac = context.factura_detall.First(i => i.id_factura_detall == id);
                    context.factura_detall.Remove(fac);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
            }
        }

        public void CrearDetall(factura_detall f)
        {
            using (var context = new dbempresaEntities())
            {
                context.factura_detall.Add(f);
                context.SaveChanges();
            }
        }

        public List<factura_detall> LeerDetall()
        {
            using (var context = new dbempresaEntities())
            {
                return context.factura_detall.ToList();
            }
        }

        public factura_detall LeerDetall(int id)
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
