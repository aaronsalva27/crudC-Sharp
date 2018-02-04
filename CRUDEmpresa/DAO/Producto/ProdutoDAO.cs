using CRUDEmpresa.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDEmpresa.DAO.Producto
{
    interface ProdutoDAO
    {
        void CrearProducto(productes p);

        List<productes> LeerProdutos();

        productes LeerProducto(int id);
    }
}
