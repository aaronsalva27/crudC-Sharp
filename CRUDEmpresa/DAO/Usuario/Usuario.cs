using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDEmpresa.DAO.Usuario
{
    class Usuario
    {
        public String Nombre { get; set; }
        public String Apellido { get; set; }

        public String toString()
        {
            return String.Format("Nombe: {0} - Apellido: {1}",this.Nombre,this.Apellido);
        }
    }
}
