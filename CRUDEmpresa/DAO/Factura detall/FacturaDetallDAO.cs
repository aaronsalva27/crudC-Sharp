using CRUDEmpresa.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDEmpresa.DAO.FacturaDetall
{
    interface FacturaDetallDAO
    {
        void CrearFacturaDetall(factura_detall c);

        void BorrarFacturaDetall(int id);

        List<factura_detall> LeerFacturasDetall();

        factura_detall LeerFacturaDetall(int id);
    }
}
