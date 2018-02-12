using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRUDEmpresa.EntityFramework;

namespace CRUDEmpresa.DAO.Producto
{
    /// <summary>
    /// Clase que implementa los métodos para hacer un crud sobre el objeto productes
    /// </summary>
    class ProductoDAOImpl : ProdutoDAO
    {
        /// <summary>
        /// Crea un nuevo objeto producto
        /// </summary>
        /// <param name="p">objeto producto que se quiere guadar</param>
        public void CrearProducto(productes p)
        {
            //Querying with LINQ to Entities 
            using (var context = new dbempresaEntities())
            {
                context.productes.Add(p);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Método que elimina un registro de la base de datos
        /// </summary>
        /// <param name="id">id del producto que se quiere borrar</param>
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

        /// <summary>
        /// Método que recuperar una entrada de la base de datos
        /// </summary>
        /// <param name="id">id del objeto que queremos recuperar</param>
        /// <returns>devuelve un objeto productes</returns>

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

        /// <summary>
        /// Método que recupera todas las entradas de la base de datos
        /// </summary>
        /// <returns>Devuele una lista con todos los productos</returns>
        public List<productes> LeerProdutos()
        {
            using (var context = new dbempresaEntities())
            {
                return context.productes.ToList();
            }
        }


    }
}
