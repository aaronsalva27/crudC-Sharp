using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDEmpresa.views
{
    public partial class ClientView : Form
    {
        public ClientView()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.ControlBox = false;
            this.ShowInTaskbar = false;
            this.Text = "";

        }

        private void ClientView_Load(object sender, EventArgs e)
        {

        }
    }
}
