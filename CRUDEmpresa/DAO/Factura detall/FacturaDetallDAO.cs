using CRUDEmpresa.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDEmpresa.DAO.FacturaDetall
{
    /// <summary>
    /// Interpaz que declara los métodos para hacer un crud sobre el objeto Factura_detall
    /// </summary>
    interface FacturaDetallDAO
    {
        void CrearFacturaDetall(factura_detall c);

        void BorrarFacturaDetall(int id);

        List<factura_detall> LeerFacturasDetall();

        factura_detall LeerFacturaDetall(int id);
    }
}
