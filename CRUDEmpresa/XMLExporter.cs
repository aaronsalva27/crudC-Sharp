using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using CRUDEmpresa.EntityFramework;
using System.Xml;
using System.Xml.Linq;
using System.Diagnostics;

namespace CRUDEmpresa
{
    public partial class XMLExporter : UserControl
    {
        private dbempresaEntities context;
        public XMLExporter()
        {
            InitializeComponent();
        }

        private void XMLExporter_Load(object sender, EventArgs e)
        {
           this.context = new dbempresaEntities();

            //Declaramos el documento y su definición
            XDocument document = new XDocument(
                new XDeclaration("1.0", "utf-8", null));

            //Creamos el nodo raiz y lo añadimos al documento
            XElement nodoRaiz = new XElement("empresa");
            document.Add(nodoRaiz);
            XElement nodoClients = new XElement("clients");
            XElement nodoProductes = new XElement("productes");
            XElement nodoFactures = new XElement("factura");
            XElement nodoFacturesDetall = new XElement("factura_detall");
        
            nodoRaiz.Add(nodoClients);
            nodoRaiz.Add(nodoProductes);
            nodoRaiz.Add(nodoFactures);
            nodoRaiz.Add(nodoFacturesDetall);

            foreach (clients c in this.context.clients)
            {
                XElement nodoClient = new XElement("client");
                nodoClient.Add(new XElement("id_client", c.id_client));
                nodoClient.Add(new XElement("nom", c.nom));
                nodoClient.Add(new XElement("cognom1", c.cognom1));
                nodoClient.Add(new XElement("cognom2", c.cognom2));
                nodoClient.Add(new XElement("adreça", c.adreça));
                nodoClient.Add(new XElement("codi_postal", c.codi_postal));
                nodoClient.Add(new XElement("poblacio", c.poblacio));
                nodoClient.Add(new XElement("provincia", c.provincia));
                nodoClient.Add(new XElement("telefon", c.telefon));
                nodoClient.Add(new XElement("fax", c.fax));
                nodoClient.Add(new XElement("email", c.email));
                nodoClients.Add(nodoClient);
            }
            foreach (productes p in this.context.productes)
            {
                XElement nodoProducte = new XElement("producte");
                nodoProducte.Add(new XElement("id_produte", p.id_produte));
                nodoProducte.Add(new XElement("producte", p.producte));
                nodoProducte.Add(new XElement("preu", p.preu));
                nodoProductes.Add(nodoProducte);
            }
            foreach (factura f in this.context.factura)
            {
                XElement nodoFactura = new XElement("factura");
                nodoFactura.Add(new XElement("n_factura", f.n_factura));
                nodoFactura.Add(new XElement("id_client", f.id_client));
                nodoFactura.Add(new XElement("descompte", f.descompte));
                nodoFactura.Add(new XElement("data", f.data));
                nodoFactura.Add(new XElement("iva", f.iva));
                nodoFactures.Add(nodoFactura);
            }
            foreach (factura_detall fd in this.context.factura_detall)
            {
                XElement nodoFacturaDetall = new XElement("factura_detall");
                nodoFacturaDetall.Add(new XElement("id_factura_detall", fd.id_factura_detall));
                nodoFacturaDetall.Add(new XElement("n_factura", fd.n_factura));
                nodoFacturaDetall.Add(new XElement("id_producte", fd.id_producte));
                nodoFacturaDetall.Add(new XElement("quantitat", fd.quantitat));
                nodoFacturesDetall.Add(nodoFacturaDetall);
            }
            Debug.WriteLine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\export.xml");
            document.Save(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+ "\\export.xml");



        }
    }
}
