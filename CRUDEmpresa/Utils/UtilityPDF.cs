using CRUDEmpresa.DAO;
using CRUDEmpresa.EntityFramework;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CRUDEmpresa.Utils
{
    class UtilityPDF
    {
        private string path;

        public static List<clients> clientList;
        public static List<factura> facturaList;
        public static List<factura_detall> factura_detallList;
        public static List<productes> producteList;

        public UtilityPDF(string path)
        {
            this.path = path;
            clientList = new DAOFactory().getClienteDAO().LeerCliente();
            facturaList = new DAOFactory().getFacturaDAO().LeerFacturas();
            factura_detallList = new DAOFactory().getFacturaDetallDAO().LeerFacturasDetall();
            producteList = new DAOFactory().getProductoDAO().LeerProdutos();
        }

        public Boolean generatePDF()
        {
            Thread.Sleep(3000); //ja ja

            // Creamos el documento con el tamaño de página tradicional
            Document doc = new Document(PageSize.LETTER);
            // Indicamos donde vamos a guardar el documento
            PdfWriter writer = PdfWriter.GetInstance(doc,
                                        new FileStream(@path, FileMode.Create));

            // Le colocamos el título y el autor
            // **Nota: Esto no será visible en el documento
            doc.AddTitle("resume");
            doc.AddCreator("Savami");

            // Abrimos el archivo
            doc.Open();

            // Creamos el tipo de Font que vamos utilizar
            iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA,10 , iTextSharp.text.Font.NORMAL, BaseColor.BLACK);


            //LOGO
            string imageURL = Environment.CurrentDirectory + "/images/logo.jpg";
            iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(imageURL);
            jpg.ScaleToFit(140f, 120f);
            jpg.Alignment = Element.ALIGN_CENTER;
            
            doc.Add(jpg);
            doc.Add(Chunk.NEWLINE);

            // Creamos una tabla de detalls
            var title = new Paragraph("Factura Detall");
            title.SpacingAfter = 1;
            title.SpacingBefore = 50;
            doc.Add(title);
            doc.Add(Chunk.NEWLINE);
            PdfPTable tblPrueba = new PdfPTable(4);
            tblPrueba.WidthPercentage = 100;

            // Configuramos el título de las columnas de la tabla
            PdfPCell idfacturaDetall = new PdfPCell(new Phrase("id_Factura_Detall", _standardFont));
            idfacturaDetall.BorderWidth = 0;
            idfacturaDetall.BackgroundColor = BaseColor.ORANGE;
            idfacturaDetall.BorderWidthBottom = 0.75f;

            PdfPCell nFactura = new PdfPCell(new Phrase("nFactura", _standardFont));
            nFactura.BorderWidth = 0;
            nFactura.BackgroundColor = BaseColor.ORANGE;
            nFactura.BorderWidthBottom = 0.75f;

            PdfPCell id_Producte = new PdfPCell(new Phrase("id_Producte", _standardFont));
            id_Producte.BorderWidth = 0;
            id_Producte.BackgroundColor = BaseColor.ORANGE;
            id_Producte.BorderWidthBottom = 0.75f;

            PdfPCell Quantitat = new PdfPCell(new Phrase("Quantitat", _standardFont));
            Quantitat.BorderWidth = 0;
            Quantitat.BackgroundColor = BaseColor.ORANGE;
            Quantitat.BorderWidthBottom = 0.75f;


            // Añadimos las celdas a la tabla
            tblPrueba.AddCell(idfacturaDetall);
            tblPrueba.AddCell(nFactura);
            tblPrueba.AddCell(id_Producte);
            tblPrueba.AddCell(Quantitat);


            foreach (factura_detall  fd in factura_detallList) {

                idfacturaDetall = new PdfPCell(new Phrase(fd.id_factura_detall.ToString(), _standardFont));
                idfacturaDetall.BorderWidth = 0;

                nFactura = new PdfPCell(new Phrase(fd.n_factura.ToString(), _standardFont));
                nFactura.BorderWidth = 0;

                id_Producte = new PdfPCell(new Phrase(fd.id_producte.ToString(), _standardFont));
                id_Producte.BorderWidth = 0;

                Quantitat = new PdfPCell(new Phrase(fd.quantitat.ToString(), _standardFont));
                Quantitat.BorderWidth = 0;

                // Añadimos las celdas a la tabla
                tblPrueba.AddCell(idfacturaDetall);
                tblPrueba.AddCell(nFactura);
                tblPrueba.AddCell(id_Producte);
                tblPrueba.AddCell(Quantitat);

            }


            doc.Add(tblPrueba);
            doc.Add(Chunk.NEWLINE);

            ///////////////////////////////////////////////////////////
            // Creamos una tabla de factura
            // de nuestros visitante.
            var title2 = new Paragraph("Factura");
            title2.SpacingAfter = 1;
            title.SpacingBefore = 30;
            doc.Add(title2);
            doc.Add(Chunk.NEWLINE);
            PdfPTable tblFactura = new PdfPTable(5);
            tblFactura.WidthPercentage = 100;

            // Configuramos el título de las columnas de la tabla
            PdfPCell n_factura = new PdfPCell(new Phrase("n_factura", _standardFont));
            n_factura.BorderWidth = 0;
            n_factura.BackgroundColor = BaseColor.CYAN;
            n_factura.BorderWidthBottom = 0.75f;

            PdfPCell id_client = new PdfPCell(new Phrase("id_client", _standardFont));
            id_client.BorderWidth = 0;
            id_client.BackgroundColor = BaseColor.CYAN;
            id_client.BorderWidthBottom = 0.75f;

            PdfPCell data = new PdfPCell(new Phrase("data", _standardFont));
            data.BorderWidth = 0;
            data.BackgroundColor = BaseColor.CYAN;
            data.BorderWidthBottom = 0.75f;

            PdfPCell descompte = new PdfPCell(new Phrase("descompte", _standardFont));
            descompte.BorderWidth = 0;
            descompte.BackgroundColor = BaseColor.CYAN;
            descompte.BorderWidthBottom = 0.75f;

            PdfPCell IVA = new PdfPCell(new Phrase("IVA", _standardFont));
            IVA.BorderWidth = 0;
            IVA.BackgroundColor = BaseColor.CYAN;
            IVA.BorderWidthBottom = 0.75f;


            // Añadimos las celdas a la tabla
            tblFactura.AddCell(n_factura);
            tblFactura.AddCell(id_client);
            tblFactura.AddCell(data);
            tblFactura.AddCell(descompte);
            tblFactura.AddCell(IVA);


            foreach (factura f in facturaList)
            {

                n_factura = new PdfPCell(new Phrase(f.n_factura.ToString(), _standardFont));
                n_factura.BorderWidth = 0;

                id_client = new PdfPCell(new Phrase(f.n_factura.ToString(), _standardFont));
                id_client.BorderWidth = 0;

                data = new PdfPCell(new Phrase(f.data.ToString(), _standardFont));
                data.BorderWidth = 0;

                descompte = new PdfPCell(new Phrase(f.descompte.ToString(), _standardFont));
                descompte.BorderWidth = 0;

                IVA = new PdfPCell(new Phrase(f.iva.ToString(), _standardFont));
                IVA.BorderWidth = 0;

                // Añadimos las celdas a la tabla
                tblFactura.AddCell(n_factura);
                tblFactura.AddCell(id_client);
                tblFactura.AddCell(data);
                tblFactura.AddCell(descompte);
                tblFactura.AddCell(IVA);

            }


            doc.Add(tblFactura);
            doc.Add(Chunk.NEWLINE);

            doc.Close();
            writer.Close();

            return true;
        }

    }
}
