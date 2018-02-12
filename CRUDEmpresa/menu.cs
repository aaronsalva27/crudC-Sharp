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
            this.tableLayoutPanel1.Dock = DockStyle.Fill;
        }

        private void menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
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
            /*var context = new dbempresaEntities();
            BindingSource bi = new BindingSource();
            bi.DataSource = context.clients.ToList();
            dataGridView1.DataSource = bi;
            dataGridView1.Refresh();*/

            pictureBox1.Image = Image.FromFile(Environment.CurrentDirectory + "/images/mysql.png").GetThumbnailImage(50, 50, null, IntPtr.Zero);
            pictureBox2.Image = Image.FromFile(Environment.CurrentDirectory + "/images/entity_image.png").GetThumbnailImage(50, 50, null, IntPtr.Zero);

        }

        private void btnProductes_Click(object sender, EventArgs e)
        {
            this.stripStatusLabel.Text = "Productes";
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(new ProductosControl(this));
        }

        private void btnClients_Click(object sender, EventArgs e)
        {
            this.stripStatusLabel.Text = "Clients";
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(new ClientControl(this));
        }

     
        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void sendMessage(String message)
        {
            this.stripStatusLabel.Text = message;
        }

        //import
        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.DefaultExt = "xml";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(openFileDialog1.FileName, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mainPanel.Controls.Clear();
                mainPanel.Controls.Add( new XmlController(openFileDialog1.FileName)); // le pasamos la ruta del archivo
            }

        }

        //Export XML
        private void button3_Click(object sender, EventArgs e)
        {
            this.stripStatusLabel.Text = "Export";
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(new XMLExporter());
        }

        private void btnFacturas_Click(object sender, EventArgs e)
        {
            this.stripStatusLabel.Text = "Factura";
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(new FacturaControl(this));
        }

        private void btnDetalls_Click(object sender, EventArgs e)
        {
            this.stripStatusLabel.Text = "Detall";
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(new DetallControl(this));
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

       
    }
}
