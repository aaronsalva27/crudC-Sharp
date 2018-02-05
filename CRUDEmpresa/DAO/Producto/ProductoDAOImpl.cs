using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRUDEmpresa.EntityFramework;

namespace CRUDEmpresa.DAO.Producto
{
    class ProductoDAOImpl : ProdutoDAO
    {
        public void CrearProducto(productes p)
        {
            //Querying with LINQ to Entities 
            using (var context = new dbempresaEntities())
            {
                context.productes.Add(p);
                context.SaveChanges();
            }
        }

        public void BorrarProducto(int id)
        {
            using (var context = new dbempresaEntities())
            {
                try
                {
                    productes prod = context.productes.First(i => i.id_produte == id);
                    context.productes.Remove(prod);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                }
            }
        }

        public productes LeerProducto(int id)
        {
            //Querying with LINQ to Entities 
            using (var context = new dbempresaEntities())
            {
                return context.productes
                                   .Where(s => s.id_produte == id)
                                   .FirstOrDefault();
            }
        }

        public List<productes> LeerProdutos()
        {
            using (var context = new dbempresaEntities())
            {
                return context.productes.ToList();
            }
        }


    }
}
