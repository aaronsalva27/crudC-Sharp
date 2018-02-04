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
            throw new NotImplementedException();
        }

        public productes LeerProducto(int id)
        {
            //Querying with LINQ to Entities 
            using (var context = new dbempresaEntities())
            {
                return  context.productes
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
