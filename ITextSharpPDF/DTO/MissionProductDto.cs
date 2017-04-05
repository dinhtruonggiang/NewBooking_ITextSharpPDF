namespace ITextSharpPDF.DTO
{
    public class MissionProductDto
    {
        public long? MissionId { get; set; }
        public long? CustomerId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public string SubCategoryName { get; set; }
        public string Samples { get; set; }
        public string Accessories { get; set; }
        public string Sales { get; set; }
    }
}