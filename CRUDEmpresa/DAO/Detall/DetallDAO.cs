using CRUDEmpresa.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDEmpresa.DAO.Detall
{
    interface DetallDAO
    {
        void CrearDetall(factura_detall f);

        void BorrarDetall(int id);

        List<factura_detall> LeerDetall();

        factura_detall LeerDetall(int id);
    }
}
