using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRUDEmpresa.EntityFramework;
using CRUDEmpresa.DAO;

namespace CRUDEmpresa.views
{
    public partial class ProductosControl : UserControl
    {
        private menu parent;
        private int currentProducto;

        public ProductosControl(menu parent)
        {

            this.parent = parent;

            InitializeComponent();

            this.Dock = DockStyle.Fill;
        }

        private void ProductosControl_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new DAOFactory().getProductoDAO().LeerProdutos();
            dataGridView1.Refresh();
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           try
            {
               DataGridViewTextBoxCell cellId = (DataGridViewTextBoxCell)
               dataGridView1.Rows[e.RowIndex].Cells[0];


               DataGridViewTextBoxCell cellValue = (DataGridViewTextBoxCell)
               dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];

                this.currentProducto = int.Parse(cellId.Value.ToString());


               this.parent.sendMessage(cellId.Value.ToString()+ " "+cellValue.Value.ToString());
            }
            catch (Exception ex)
            {
                
            }
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.label1.Text = new DAOFactory().getProductoDAO().LeerProducto(this.currentProducto).producte;

            tabControl1.SelectedTab = Modify;
        }
    }
}
