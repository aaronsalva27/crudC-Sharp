using CRUDEmpresa.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDEmpresa.DAO.Cliente
{
    /// <summary>  
    ///  Interficie donde definimos los metodos para hacer un crud sobre el objeto cliente
    /// </summary>  
    interface ClienteDAO
    {
        void CrearCliente(clients c);

        void BorrarCliente(int id);

        List<clients> LeerCliente();

        clients LeerCliente(int id);
    }
}
