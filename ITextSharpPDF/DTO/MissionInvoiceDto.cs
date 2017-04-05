namespace ITextSharpPDF.DTO
{
    public class MissionInvoiceDto
    {
        public MissionDto Mission { get; set; }
        public InvoiceDto Invoice { get; set; }
        public MissionProductDto[] customerProductList { get; set; }
        public MissionProductDto[] customerProductList2 { get; set; }
    }
}