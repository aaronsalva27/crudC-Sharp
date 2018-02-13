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
    public partial class FacturaControl : UserControl
    {
        /// <summary>
        /// context de EF para acceder a la BD
        /// </summary>
        private dbempresaEntities context;
        /// <summary>
        /// Check is new row is added
        /// </summary>
        private Boolean newrow;
        /// <summary>
        /// Instancia de la clase menu
        /// </summary>
        private menu parent;
        /// <summary>
        /// Variable que guarda la ultima columna.
        /// </summary>
        private int deleteColumn;
        /// <summary>
        /// Instancia de la clase utilidad UtilityPDF
        /// </summary>
        private Utils.UtilityPDF pdfUtility;

        /// <summary>
        /// Lista de clientes
        /// </summary>
        private List<clients> clientes = new DAOFactory().getClienteDAO().LeerCliente();

        /// <summary>
        /// Combobox con la lista de clientes
        /// </summary>
        private ComboBox comboBox = new ComboBox();
        /// <summary>
        /// Date picker
        /// </summary>
        DateTimePicker dtp = new DateTimePicker();
        Rectangle _Rectangle;


        public FacturaControl(menu parent)
        {
            this.parent = parent;
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            progressBar1.Visible = false;


            // add the clients to combobox
            foreach (clients c in clientes)
            {
                comboBox.Items.Add(c.id_client + "-" + c.nom);
            }
            
            dataGridView1.Controls.Add(comboBox);
            comboBox.Visible = false;
            comboBox.TextChanged += ComboBox_TextChanged;

            //adding the datepicker to form
            dataGridView1.Controls.Add(dtp);
            dtp.Visible = false;
            dtp.CustomFormat = "dd/MM/yyyy HH:mm";

            dtp.Format = DateTimePickerFormat.Custom;
            dtp.TextChanged += new EventHandler(dtp_TextChange);
        }

        /// <summary>
        /// Método que se ejecuta cuando el valor de comboBox cambia.
        /// Añade el calor del combobox a la celda.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_TextChanged(object sender, EventArgs e)
        {
            parent.sendMessage(comboBox.SelectedItem.ToString().Split()[0]);
            dataGridView1.BeginEdit(true);
            dataGridView1.CurrentCell.Value = comboBox.SelectedItem.ToString().Split('-')[0];
            dataGridView1.EndEdit();
            comboBox.Hide();
        }

        private void FacturaControl_Load(object sender, EventArgs e)
        {
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
            bi.DataSource = this.context.factura.ToList();
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

            // if date cell  is clicked change cell with datepicker
            if (e.ColumnIndex == 2 && e.RowIndex >= 0)
            {
                parent.sendMessage("entra picker");
                _Rectangle = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true); //  
                dtp.Size = new Size(_Rectangle.Width, _Rectangle.Height); //  
                dtp.Location = new Point(_Rectangle.X, _Rectangle.Y); //  
                dtp.Visible = true;
            }

            // if combobox cell  is clicked change cell with combobox
            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                parent.sendMessage("entra combo");
                _Rectangle = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true); //  
                comboBox.Size = new Size(_Rectangle.Width, _Rectangle.Height); //  
                comboBox.Location = new Point(_Rectangle.X, _Rectangle.Y); //  
                comboBox.Visible = true;
            }

            if (e.ColumnIndex == deleteColumn && e.RowIndex >= 0 && newrow != true) //delete icon button is clicked
            {
                int bid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                DialogResult result = MessageBox.Show("Quieres eliminar este registro?", "Confirmación", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    //deleteProdute(bid); //delete the record from the producte table
                    new DAOFactory().getFacturaDAO().BorrarFactura(bid);

                    dataGridView1.Rows.RemoveAt(e.RowIndex); //delete the row from the DataGridView
                }

            }
            else if (e.ColumnIndex == deleteColumn && newrow) //save icon button is clicked
            {
                try
                {
                    int id_client = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                    DateTime data = DateTime.Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                    int descompte = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString()) > 100 ? 100 : int.Parse(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
                    int iva = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString()) > 100 ? 100 : int.Parse(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
                   



                    DialogResult result = MessageBox.Show("Guardando siguiente registro:\n", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {
                        // addProducto(producte, preu); //add the new row to the producte table
                        var fac = new factura
                        {
                            id_client = id_client,
                            data = data,
                            descompte = descompte,
                            iva = iva
                        };
                        new DAOFactory().getFacturaDAO().CrearFactura(fac);
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

        /// <summary>
        /// Método que se ejecuta cuando el valor del datepicker cambia.
        /// Añade el calor del combobox a la celda.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtp_TextChange(object sender, EventArgs e)
        {
            DateTime? date = new DateTime(dtp.Value.Ticks);
            parent.sendMessage(dtp.Text.ToString());
            dataGridView1.BeginEdit(true);
            dataGridView1.CurrentCell.Value = date.Value.ToString();
            dataGridView1.EndEdit();
            dtp.Hide();
        }

        private void dataGridView1_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            dtp.Visible = false;
            comboBox.Hide();
        }

        private void dataGridView1_Scroll(object sender, ScrollEventArgs e)
        {
            dtp.Visible = false;
            comboBox.Hide();
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
            dataGridView1.Rows[dataGridView1.NewRowIndex - 1].Cells[deleteColumn].Value = Image.FromFile(Environment.CurrentDirectory + "/images/save.png").GetThumbnailImage(15, 15, null, IntPtr.Zero);
        }

        /// <summary>
        /// Función que se ejecuta cuando hay un error en la tabla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="anError"></param>
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

        /// <summary>
        /// Método que se utiliza para actualizar los registros de la tabla.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString() != "0")
            {
                dataGridView1.Rows[e.RowIndex].Cells[3].Value = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString()) > 100 ? 
                                                                  100 :  int.Parse(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());

                dataGridView1.Rows[e.RowIndex].Cells[4].Value = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString()) > 100 ?
                                                                  100 : int.Parse(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());

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

        /// <summary>
        /// Función que despliega un dialogo y llama a la clase UtilityPDF para generar un pdf de la tabla.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {

                progressBar1.Visible = true;
                progressBar1.Style = ProgressBarStyle.Marquee;
                MessageBox.Show(folderBrowserDialog1.SelectedPath, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                pdfUtility = new Utils.UtilityPDF(folderBrowserDialog1.SelectedPath + @"\" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf");
                // simply start and await the loading task
                var result = false;
                result = await Task.Run(() => this.pdfUtility.generatePDF());
                progressBar1.Visible = false;
                parent.sendMessage("exportando pdf...");
                if (result)
                { //ok,
                    parent.sendMessage("PDF exportado");
                }
                else
                {
                    parent.sendMessage("Se ha producido un error...");
                }
            }
        }
    }
}
