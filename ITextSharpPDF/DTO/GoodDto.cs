namespace ITextSharpPDF.DTO
{
    public class GoodDto 
    {
        public long Id { get; set; }
        public long? MissionId { get; set; }
        public MissionDto Mission { get; set; }
        public long? Number { get; set; }
        public string Text { get; set; }
        public decimal? Amount { get; set; }
        public decimal? Price { get; set; }
    }
}