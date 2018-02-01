using CRUDEmpresa.DAO.Usuario;
using CRUDEmpresa.EntityFramework;
using CRUDEmpresa.views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDEmpresa
{
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
            this.FormClosed += new FormClosedEventHandler(this.menu_FormClosed);
            //MdiParent = this;
        }

        private void menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripMenuItem item = e.ClickedItem as ToolStripMenuItem;
            if (item != null)
            {
                string url = item.Tag as String;
                this.statusLabel.Text = url;

                switch(url)
                {
                    case "clientes":
                        /*panel1.Controls.Clear();
                        ClientView cv = new ClientView();
                        cv.MdiParent = this.MdiParent;
                        cv.Show();*/
                        
                        //panel1.Controls.Add(cv);
                        
                        break;
                    default:
                        break;
                }
            };
        }

        private void FlowLayoutPanel1_ControlAdded(object sender, ControlEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menu_Load(object sender, EventArgs e)
        {
            var context = new dbempresaEntities();
            BindingSource bi = new BindingSource();
            bi.DataSource = context.clients.ToList();
            dataGridView1.DataSource = bi;
            dataGridView1.Refresh();
        }

        private void clientsBindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void clientsBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
