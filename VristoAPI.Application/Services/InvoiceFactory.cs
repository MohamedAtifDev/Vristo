using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VristoAPI.Application.Services
{
    public  class InvoiceFactory
    {
        
        //public void GeneratePdf()
        //{
        //    // use any method to create a document, e.g.: injected service
        //    var document = GenerateComplexPdf();

        //    // generate PDF file and return it as a response

        //    return Results.File(document.GeneratePdf(), "application/pdf", "hello-world.pdf");
        //}
        //private Document GenerateComplexPdf()
        //{
        //    var DefaultFontFamily = TextStyle.Default.FontFamily("Arial").FontSize(11);

        //    // Generate and save the PDF
        //    QuestPDF.Settings.License = LicenseType.Community;
        //    return Document.Create(container => container.Page(page =>
        //    {
        //        page.Margin(2, Unit.Centimetre);
        //        page.Size(216, 279, Unit.Millimetre);
        //        page.DefaultTextStyle(DefaultFontFamily);
        //        page.ContentFromRightToLeft();

        //        page.Header().Element(_ComposeHeader);
        //        page.Content().Element(_ComposeContent);

        //    })
        //    );

        //}

        //private void _ComposeHeader(IContainer container)
        //{
        //    var titleStyle = TextStyle.Default.FontSize(18).Bold();
        //    var goBeautiCompanyTitleStyle = TextStyle.Default.FontSize(15).Bold();
        //    var defaultStyle = TextStyle.Default.FontSize(11);
        //    var logoPath = "C:\\Users\\EL-masreya\\Desktop\\Vristo\\VristoAPI\\Uploads\\g-8.png";

        //    // Invoice data
        //    string sellerName = "Vristo";
        //    string vatRegistrationNumber = "123456789";
        //    string invoiceTimestamp = "22/5/2024";


        //    // Convert the Base64 string to byte array
        //    byte[] qrCodeImage = GenerateBarcode("100");

        //    container.Row(row =>
        //    {
        //        row.ConstantItem(180).Column(column =>
        //        {
        //            column.Item()
        //                  .Height(15);

        //            column.Spacing(5);

        //            column.Item().PaddingTop(-50)
        //                  .Text("Purchase Invoice")
        //                  .Style(titleStyle);

        //            column.Item()
        //                  .Image(qrCodeImage)
        //                  .FitWidth();

        //        });

        //        //row.ConstantItem(140); // Adjust the value as needed

        //        row.RelativeItem().Column(column =>
        //        {
        //            column.Spacing(2);
        //            column.Item()
        //                  .PaddingRight(150)
        //                  .Image(logoPath)
        //                  .WithCompressionQuality(ImageCompressionQuality.Low)
        //                  .FitWidth();

        //            column.Item()

        //                  .Text("Vristo")
        //                  .AlignLeft()
        //                  .Style(goBeautiCompanyTitleStyle);

        //            column.Item()
        //                  .PaddingRight(170).AlignLeft()
        //                  .Text($"Tax Number : 100")
        //                  .Style(defaultStyle);

        //            column.Item()
        //            .AlignLeft()
        //                  .PaddingRight(150)
        //                  .Text("Address : Cairo")
        //                  .Style(defaultStyle);

        //            column.Item()
        //            .AlignLeft()
        //                  .PaddingRight(150)
        //                  .Text("Country : Egypt")
        //                  .Style(defaultStyle);

        //            column.Item()
        //            .AlignLeft()
        //               .PaddingRight(150)
        //               .Text("Phone : 01065578456")
        //               .Style(defaultStyle);

        //            column.Item().Height(50);
        //        });
        //    });
        //}


        //private void _ComposeContent(IContainer container)
        //{
        //    var customerName = $"MohamedAtef";

        //    container.Row(row =>
        //    {
        //        //// Add the Row with Customer Details and Invoice Info
        //        row.RelativeItem().Column(column =>
        //        {
        //            column.Spacing(5);

        //            column.Item().Row(row =>
        //            {
        //                row.RelativeItem().Text("Invoice To:").Style(TextStyle.Default.SemiBold());
        //                row.RelativeItem()
        //                  .PaddingRight(110)
        //                  .Text(text =>
        //                  {
        //                      text.Span("Invoice No:").Style(TextStyle.Default.SemiBold());
        //                      text.Span("100");
        //                  });
        //            });

        //            column.Item().Row(row =>
        //            {
        //                row.RelativeItem().Text(customerName);
        //                row.RelativeItem()
        //                   .PaddingRight(110)
        //                   .Text(text =>
        //                   {
        //                       text.Span("Invoice Date ").Style(TextStyle.Default.SemiBold());
        //                       text.Span("22/2/2024");
        //                   });
        //            });

        //           /* column.Item().Row(row =>
        //            {
        //                row.RelativeItem().Text("100");
        //                if (!string.IsNullOrWhiteSpace("111"))
        //                    row.RelativeItem()
        //                       .PaddingRight(110)
        //                       .Text(text =>
        //                       {
        //                           text.Span("طريقة الدفع: ").Style(TextStyle.Default.SemiBold());
        //                           text.Span("1");
        //                       });
        //            });*/

        //            column.Item().Text("Address : Cairo");
        //            column.Item().Height(30);

        //            _ComposeInvoiceDetailsTable(column);

        //            _ComposeInvoiceTotalsTable(column);

        //            column.Item().Height(40);

        //        });
        //    });
        //}

        //private void _ComposeInvoiceDetailsTable(ColumnDescriptor column)
        //{
        //    column.Item().AlignCenter().Table(table =>
        //    {
        //        // step 1
        //        table.ColumnsDefinition(columns =>
        //        {





        //            columns.RelativeColumn(50);
        //            columns.ConstantColumn(70);
        //            columns.ConstantColumn(180);
        //            columns.ConstantColumn(80);

        //        });

        //        // step 2
        //        table.Header(header =>
        //        {
        //            header.Cell().Element(TermCellStyle).Padding(5).Text("Quantity");
        //            header.Cell().Element(CellStyle).Padding(5).Text("Unit Price");
        //            header.Cell().Element(CellStyle).Padding(5).Text("Description");

        //            header.Cell().Element(CellStyle).Padding(5).Text("Product");


        //            static IContainer CellStyle(IContainer container)
        //            {
        //                return container.DefaultTextStyle(x => x.SemiBold())
        //                                .BorderTop(1)
        //                                .BorderBottom(1)
        //                                .Background(Colors.Grey.Lighten2);
        //            }

        //            static IContainer TermCellStyle(IContainer container)
        //            {
        //                return container.DefaultTextStyle(x => x.SemiBold())
        //                                .BorderTop(1)
        //                                .BorderBottom(1)
        //                                .BorderRight(1)
        //                                .Background(Colors.Grey.Lighten2);
        //            }

        //            static IContainer TotalCellStyle(IContainer container)
        //            {
        //                return container.DefaultTextStyle(x => x.SemiBold())
        //                                .BorderTop(1)
        //                                .BorderBottom(1)
        //                                .BorderLeft(1)
        //                                .Background(Colors.Grey.Lighten2);
        //            }
        //        });


        //    });
        //}

        //private void _ComposeInvoiceTotalsTable(ColumnDescriptor column)
        //{
        //    var currencyText = "EGP";

        //    column.Item().Row(row =>
        //    {
        //        row.ConstantItem(270);

        //        row.RelativeItem().Table(table =>
        //        {
        //            table.ColumnsDefinition(columns =>
        //            {
        //                columns.RelativeColumn();
        //                columns.RelativeColumn();
        //            });


        //            //table.Cell().Element(CellStyle).AlignRight().Text("(%0) صفرية").Style(TextStyle.Default.SemiBold());
        //            //table.Cell().Element(CellStyle).AlignLeft().Text(_model.TotalPrice.ToNumberFormat() + " " + currencyText);
        //            table.Cell().Element(TotalCellStyle).AlignRight().Text($"Vat 15%").Style(TextStyle.Default.SemiBold());
        //            table.Cell().Element(TotalCellStyle).AlignLeft().Text(500 + " " + currencyText);

        //            table.Cell().Element(TotalCellStyle).AlignRight().Text("Total").Style(TextStyle.Default.SemiBold());
        //            table.Cell().Element(TotalCellStyle).AlignLeft().Text(600 + " " + currencyText);

        //            table.Cell().Element(TotalCellStyle).AlignRight().Text("Payed").Style(TextStyle.Default.SemiBold());
        //            table.Cell().Element(TotalCellStyle).AlignLeft().Text(800 + " " + currencyText);

        //            table.Cell().Element(TotalCellStyle).AlignRight().Text("Amount").Style(TextStyle.Default.SemiBold());
        //            table.Cell().Element(TotalCellStyle).AlignLeft().Text(150 + " " + currencyText);

        //            static IContainer TotalCellStyle(IContainer container)
        //            {
        //                return container.BorderBottom(1).BorderColor(Colors.Black).PaddingVertical(5);
        //            }
        //        });
        //    });
        //}
        //private byte[] GenerateBarcode(string invoiceNumber)
        //{
        //    using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
        //    {
        //        // Generate the QR code data
        //        QRCodeData qrCodeData = qrGenerator.CreateQrCode(invoiceNumber, QRCodeGenerator.ECCLevel.Q);

        //        // Create a QR code from the QRCodeData
        //        var qrCode = new QRCode(qrCodeData);

        //        // Convert the QR code to a Bitmap image
        //        using (Bitmap qrCodeImage = qrCode.GetGraphic(20)) // 20 is the pixel size for the QR code
        //        {
        //            // Convert the Bitmap to a base64 string to embed in HTML or return as image
        //            using (MemoryStream ms = new MemoryStream())
        //            {
        //                qrCodeImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png); // Save to memory stream as PNG
        //                byte[] byteImage = ms.ToArray();
        //                return byteImage; // Return as base64 string
        //            }
        //        }
        //    }
        //}
    }
}
