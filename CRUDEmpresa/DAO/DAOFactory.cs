using CRUDEmpresa.DAO.Cliente;
using CRUDEmpresa.DAO.Producto;
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
        private ProdutoDAO ProducteBean = null;
        private ClienteDAO ClientBean = null;


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

        /**
         * Metodo que devuelve la instancia de la clase UsuarioDAOImpl
         * @return EmplatBean
         */
        public ProdutoDAO getProductoDAO()
        {
            if (this.ProducteBean == null)
            {
                ProducteBean = new ProductoDAOImpl();
            }
            return ProducteBean;
        }

        public ClienteDAO getClienteDAO()
        {
            if (this.ClientBean == null)
            {
                ClientBean = new ClienteDAOImpl();
            }
            return ClientBean;
        }

    }
}
