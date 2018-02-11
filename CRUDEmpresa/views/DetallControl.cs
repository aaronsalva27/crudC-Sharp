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
    public partial class DetallControl : UserControl
    {

        private dbempresaEntities context;
        private Boolean newrow;
        private menu parent;
        private int deleteColumn;

        private List<productes> productes = new DAOFactory().getProductoDAO().LeerProdutos();
        private List<factura> facturas = new DAOFactory().getFacturaDAO().LeerFactura();

        private ComboBox comboBoxProductes = new ComboBox();
        private ComboBox comboBoxFacturas = new ComboBox();
        Rectangle _Rectangle;

        public DetallControl(menu parent)
        {
            this.parent = parent;
            InitializeComponent();
            this.Dock = DockStyle.Fill;

            // add the clients 
            foreach (productes c in productes)
            {
                comboBoxProductes.Items.Add(c.id_produte + "-" + c.producte);
            }
            dataGridView1.Controls.Add(comboBoxProductes);
            comboBoxProductes.Visible = false;
            comboBoxProductes.TextChanged += ComboBoxProductes_TextChanged;

            // add the clients 
            foreach (factura f in facturas)
            {
                comboBoxFacturas.Items.Add(f.n_factura.ToString());
            }
            dataGridView1.Controls.Add(comboBoxFacturas);
            comboBoxFacturas.Visible = false;
            comboBoxFacturas.TextChanged += ComboBoxFacturas_TextChanged;


        }

        private void ComboBoxFacturas_TextChanged(object sender, EventArgs e)
        {
            parent.sendMessage(comboBoxFacturas.SelectedItem.ToString().Split()[0]);
            dataGridView1.CurrentCell.Value = comboBoxFacturas.SelectedItem.ToString().Split()[0];
            comboBoxFacturas.Hide();
        }

        private void ComboBoxProductes_TextChanged(object sender, EventArgs e)
        {
            parent.sendMessage(comboBoxProductes.SelectedItem.ToString().Split()[0]);
            dataGridView1.CurrentCell.Value = comboBoxProductes.SelectedItem.ToString().Split('-')[0];
            comboBoxProductes.Hide();
        }

        private void DetallControl_Load(object sender, EventArgs e)
        {
            loadData();
            initData();
        }

        private void loadData()
        {
            this.context = new dbempresaEntities();
            BindingSource bi = new BindingSource();
            bi.DataSource = this.context.factura_detall.ToList();
            dataGridView1.DataSource = bi;
        }

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
            deleteColumn = dataGridView1.ColumnCount - 1;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewTextBoxCell cellId = (DataGridViewTextBoxCell)
                dataGridView1.Rows[e.RowIndex].Cells[0];
                DataGridViewTextBoxCell cellValue = (DataGridViewTextBoxCell)
                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                this.parent.sendMessage(cellId.Value.ToString() + " " + cellValue.Value.ToString());
            }
            catch (Exception ex)
            {
            }

            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                parent.sendMessage("entra combo");
                _Rectangle = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true); //  
                comboBoxFacturas.Size = new Size(_Rectangle.Width, _Rectangle.Height); //  
                comboBoxFacturas.Location = new Point(_Rectangle.X, _Rectangle.Y); //  
                comboBoxFacturas.Visible = true;
            }

            if (e.ColumnIndex == 2 && e.RowIndex >= 0)
            {
                parent.sendMessage("entra combo");
                _Rectangle = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true); //  
                comboBoxProductes.Size = new Size(_Rectangle.Width, _Rectangle.Height); //  
                comboBoxProductes.Location = new Point(_Rectangle.X, _Rectangle.Y); //  
                comboBoxProductes.Visible = true;

            }


                if (e.ColumnIndex == deleteColumn && e.RowIndex >= 0 && newrow != true) //delete icon button is clicked
            {
                int bid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                DialogResult result = MessageBox.Show("Quieres eliminar este registro?", "Confirmación", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    //deleteProdute(bid); //delete the record from the producte table
                    new DAOFactory().getDetallDAO().BorrarDetall(bid);

                    dataGridView1.Rows.RemoveAt(e.RowIndex); //delete the row from the DataGridView
                }

            }
            else if (e.ColumnIndex == deleteColumn && newrow) //save icon button is clicked
            {
                try
                {
                    int n_factura = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                    int id_producte = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString()); ;
                    int quantitat = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString()); ;

                    DialogResult result = MessageBox.Show("Guardando siguiente registro:\n", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {
                        // addProducto(producte, preu); //add the new row to the producte table
                        var fac = new factura_detall
                        {
                            n_factura = n_factura,
                            id_producte = id_producte,
                            quantitat = quantitat
                        };
                        new DAOFactory().getDetallDAO().CrearDetall(fac);
                        newrow = false;
                        dataGridView1.Rows[e.RowIndex].Cells[deleteColumn].Value = Image.FromFile(Environment.CurrentDirectory + "/images/del.jpg").GetThumbnailImage(15, 15, null, IntPtr.Zero);
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

        private void dataGridView1_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            comboBoxFacturas.Hide();
            comboBoxProductes.Hide();
        }

        private void dataGridView1_Scroll(object sender, ScrollEventArgs e)
        {
            comboBoxFacturas.Hide();
            comboBoxProductes.Hide();
        }

        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            this.parent.sendMessage("add row  " + dataGridView1.NewRowIndex);
            newrow = true;
            dataGridView1.Rows[dataGridView1.NewRowIndex - 1].Cells[deleteColumn].Value = Image.FromFile(Environment.CurrentDirectory + "/images/save.png").GetThumbnailImage(15, 15, null, IntPtr.Zero);
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs anError)
        {
            MessageBox.Show("Error happened " + anError.Exception.Message.ToString());

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
                MessageBox.Show("Parsing error" + anError.Exception.Message.ToString());
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
