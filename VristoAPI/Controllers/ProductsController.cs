using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using Twilio.Rest.Routes.V2;
using VristoAPI.Application.Features.Products.Query.GetProductWithPagination;
using VristoAPI.Application.Models;
using VristoAPI.Application.Services;
using VristoAPI.Domain.DTOs;
using VristoAPI.Domain.Models;

namespace VristoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(ISender sender,IConfiguration config,ISMSSender smssender) : ControllerBase
    {
        [HttpGet]
        public async Task<PaginatedList<ProductDTO>> Get([FromQuery]GetProductWithPaginationQuery Query)
        {
            var c= await sender.Send(Query);
            return c;
        }

        [HttpPost]
        public async Task<bool> SendEmail(string Reciever)
        {

        

            var sender = new EmailSender(config);
            var x= await sender.SendEmail(Reciever, "WelcomeEmail.cshtml");
            return x;
        }
        [HttpPost]
        [Route("SendSMS")]
        public async Task<bool> SendSMS(string Phonenumber)
        {
           var x= smssender.Send(Phonenumber, "Gello");
            if (!string.IsNullOrEmpty(x.ErrorMessage))
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        private byte[] GenerateSamplePdf()
        {
            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(50);
                    page.Content().Column(column =>
                    {
                        column.Item().Text("Hello, World! This is a sample PDF.");
                        column.Item().Text($"Generated at: {DateTime.Now}");
                    });
                });
            });
            return document.GeneratePdf();
        }

        [HttpGet("generate-simple")]
        public IActionResult GenerateSimplePdf()
        {
            var pdfContent = GenerateSamplePdf();
            return File(pdfContent, "application/pdf", "sample.pdf");
        }

        // Generates a complex PDF
        [HttpGet("generate-complex")]
        public IActionResult GenerateComplexPdF()
        {
            var pdfContent = GenerateComplexPdf();
            return File(pdfContent, "application/pdf", "complex.pdf");
        }

        // Generates a more complex PDF
        private byte[] GenerateComplexPdf()
        {
            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(50);
                    page.Content().Column(column =>
                    {
                        column.Item().Text("Title: Complex PDF Example").FontSize(20).Bold();
                        column.Item().Text("This PDF contains a table and a styled text.");

                        column.Item().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.ConstantColumn(100);
                                columns.RelativeColumn();
                            });

                            table.Header(header =>
                            {
                                header.Cell().Text("ID");
                                header.Cell().Text("Name");
                            });

                            table.Cell().Text("1");
                            table.Cell().Text("John Doe");
                            table.Cell().Text("2");
                            table.Cell().Text("Jane Smith");
                        });
                    });
                });
            });

            QuestPDF.Settings.License = LicenseType.Community;
            return document.GeneratePdf();
        }
    }
}
