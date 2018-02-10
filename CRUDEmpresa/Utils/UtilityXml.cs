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

namespace CRUDEmpresa.Utils
{
    class UtilityXml
    {
        private XmlDocument xmlDoc;
        private List<clients> clientList;

        public void XMLDocManager(string fileRoute)
        {
            xmlDoc = new XmlDocument();
            clientList = new List<clients>();
            try {
                xmlDoc.Load(@fileRoute);
                loadListFromXML();
            }
            catch (XmlException e) {
                Console.WriteLine("Excepció: " + e.ToString());
            }
        }

        public bool loadListFromXML()
        {
            if (xmlDoc == null) return false;
            else
            {
                foreach (XmlNode current_client in xmlDoc.GetElementsByTagName("client"))
                {
                    Console.WriteLine(current_client.ToString());
                    /*
                    clientList.Add(new CD(current_cd.SelectSingleNode("TITLE").InnerText,
                                        current_cd.SelectSingleNode("ARTIST").InnerText.ToLower(),
                                        current_cd.SelectSingleNode("COUNTRY").InnerText,
                                        current_cd.SelectSingleNode("COMPANY").InnerText,
                                        double.Parse(current_cd.SelectSingleNode("PRICE").InnerText, System.Globalization.CultureInfo.InvariantCulture),
                                        Int32.Parse(current_cd.SelectSingleNode("YEAR").InnerText)));
                                        */
                }
                return true;
            }
        }

        public int getNumberCDs_v2() { return xmlDoc.GetElementsByTagName("CD").Count; }   // v2. sense carregar les dades a classes pròpies

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
