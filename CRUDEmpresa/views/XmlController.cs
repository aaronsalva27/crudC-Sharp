using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        }

        private void XmlController_Load(object sender, EventArgs e)
        {
            label1.Text = this.fileRoute;
            this.xmlUtility = new Utils.UtilityXml();
            this.xmlUtility.XMLDocManager(this.fileRoute);
        }

       
    }
}
