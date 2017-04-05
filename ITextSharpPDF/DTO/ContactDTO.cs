namespace ITextSharpPDF.DTO
{
    public class ContactDto
    {
        public ContactDto()
        {
        }
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string CellPhone { get; set; }
        public string Email { get; set; }
        public int Status { get; set; }
    }
}
