using CRUDEmpresa.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDEmpresa.DAO.Cliente
{
    interface ClienteDAO
    {
        void CrearCliente(clients c);

        void BorrarCliente(int id);

        List<clients> LeerCliente();

        clients LeerCliente(int id);
    }
}
