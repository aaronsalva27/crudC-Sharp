using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using CRUDEmpresa.EntityFramework;
using System.Diagnostics;
using CRUDEmpresa.DAO.Cliente;
using System.Threading;
using CRUDEmpresa.EntityFramework;
using CRUDEmpresa.DAO;


namespace CRUDEmpresa.Utils
{
    /// <summary>
    /// Clase utilidad con los métodos para registros a la BD desde un XML.
    /// </summary>
    class UtilityXml
    {
        public static XmlDocument xmlDoc;
        public static List<clients> clientList;
        public static List<factura> facturaList;
        public static List<factura_detall> factura_detallList;
        public static List<productes> producteList;
        private dbempresaEntities context;

        /// <summary>
        /// Métdo que comprueba que la ruta pasada existe y llama al método loadListFromXML 
        /// </summary>
        /// <param name="fileRoute">ruta del fichero</param>
        /// <returns>Boolean</returns>
        public Boolean XMLDocManager(string fileRoute)
        {
            xmlDoc = new XmlDocument();
            clientList = new List<clients>();
            facturaList = new List<factura>();
            factura_detallList = new List<factura_detall>();
            producteList = new List<productes>();
            Thread.Sleep(4000); //ja ja
            try
            {
                xmlDoc.Load(@fileRoute);
                return loadListFromXML();
            }
            catch (XmlException e)
            {
                Console.WriteLine("Excepció: " + e.ToString());
                return false;
            }
        }

        /// <summary>
        /// Método que carga las entradas del XML en el context de la bd
        /// </summary>
        /// <returns></returns>
        public bool loadListFromXML()
        {
            if (xmlDoc == null) return false;
            else
            {
                try
                {
                    //Debug.WriteLine(xmlDoc.InnerXml);
                    foreach (XmlNode client in xmlDoc.SelectNodes("empresa/clients/client"))
                    {
                        //< id_client > 123 </ id_client >< nom > David </ nom >< cognom1 > Ramírez </ cognom1 >
                        //< cognom2 > Campoy </ cognom2 >< adreça > Mollet </ adreça >< codi_postal > 080100 </ codi_postal >
                        //< poblacio > Mollet </ poblacio >< provincia > Barcelona </ provincia >< telefon > 696969696 </ telefon >
                        //< fax > 686868686 </ fax >< email > a@a.a </ email >
                        Debug.WriteLine(client.InnerXml);
                        clients c = new clients();
                        c.id_client = Int32.Parse(client.SelectSingleNode("id_client").InnerText);
                        c.nom = client.SelectSingleNode("nom").InnerText;
                        c.cognom1 = client.SelectSingleNode("cognom1").InnerText;
                        c.cognom2 = client.SelectSingleNode("cognom2").InnerText;
                        c.adreça = client.SelectSingleNode("adreça").InnerText;
                        c.codi_postal = Int32.Parse(client.SelectSingleNode("codi_postal").InnerText);
                        c.poblacio = client.SelectSingleNode("poblacio").InnerText;
                        c.provincia = client.SelectSingleNode("provincia").InnerText;
                        c.telefon = Int32.Parse(client.SelectSingleNode("telefon").InnerText);
                        c.fax = Int32.Parse(client.SelectSingleNode("fax").InnerText);
                        c.email = client.SelectSingleNode("email").InnerText;
                        clientList.Add(c);
                    }
                    foreach (XmlNode factura in xmlDoc.SelectNodes("empresa/factures/factura"))
                    {
                        /*
                        < factura >
                        < n_factura > 1111 </ factures >
                        < id_client > 123 </ client >
                        < data > 2017 - 12 - 05 00:10:00 < data >
                        < descompte > 5 </ descompte >
                        < iva > 21 </ iva >
                        </ factura >*/

                        Debug.WriteLine(factura.InnerXml);
                        factura fc = new factura();
                        fc.n_factura = Int32.Parse(factura.SelectSingleNode("n_factura").InnerText);
                        fc.id_client = Int32.Parse(factura.SelectSingleNode("id_client").InnerText);
                        fc.data = DateTime.Parse(factura.SelectSingleNode("data").InnerText);
                        fc.descompte = Int32.Parse(factura.SelectSingleNode("descompte").InnerText);
                        fc.iva = Int32.Parse(factura.SelectSingleNode("iva").InnerText);
                        facturaList.Add(fc);
                    }

                    foreach (XmlNode factura_detall in xmlDoc.SelectNodes("empresa/factures_detall/factura_detall"))
                    {
                        /*
                       <factures_detall>
                         <factura_detall>
                            <id_factura_detall>2222</id_factura_detall>
                            <n_factura>1111</n_factura>
                            <id_producte>333</id_producte>
                            <quantitat>5</quantitat>
                         </factura_detall>
                       </factures_detall>*/
                        Debug.WriteLine(factura_detall.InnerXml);
                        factura_detall fcd = new factura_detall();
                        fcd.id_factura_detall = Int32.Parse(factura_detall.SelectSingleNode("id_factura_detall").InnerText);
                        fcd.n_factura = Int32.Parse(factura_detall.SelectSingleNode("n_factura").InnerText);
                        fcd.id_producte = Int32.Parse(factura_detall.SelectSingleNode("id_produte").InnerText);
                        fcd.quantitat = Int32.Parse(factura_detall.SelectSingleNode("quantitat").InnerText);
                        factura_detallList.Add(fcd);
                    }

                    foreach (XmlNode producte in xmlDoc.SelectNodes("empresa/productes/producte"))
                    {
                        /*<productes>
                             <producte>
                                <id_producte>333</id_producte>
                                <producte>Laser</producte>
                                <preu>190</preu>
                             </producte>
                         </productes>*/
                        Debug.WriteLine(producte.InnerXml);
                        productes prod = new productes();
                        prod.id_produte = Int32.Parse(producte.SelectSingleNode("id_produte").InnerText);
                        prod.producte = producte.SelectSingleNode("producte").InnerText;
                        prod.preu = Int32.Parse(producte.SelectSingleNode("preu").InnerText);
                        producteList.Add(prod);
                    }
                    return true;

                }
                catch (Exception e)
                {
                    return false;

                }

            }
        }
        public void addData()
        //add list to context
        //problem the id autoincremental... T_T
        {
            this.context = new dbempresaEntities();


            foreach (clients c in clientList)
            {
                int realId = c.id_client;
                new DAOFactory().getClienteDAO().CrearCliente(c);
                this.context.SaveChanges();
                Debug.WriteLine(" Client ID is " + c.id_client);
                // modify all the fk
                foreach (factura f in facturaList)
                {
                    if (f.id_client == realId) f.id_client = c.id_client;
                }
            }

            foreach (productes pt in producteList)
            {
                var realId = pt.id_produte;
                new DAOFactory().getProductoDAO().CrearProducto(pt);
                this.context.SaveChanges();
                Debug.WriteLine("id productes: " + pt.id_produte+ " "+realId);
                // modify all the fk
                foreach (factura_detall fd in factura_detallList)
                {
                    Debug.WriteLine("real:  " + realId);
                    if (fd.id_producte == realId) fd.id_producte = pt.id_produte;
                    Debug.WriteLine("id productes de factura detall: " + fd.id_producte);
                }

            }

            foreach (factura f in facturaList)
            {
                int realnFactura = f.n_factura; 
                new DAOFactory().getFacturaDAO().CrearFactura(f);
                this.context.SaveChanges();
                //el id incremental , hay que volverlo a setear, si no hace el autoincremental normal
                //factura fact = this.context.factura.First(i => i.id_client == f.id_client && i.data == f.data 
                //&& i.descompte == f.descompte && i.iva == f.iva);
                //factura fact = this.context.factura.Last<factura>();
                //int max = this.context.factura.Max(p => p.n_factura);

                //factura fact = this.context.factura.First(i => i.n_factura == max);

                //fact.n_factura = f.n_factura;
                // modify all the fk
                foreach (factura_detall fd in factura_detallList)
                {
                    Debug.WriteLine("id nfactura: " + f.n_factura + " real  " + realnFactura +"fd"+ fd.n_factura);

                    if (fd.n_factura == realnFactura) fd.n_factura = f.n_factura;
                }

            }
            foreach (factura_detall fd in factura_detallList)
            {

                new DAOFactory().getFacturaDetallDAO().CrearFacturaDetall(fd);
                this.context.SaveChanges();

                //el id incremental , hay que volverlo a setear, si no hace el autoincremental normal
                //factura_detall factd = this.context.factura_detall.First(i => i.n_factura == fd.n_factura);
                //factura_detall factd = this.context.factura_detall.Last<factura_detall>();
                //int max = this.context.factura_detall.Max(p => p.id_factura_detall);
                //factura_detall factd = this.context.factura_detall.First(i => i.id_factura_detall == max);

                //factd.id_factura_detall = fd.id_factura_detall;

            }

        }

        public void isGroupInCollection(string bandName)
        {

            foreach (clients element in clientList)
            {
                /*if (element.Artist == bandName)
                {
                    Console.WriteLine("SÍ tenim CD's d'aquest grup");
                    return;
                }*/
            }
            Console.WriteLine("asd");
        }



    }
}
