namespace ITextSharpPDF.DTO
{
    public class DemoSiteDto
    {
        public DemoSiteDto()
        {
        }

        public long Id { get; set; }
        public long DemoSiteId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public int Status { get; set; }
        public int RegionId { get; set; }
        public string Storeno { get; set; }
        public string SalesManName { get; set; }
        public string SalesManPhone { get; set; }
        public string Account { get; set; }
        public string Chain { get; set; }
        public string Profile { get; set; }
        public string GLN { get; set; }
    }
}