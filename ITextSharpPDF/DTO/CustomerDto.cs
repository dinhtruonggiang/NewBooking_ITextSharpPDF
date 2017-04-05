namespace ITextSharpPDF.DTO
{
    public class CustomerDto
    {
        public CustomerDto()
        {
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public int? Status { get; set; }
        public int? Pg { get; set; }
        public string OrgNo { get; set; }
        public string Number { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public decimal?FreeKM { get; set; }
    }
}