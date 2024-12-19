using BarcodeStandard;

using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Org.BouncyCastle.Utilities;
using QRCoder;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using System.Drawing;
using Twilio.Rest.Routes.V2;
using VristoAPI.Application.Features.Products.Query.GetProductWithPagination;
using VristoAPI.Application.Models;
using VristoAPI.Application.Services;
using VristoAPI.Domain.DTOs;
using VristoAPI.Domain.Models;

using static System.Runtime.InteropServices.JavaScript.JSType;



namespace VristoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(ISender sender, IConfiguration config, ISMSSender smssender) : ControllerBase
    {
        [HttpGet]
        public async Task<PaginatedList<ProductDTO>> Get([FromQuery] GetProductWithPaginationQuery Query)
        {
            var c = await sender.Send(Query);
            return c;
        }

        [HttpPost]
        public async Task<bool> SendEmail(string Reciever)
        {



            var sender = new EmailSender(config);
            var x = await sender.SendEmail(Reciever, "WelcomeEmail.cshtml");
            return x;
        }
        [HttpPost]
        [Route("SendSMS")]
        public async Task<bool> SendSMS(string Phonenumber)
        {
            var x = smssender.Send(Phonenumber, "Gello");
            if (!string.IsNullOrEmpty(x.ErrorMessage))
            {
                return false;
            }
            else
            {
                return true;
            }

        }


        [HttpGet]
        [Route("GeneratePdf")]
        public IResult GeneratePdf()
        {
            // use any method to create a document, e.g.: injected service
            var document = GenerateComplexPdf();

            // generate PDF file and return it as a response

            return Results.File(document, "application/pdf", "hello-world.pdf");
        }
        private byte[] GenerateComplexPdf()
        {
            var document = Document.Create(container =>
            {
               
                container.Page(page =>
                {
                    page.Margin(50);
                    
                    page.Content()
                        .Column(column =>
                        {
                            // Header with Barcode on the left and Invoice info on the right
                            column.Item().Row(row =>
                            {
                                // Barcode on the left
                                row.RelativeItem().MaxWidth(100).MaxHeight(150).AlignTop().Image(GenerateBarcode("100"));

                                // Invoice information on the right
                                row.RelativeItem().AlignCenter().AlignRight().PaddingTop(20).Column(col =>
                                {
                                    col.Item().Text($"Invoice Number:100")
                                        .FontSize(14)
                                    .Bold();

                                    col.Item().Text($"Date: 22/7/2024")
                                        .FontSize(14)
                                    .Bold();

                                  

                                    col.Item().Text($"Bill To:MohamedAtef")
                                        .FontSize(14)
                                        .Bold();

                                });
                            });

                            // Add itemized table below
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.ConstantColumn(100); // Product/Service
                                    columns.ConstantColumn(150); // Description
                                    columns.ConstantColumn(100); // Unit Price
                                    columns.ConstantColumn(80);  // Quantity
                                    columns.ConstantColumn(100); // Total Price
                                });


                            });

                            // Total Amount
                            column.Item().AlignRight().Text($"Total: 100")
                                .FontSize(16)
                                .Bold();

                        });
                });
            });

            // Generate and save the PDF
            QuestPDF.Settings.License = LicenseType.Community;
            return document.GeneratePdf().ToArray();
        }

        private byte[] GenerateBarcode(string invoiceNumber)
        {
            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            {
                // Generate the QR code data
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(invoiceNumber, QRCodeGenerator.ECCLevel.Q);

                // Create a QR code from the QRCodeData
                var qrCode = new QRCode(qrCodeData);

                // Convert the QR code to a Bitmap image
                using (Bitmap qrCodeImage = qrCode.GetGraphic(20)) // 20 is the pixel size for the QR code
                {
                    // Convert the Bitmap to a base64 string to embed in HTML or return as image
                    using (MemoryStream ms = new MemoryStream())
                    {
                        qrCodeImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png); // Save to memory stream as PNG
                        byte[] byteImage = ms.ToArray();
                        return byteImage; // Return as base64 string
                    }
                }
            }
        }
    
    }
}
