using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDEmpresa.DAO.Usuario
{
    interface UsuarioDAO
    {
        /**
         * inserta un usuario en la bd
         * @param a Cliente
         * @throws SQLException 
         */
        void CrearUsuario(Usuario a);
        /**
         * recupera un usuario por la id
         * @param codi
         * @return Cliente
         * @throws SQLException 
         */
        Usuario LeerUsuario(int codi);
    }
}
