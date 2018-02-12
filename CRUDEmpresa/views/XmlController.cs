using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace CRUDEmpresa.views
{
    /// <summary>
    /// Formulario que gestiona la importacio de XML
    /// </summary>
    public partial class XmlController : UserControl
    {
        /// <summary>
        /// instancia de la clase utilidad UtilityXml
        /// </summary>
        private Utils.UtilityXml xmlUtility;
        /// <summary>
        /// ruta del fichero
        /// </summary>
        private string fileRoute;
        public XmlController( string fileRoute)
        {
            InitializeComponent();
            this.fileRoute = fileRoute;
            this.xmlUtility = new Utils.UtilityXml();

        }


        /// <summary>
        /// Al cargar la vista llama a la clase UtilityXml para cargar las entradas, cunado se han
        /// cargado esconde el loader
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void XmlController_Load(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            progressBar1.Style = ProgressBarStyle.Marquee;

            // simply start and await the loading task
            var result = false;
            result = await Task.Run(() => this.xmlUtility.XMLDocManager(this.fileRoute));
            progressBar1.Visible = false;
            label1.Text = this.fileRoute;
            if (result) { //ok
                label2.Text = "Se ha importado correctamente el fichero xml";
                //add data to context
                this.xmlUtility.addData();
            }
            else
            {
                label2.Text = "Se ha producido un error en la importación, compruebe los datos introducidos...";
            }
        }

       
    }
}
