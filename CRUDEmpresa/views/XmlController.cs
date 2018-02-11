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

    public partial class XmlController : UserControl
    {
        private Utils.UtilityXml xmlUtility;
        private string fileRoute;
        public XmlController( string fileRoute)
        {
            InitializeComponent();
            this.fileRoute = fileRoute;
            this.xmlUtility = new Utils.UtilityXml();

        }

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
                label2.Text = "La casualidad que has importado un xml \n " +
                    "y la casualidad de que se ha importado correctamente ";
                //add data to context
                this.xmlUtility.addData();
            }
            else
            {
                label2.Text = "Se ha producido un error...";
            }
        }

       
    }
}
