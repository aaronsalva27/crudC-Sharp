namespace CRUDEmpresa.views
{
    partial class DetallControl
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idfacturadetallDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nfacturaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idproducteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantitatDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.facturaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.factura_detallBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnPDF = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.factura_detallBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idfacturadetallDataGridViewTextBoxColumn,
            this.nfacturaDataGridViewTextBoxColumn,
            this.idproducteDataGridViewTextBoxColumn,
            this.quantitatDataGridViewTextBoxColumn,
            this.facturaDataGridViewTextBoxColumn,
            this.productesDataGridViewTextBoxColumn});
            this.dataGridView1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dataGridView1.DataSource = this.factura_detallBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.Color.White;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(10, 10, 3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(912, 217);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dataGridView1_ColumnWidthChanged);
            this.dataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError);
            this.dataGridView1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dataGridView1_Scroll);
            this.dataGridView1.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridView1_UserAddedRow);
            // 
            // idfacturadetallDataGridViewTextBoxColumn
            // 
            this.idfacturadetallDataGridViewTextBoxColumn.DataPropertyName = "id_factura_detall";
            this.idfacturadetallDataGridViewTextBoxColumn.HeaderText = "id_factura_detall";
            this.idfacturadetallDataGridViewTextBoxColumn.Name = "idfacturadetallDataGridViewTextBoxColumn";
            this.idfacturadetallDataGridViewTextBoxColumn.Width = 171;
            // 
            // nfacturaDataGridViewTextBoxColumn
            // 
            this.nfacturaDataGridViewTextBoxColumn.DataPropertyName = "n_factura";
            this.nfacturaDataGridViewTextBoxColumn.HeaderText = "n_factura";
            this.nfacturaDataGridViewTextBoxColumn.Name = "nfacturaDataGridViewTextBoxColumn";
            this.nfacturaDataGridViewTextBoxColumn.Width = 113;
            // 
            // idproducteDataGridViewTextBoxColumn
            // 
            this.idproducteDataGridViewTextBoxColumn.DataPropertyName = "id_producte";
            this.idproducteDataGridViewTextBoxColumn.HeaderText = "id_producte";
            this.idproducteDataGridViewTextBoxColumn.Name = "idproducteDataGridViewTextBoxColumn";
            this.idproducteDataGridViewTextBoxColumn.Width = 137;
            // 
            // quantitatDataGridViewTextBoxColumn
            // 
            this.quantitatDataGridViewTextBoxColumn.DataPropertyName = "quantitat";
            this.quantitatDataGridViewTextBoxColumn.HeaderText = "quantitat";
            this.quantitatDataGridViewTextBoxColumn.Name = "quantitatDataGridViewTextBoxColumn";
            this.quantitatDataGridViewTextBoxColumn.Width = 106;
            // 
            // facturaDataGridViewTextBoxColumn
            // 
            this.facturaDataGridViewTextBoxColumn.DataPropertyName = "factura";
            this.facturaDataGridViewTextBoxColumn.HeaderText = "factura";
            this.facturaDataGridViewTextBoxColumn.Name = "facturaDataGridViewTextBoxColumn";
            this.facturaDataGridViewTextBoxColumn.Width = 92;
            // 
            // productesDataGridViewTextBoxColumn
            // 
            this.productesDataGridViewTextBoxColumn.DataPropertyName = "productes";
            this.productesDataGridViewTextBoxColumn.HeaderText = "productes";
            this.productesDataGridViewTextBoxColumn.Name = "productesDataGridViewTextBoxColumn";
            this.productesDataGridViewTextBoxColumn.Width = 121;
            // 
            // factura_detallBindingSource
            // 
            this.factura_detallBindingSource.DataSource = typeof(CRUDEmpresa.EntityFramework.factura_detall);
            // 
            // btnPDF
            // 
            this.btnPDF.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnPDF.Location = new System.Drawing.Point(39, 256);
            this.btnPDF.Name = "btnPDF";
            this.btnPDF.Size = new System.Drawing.Size(129, 72);
            this.btnPDF.TabIndex = 1;
            this.btnPDF.Text = "Export PDF";
            this.btnPDF.UseVisualStyleBackColor = true;
            this.btnPDF.Click += new System.EventHandler(this.btnPDF_ClickAsync);
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(0, 414);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(912, 14);
            this.progressBar1.TabIndex = 2;
            // 
            // DetallControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnPDF);
            this.Controls.Add(this.dataGridView1);
            this.Name = "DetallControl";
            this.Size = new System.Drawing.Size(912, 428);
            this.Load += new System.EventHandler(this.DetallControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.factura_detallBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idfacturadetallDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nfacturaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idproducteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantitatDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn facturaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productesDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource factura_detallBindingSource;
        private System.Windows.Forms.Button btnPDF;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}
