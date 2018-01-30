using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDEmpresa.DAO.Usuario
{
    class UsuarioDAOImpl : UsuarioDAO
    {
        /**
        * sentencia mysql para insertar un usuario
        */
        String INSERT = "INSERT INTO Usuario(idInstitucion,username,password,DNI,nombre,apellidos,edad,telefono,email,rol) VALUES(?,?,?,?,?,?,?,?,?,?)";
        /**
         * sentencia mysql para actualizar un usuario
         */
        String UPDATE = "UPDATE empleat SET nom = ?, dataContracte= ? WHERE nom= ?";
        /**
         * sentencia mysql para eliminar un usuario
         */
        String DELETE = "DELETE FROM empleat WHERE id = ?";
        /**
         * sentencia mysql que devuelve todos los usuarios de la tabla
         */
        String GETALL = "SELECT * from Usuario";
        /**
         * sentencia mysql que devulve un usuario por la id
         */
        String GETONE = "SELECT * from Usuario where id = ?";
        /**
         * conexión con la bd
         */
        private String conn;

        /**
        * constructor de la clase UsuarioDAOImpl
        * @param conn 
        */
        public UsuarioDAOImpl(String conn)
        {
            this.conn = conn;
        }

        public void CrearUsuario(Usuario a)
        {
            // PreparedStatement stat = null;

            //try
            //{
            //    stat = conn.prepareStatement(INSERT);
            //    stat.setInt(1, a.getIdInstitucio());
            //    stat.setString(2, a.getUsername());
            //    stat.setString(3, a.getPassword());
            //    stat.setString(4, a.getDNI());
            //    stat.setString(5, a.getNombre());
            //    stat.setString(6, a.getApellido());
            //    stat.setInt(7, a.getEdad());
            //    stat.setInt(8, a.getTelefono());
            //    stat.setString(9, a.getEmail());
            //    stat.setString(10, a.getRol());

            //    if (stat.executeUpdate() == 0)
            //    {
            //        System.out.println("error");
            //    }
            //}
            //catch (SQLException e)
            //{
            //    e.printStackTrace();
            //}
            //finally
            //{
            //    conn.commit();
            //    stat.close();
            //}

        }

        public Usuario LeerUsuario(int codi)
        {
            //PreparedStatement stat = null;
            //Cliente a = new Cliente();

            //try
            //{
            //    stat = conn.prepareStatement(GETONE);

            //    try (ResultSet resultat = stat.executeQuery()) {
            //        while (resultat.next())
            //        {
            //            a.setIdUsuario(resultat.getInt(1));
            //            a.setIdInstitucio(resultat.getInt(2));
            //            a.setUsername(resultat.getString(3));
            //            a.setPassword(resultat.getString(4));
            //            a.setDNI(resultat.getString(5));
            //            a.setNombre(resultat.getString(6));
            //            a.setApellido(resultat.getString(7));
            //            a.setEdad(resultat.getInt(8));
            //            a.setTelefono(resultat.getInt(9));
            //            a.setEmail(resultat.getString(10));
            //            a.setRol(resultat.getString(11));
            //        }
            //    }

            //    }
            //    catch (SQLException e)
            //    {
            //        e.printStackTrace();
            //    }
            //    finally
            //    {
            //        stat.close();
            //    }

            return new Usuario();
        }
    }
}
