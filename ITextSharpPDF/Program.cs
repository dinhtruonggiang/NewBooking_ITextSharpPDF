using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using ITextSharpPDF.DTO;

namespace ITextSharpPDF
{
    class Program
    {
        static void Main(string[] args)
        {
            CreatePdf();
        }
        protected static string GetSolutionFSPath()
        {
            return System.IO.Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        }
        protected static string GetProjectFSPath()
        {
            return String.Format("{0}\\{1}", GetSolutionFSPath(), System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }

        static void CreatePdf()
        {
            //Create a byte array that will eventually hold our final PDF
            Byte[] bytes;

            //Boilerplate iTextSharp setup here
            //Create a stream that we can write to, in this case a MemoryStream
            using (var ms = new MemoryStream())
            {

                //Create an iTextSharp Document which is an abstraction of a PDF but **NOT** a PDF
                using (var doc = new Document())
                {

                    //Create a writer that's bound to our PDF abstraction and our stream
                    using (var writer = PdfWriter.GetInstance(doc, ms))
                    {

                        //Open the document for writing
                        doc.Open();

                        //Our sample HTML and CSS
                        //var example_html = @"<p>This <em>is </em><span class=""headline"" style=""text-decoration: underline;"">some</span> <strong>sample <em> text</em></strong><span style=""color: red;"">!!!</span></p>";
                        //var example_css = @".headline{font-size:200%}";
                        var currentPath = GetProjectFSPath();
                        var example_html = File.ReadAllText($"{currentPath}\\missionHtmlTemplate.html", Encoding.UTF8);
                        var example_css = File.ReadAllText($"{currentPath}\\missionCssTemplate.css", Encoding.UTF8);

                        var missionInvoice = GetMissionInvoice();
                        example_html = MergeDataWithHtmlTemplate(missionInvoice, example_html);

                        //                        /**************************************************
                        //                         * Example #1                                     *
                        //                         *                                                *
                        //                         * Use the built-in HTMLWorker to parse the HTML. *
                        //                         * Only inline CSS is supported.                  *
                        //                         * ************************************************/
                        //
                        //                        //Create a new HTMLWorker bound to our document
                        //                        using (var htmlWorker = new iTextSharp.text.html.simpleparser.HTMLWorker(doc))
                        //                        {
                        //
                        //                            //HTMLWorker doesn't read a string directly but instead needs a TextReader (which StringReader subclasses)
                        //                            using (var sr = new StringReader(example_html))
                        //                            {
                        //
                        //                                //Parse the HTML
                        //                                htmlWorker.Parse(sr);
                        //                            }
                        //                        }
                        //
                        //                        /**************************************************
                        //                         * Example #2                                     *
                        //                         *                                                *
                        //                         * Use the XMLWorker to parse the HTML.           *
                        //                         * Only inline CSS and absolutely linked          *
                        //                         * CSS is supported                               *
                        //                         * ************************************************/
                        //
                        //                        //XMLWorker also reads from a TextReader and not directly from a string
                        //                        using (var srHtml = new StringReader(example_html))
                        //                        {
                        //
                        //                            //Parse the HTML
                        //                            iTextSharp.tool.xml.XMLWorkerHelper.GetInstance().ParseXHtml(writer, doc, srHtml);
                        //                        }

                        /**************************************************
                         * Example #3                                     *
                         *                                                *
                         * Use the XMLWorker to parse HTML and CSS        *
                         * ************************************************/

                        //In order to read CSS as a string we need to switch to a different constructor
                        //that takes Streams instead of TextReaders.
                        //Below we convert the strings into UTF8 byte array and wrap those in MemoryStreams
                        using (var msCss = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(example_css)))
                        {
                            using (var msHtml = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(example_html)))
                            {
                                //Parse the HTML
                                iTextSharp.tool.xml.XMLWorkerHelper.GetInstance().ParseXHtml(writer, doc, msHtml, msCss);
                            }
                        }

                        doc.Close();
                    }
                }

                //After all of the PDF "stuff" above is done and closed but **before** we
                //close the MemoryStream, grab all of the active bytes from the stream
                bytes = ms.ToArray();
            }

            //Now we just need to do something with those bytes.
            //Here I'm writing them to disk but if you were in ASP.Net you might Response.BinaryWrite() them.
            //You could also write the bytes to a database in a varbinary() column (but please don't) or you
            //could pass them to another function for further PDF processing.
            var testFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "test.pdf");
            System.IO.File.WriteAllBytes(testFile, bytes);
        }

        static string MergeDataWithHtmlTemplate(MissionInvoiceDto missionInvoice, string htmlTemplate)
        {
            var htmlContent = htmlTemplate;
            var imgFolder = $"{GetProjectFSPath()}/images";
            var checkedImg = $"{GetProjectFSPath()}/images/checkmark.png";
            var unCheckedImg = $"{GetProjectFSPath()}/images/checkbox_unchecked.png";

            htmlContent = htmlContent.Replace("{{logoImg}}", $"{imgFolder}/logo3.png")
                .Replace("{{missionId}}", missionInvoice.Mission.Id.ToString())
                .Replace("{{missionDate}}", missionInvoice.Mission.Date.ToString("dd.MM.yyyy"))
                .Replace("{{currentDate}}", DateTime.Now.ToString("dd.MM.yyyy"))
                .Replace("{{customer1}}", missionInvoice.Mission.Customer.Name)
                .Replace("{{demoSiteContactName}}", missionInvoice.Mission.DemoSiteContactName)
                .Replace("{{shopContactPersonName}}", missionInvoice.Mission.ShopContactPersonName)
                .Replace("{{shopAgreedUponPlacement}}", missionInvoice.Mission.ShopAgreedUponPlacement)
                .Replace("{{product1}}", missionInvoice.Mission.Product)
                .Replace("{{productCat1}}", missionInvoice.Mission.ProductCat1)
                .Replace("{{productSubCat1}}", missionInvoice.Mission.ProductSubCat1)
                .Replace("{{dress}}", missionInvoice.Mission.Dress)
                .Replace("{{front}}", missionInvoice.Mission.Front)
                .Replace("{{rollups}}", missionInvoice.Mission.Rollups)
                .Replace("{{bordCheckImg}}",
                    missionInvoice.Mission.SelectedEquipments.Contains("1") ? checkedImg : unCheckedImg)
                .Replace("{{stekeovnCheckImg}}",
                    missionInvoice.Mission.SelectedEquipments.Contains("2") ? checkedImg : unCheckedImg)
                .Replace("{{kokeplateCheckImg}}",
                    missionInvoice.Mission.SelectedEquipments.Contains("3") ? checkedImg : unCheckedImg)
                .Replace("{{mikrobCheckImg}}",
                    missionInvoice.Mission.SelectedEquipments.Contains("4") ? checkedImg : unCheckedImg)
                .Replace("{{reportMissionCheckImg}}",
                    missionInvoice.Mission.ReportCustomer == true ? checkedImg : unCheckedImg)
                .Replace("{{other}}", missionInvoice.Mission.Other)
                .Replace("{{info}}", missionInvoice.Mission.Info)
                .Replace("{{demoWorker}}",
                    $"{missionInvoice.Mission.DemoWorker.FullName}, {missionInvoice.Mission.DemoWorker.Address}")
                .Replace("{{demoSite}}", missionInvoice.Mission.DemoSite.Name)
                .Replace("{{phoneNo}}", missionInvoice.Mission.DemoSite.Phone)
                .Replace("{{start}}", missionInvoice.Mission.StartTime)
                .Replace("{{end}}", missionInvoice.Mission.EndTime)
                .Replace("{{address}}",
                    $"{missionInvoice.Mission.DemoSite.Address}, {missionInvoice.Mission.DemoSite.PostalCode} {missionInvoice.Mission.DemoSite.City}")
                .Replace("{{account}}", missionInvoice.Mission.DemoSite.Account)
                .Replace("{{received}}", missionInvoice.Mission.Received)
                .Replace("{{sample}}", missionInvoice.Mission.Samples)
                .Replace("{{accessories}}", missionInvoice.Mission.Accessories)
                .Replace("{{sales}}", missionInvoice.Mission.Sales)
                .Replace("{{feedbackCustomer}}", missionInvoice.Mission.FeedbackCustomer)
                .Replace("{{feedBackDemoSite}}", missionInvoice.Mission.FeedBackDemoSite)
                .Replace("{{startHour}}", missionInvoice.Invoice.StartHour)
                .Replace("{{endHour}}", missionInvoice.Invoice.EndHour)
                .Replace("{{kmStart}}", missionInvoice.Invoice.KMStart.ToString())
                .Replace("{{kmEnd}}", missionInvoice.Invoice.KMEnd.ToString())
                .Replace("{{kmTotal}}", missionInvoice.Invoice.KMTotal.ToString())
                .Replace("{{totalHour}}", missionInvoice.Invoice.TotalHour.ToString())
                .Replace("{{extraTransport}}", missionInvoice.Invoice.ExtraTransport.ToString())
                .Replace("{{bought}}", missionInvoice.Invoice.Bought.ToString())
                .Replace("{{salary}}", missionInvoice.Invoice.Salary.ToString());

            var i = 0;

            while (i < 5)
            {
                var curIndex = i + 1;
                var goodName = i < missionInvoice.Mission.MissionGoods.Length
                    ? missionInvoice.Mission.MissionGoods[i].Text
                    : string.Empty;
                var goodAmount = i < missionInvoice.Mission.MissionGoods.Length
                    ? missionInvoice.Mission.MissionGoods[i].Amount.ToString()
                    : string.Empty;
                var goodPrice = i < missionInvoice.Mission.MissionGoods.Length
                    ? missionInvoice.Mission.MissionGoods[i].Price.ToString()
                    : string.Empty;

                htmlContent = htmlContent.Replace($"{{goodName{curIndex}}}", goodName)
                    .Replace($"{{goodAmount{curIndex}}}", goodAmount)
                    .Replace($"{{goodPrice{curIndex}}}", goodPrice);

                i++;
            }

            //Customer 1 Product content
            htmlContent = htmlContent.Replace($"{{Customer1_ProductZone}}", GetCustomerProductHtml(missionInvoice.customerProductList));

            //Show/hide customer 2 sections
            if (missionInvoice.Mission.Customer2 != null)
            {
                htmlContent = htmlContent.Replace("<!--Customer2", "").Replace("Customer2-->", "")
                    .Replace("{{product2}}", missionInvoice.Mission.Product2)
                    .Replace("{{productCat2}}", missionInvoice.Mission.ProductCat2)
                    .Replace("{{productSubCat2}}", missionInvoice.Mission.ProductSubCat2)
                    .Replace("{{customer2}}", missionInvoice.Mission.Customer2?.Name)
                    .Replace($"{{Customer2_ProductZone}}", GetCustomerProductHtml(missionInvoice.customerProductList2));
            }

            return htmlContent;
        }

        static string GetCustomerProductHtml(MissionProductDto[] missionProductDtos)
        {
            var productHtml = "";
            foreach (var customerProduct in missionProductDtos)
            {
                productHtml = productHtml + $@"<tr>		
                <td style='width:30px;border:1px solid;height:30'>
					&nbsp;
				</td>
				<td style='width:200px;font-size:8pt;border:1px solid;height:30'>
                    {customerProduct.ProductName}
                </ td >
                < td style='width:140px;font-size:8pt;border:1px solid'>
                    Category 1
                </td>
				<td style='width:130px;font-size:8pt;border:1px solid'>
                    {customerProduct.SubCategoryName}
                </td>			
				<td style='width:140px;font-size:8pt;border:1px solid;text-align:right'>
					{customerProduct.Samples}
                </td>						
				<td style='width:100px;font-size:8pt;border:1px solid;text-align:right'>
                    {customerProduct.Accessories}
                </td>			
				<td style='width:75px;font-size:8pt;border:1px solid;text-align:right'>
					{customerProduct.Sales}
                </td>			
			</tr>";
            }
            return productHtml;
        }

        static MissionInvoiceDto GetMissionInvoice()
        {
            
            MissionInvoiceDto missionInvoice = new MissionInvoiceDto
            {
                Mission  = new MissionDto
                {
                    Id = 29137,
                    Date = new DateTime(2017, 1, 3),
                    StartTime = "7.30",
                    EndTime = "8.30",
                    Customer = new CustomerDto
                    {
                        Name = "BERTHAS AS C/O FINDAL&KROGH"
                    },
                    DemoSiteContactName = "Demo Site Contact",
                    ShopContactPersonName ="Shop Contact",
                    ShopAgreedUponPlacement = "Shop Agreed",
                    SelectedEquipments = new string[] {"3", "4"},
                    ReportCustomer = true,
                    Other = "Other 111",
                    Info = "Info 222",
                    Received = "Ja",
                    Samples = "smaksprøver",
                    Accessories = "beger",
                    Sales = "salg",
                    FeedbackCustomer = "feedback Customer",
                    FeedBackDemoSite = "feedback Demo Site",
                    DemoWorker = new DemoWorkerDto
                    {
                        FirstName = "Tove",
                        LastName = "Ingvaldsen",
                        Address = "Ripnesbakken 9"
                    },
                    DemoSite = new DemoSiteDto
                    {
                        Name = "AGDER",
                        Phone = "123456789",
                        Address = "",
                        PostalCode = "0000",
                        City = "A",
                        Account = "987654321"
                    },
                    MissionGoods = new GoodDto[]
                    {
                        new GoodDto
                        {
                            Text = "Good 1",
                            Amount = 2,
                            Price = 2
                        },
                        new GoodDto
                        {
                            Text = "Good 2",
                            Amount = 5,
                            Price = 12
                        },
                    },
                    Front = "front section",
                    Rollups = "rollups/popups section"
                },
                Invoice = new InvoiceDto
                {
                    StartHour = "7.30",
                    KMStart = 3,
                    EndHour = "10.00",
                    KMEnd = 5,
                    ExtraTransport = 3,
                    KMTotal = 2,
                    TotalHour = 4,
                    Bought = 2,
                    Salary = 35
                },
                customerProductList = new []
                {
                    new MissionProductDto
                    {
                        ProductName = "Customer 1 Product 1",
                        Accessories = "Accesssories 1",
                        CategoryName = "Category 1",
                        Sales = "Sales 1",
                        Samples = "Samples 1",
                        SubCategoryName = "Sub Category 1"
                    },
                    new MissionProductDto
                    {
                        ProductName = "Product 2",
                        Accessories = "Accesssories 2",
                        CategoryName = "Category 2",
                        Sales = "Sales 2",
                        Samples = "Samples 2",
                        SubCategoryName = "Sub Category 2"
                    }
                },
                customerProductList2 = new []
                {
                    new MissionProductDto
                    {
                        ProductName = "Customer 2 Product 1",
                        Accessories = "Accesssories 1",
                        CategoryName = "Category 1",
                        Sales = "Sales 1",
                        Samples = "Samples 1",
                        SubCategoryName = "Sub Category 1"
                    },
                    new MissionProductDto
                    {
                        ProductName = "Product 2",
                        Accessories = "Accesssories 2",
                        CategoryName = "Category 2",
                        Sales = "Sales 2",
                        Samples = "Samples 2",
                        SubCategoryName = "Sub Category 2"
                    }
                }
            };

            return missionInvoice;
        }
    }
}

