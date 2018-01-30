using CRUDEmpresa.DAO.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDEmpresa.DAO
{
    class DAOFactory
    {
        /**
     * Conexion
     */
        //private static Connection conn;
        /**
         * Base de datos
         */
        //private static BDAccessor bd = null;
        /**
         * Instancia de la clase UusarioDAO
         */
        private UsuarioDAO EmplatBean = null;
        

        /**
         * Construtor de la clase DAOInstitucio
         */
        public DAOFactory()
        {
            //bd  = new BDAccessor();
            //conn = utils.Constant.getConnexion();

        }

        /**
         * Metodo que devuelve la instancia de la clase UsuarioDAOImpl
         * @return EmplatBean
         */
        public UsuarioDAO getEmpleatDAO()
        {
            if (this.EmplatBean == null)
            {
                //EmplatBean = new UsuarioDAOImpl(conn);
            }
            return EmplatBean;
        }
        
    }
}
