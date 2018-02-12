using CRUDEmpresa.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDEmpresa.DAO.Producto
{
    /// <summary>
    /// Interpaz de que declara los métodos para hacer una crud sobre el objeto de la clase productes
    /// </summary>
    interface ProdutoDAO
    {
        void CrearProducto(productes p);

        void BorrarProducto(int id);

        List<productes> LeerProdutos();

        productes LeerProducto(int id);
    }
}
