using CRUDEmpresa.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDEmpresa.DAO.Factura
{
    /// <summary>
    ///  Interficie con la declaracion de los métodos para hacer un crud sobre el objeto Factura.
    /// </summary>
    interface FacturaDAO
    {

        void CrearFactura(factura c);

        void BorrarFactura(int id);

        List<factura> LeerFacturas();


        factura LeerFactura(int id);
    }
}
