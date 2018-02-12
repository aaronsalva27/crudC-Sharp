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
    /// <summary>
    /// Formulario con la informacio de factura
    /// </summary>
    public partial class ProductosControl : UserControl
    {
        /// <summary>
        /// instancia de la clase menu
        /// </summary>
        private menu parent;
        private int currentProducto;
        /// <summary>
        /// Check is new row is added
        /// </summary>
        private Boolean newrow;
        /// <summary>
        /// Ccontexto de EF para acceder a la BD
        /// </summary>
        private dbempresaEntities context;

        public ProductosControl(menu parent)
        {
            this.parent = parent;
            InitializeComponent();

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(28, 94, 85);
            this.Dock = DockStyle.Fill; 
        }

        private void ProductosControl_Load(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = new DAOFactory().getProductoDAO().LeerProdutos();
            // dataGridView1.Refresh();

            loadData();
            initData();
        }
        /// <summary>
        /// carga los datos de la BD a la tabla
        /// </summary>
        private void loadData()
        {
            this.context = new dbempresaEntities();
            BindingSource bi = new BindingSource();
            bi.DataSource = this.context.productes.ToList();
            dataGridView1.DataSource = bi;
        }
        /// <summary>
        /// Settea la columna del ID como solo de lectura y añade el boton de borrar al final de cada row.
        /// </summary>
        private void initData()
        {

            dataGridView1.Columns[0].ReadOnly = true; //make the id column read only
            //add new button column to the DataGridView
            //This column displays a delete icon in each row
            DataGridViewImageColumn delbut = new DataGridViewImageColumn();
            delbut.Image = Image.FromFile(Environment.CurrentDirectory + "/images/del.jpg").GetThumbnailImage(15, 15, null, IntPtr.Zero);
            delbut.Width = 100;
            delbut.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns.Add(delbut);
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
                this.parent.sendMessage(cellId.Value.ToString() + " " + cellValue.Value.ToString());
            }
            catch (Exception ex)
            {
            }


            if (e.ColumnIndex == 3 && e.RowIndex >= 0 && newrow != true) //delete icon button is clicked
            {
                int bid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                DialogResult result = MessageBox.Show("Quieres eliminar este registro?", "Confirmación", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    //deleteProdute(bid); //delete the record from the producte table
                    new DAOFactory().getProductoDAO().BorrarProducto(bid);
                    dataGridView1.Rows.RemoveAt(e.RowIndex); //delete the row from the DataGridView
                }

            }
            else if (e.ColumnIndex == 3 && newrow) //save icon button is clicked
            {
                try
                {
                    String producte = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    int preu = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());

                    DialogResult result = MessageBox.Show("Guardando siguiente registro:\n" + producte.ToString() + "\n" + preu.ToString(), "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {
                        // addProducto(producte, preu); //add the new row to the producte table
                        var prod = new productes { producte = producte, preu = preu };
                        new DAOFactory().getProductoDAO().CrearProducto(prod);
                        newrow = false;
                        dataGridView1.Rows[e.RowIndex].Cells[3].Value = Image.FromFile(Environment.CurrentDirectory + "/images/del.jpg").GetThumbnailImage(15, 15, null, IntPtr.Zero);
                        // dataGridView1.EndEdit();
                        // dataGridView1.Refresh();
                        dataGridView1.EndEdit();
                        this.context.SaveChanges();
                        this.loadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to save the record. The problem might come from the following:\n1. Blank fields\n2. Duplicate record", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// New entry, change the delete button to save buton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            this.parent.sendMessage("add row  " + dataGridView1.NewRowIndex);
            newrow = true;
            dataGridView1.Rows[dataGridView1.NewRowIndex - 1].Cells[3].Value = Image.FromFile(Environment.CurrentDirectory + "/images/save.png").GetThumbnailImage(15, 15, null, IntPtr.Zero);
        }

        /// <summary>
        /// Función que se ejecuta cuando hay un error en la tabla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="anError"></param>
        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs anError)
        {
            MessageBox.Show("Error happened " + anError.Context.ToString());

            if (anError.Context == DataGridViewDataErrorContexts.Commit)
            {
                MessageBox.Show("Commit error");
            }
            if (anError.Context == DataGridViewDataErrorContexts.CurrentCellChange)
            {
                MessageBox.Show("Cell change");
            }
            if (anError.Context == DataGridViewDataErrorContexts.Parsing)
            {
                MessageBox.Show("Parsing error");
            }
            if (anError.Context == DataGridViewDataErrorContexts.LeaveControl)
            {
                MessageBox.Show("leave control error");
            }

            if ((anError.Exception) is ConstraintException)
            {
                DataGridView view = (DataGridView)sender;
                view.Rows[anError.RowIndex].ErrorText = "an error";
                view.Rows[anError.RowIndex].Cells[anError.ColumnIndex].ErrorText = "an error";
                anError.ThrowException = false;
            }
        }

        /// <summary>
        /// Método que se utiliza para actualizar los registros de la tabla.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString() != "0")
            {
                try
                {
                    this.parent.sendMessage("valuechanged" + dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                    dataGridView1.EndEdit();
                    this.context.SaveChanges();
                    this.loadData();
                }
                catch (System.Data.Entity.Infrastructure.DbUpdateException execp)
                {
                    MessageBox.Show(execp.InnerException.Message);
                }

            }
        }
    }
}