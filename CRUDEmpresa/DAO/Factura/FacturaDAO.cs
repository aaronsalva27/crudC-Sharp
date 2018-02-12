using CRUDEmpresa.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDEmpresa.DAO.Factura
{
    interface FacturaDAO
    {

        void CrearFactura(factura c);

        void BorrarFactura(int id);

        List<factura> LeerFacturas();


        factura LeerFactura(int id);
    }
}
