namespace ITextSharpPDF.DTO
{
    public partial class InvoiceDto 
    {
        public long Id { get; set; }
        public long? MissionId { get; set; }
        public MissionDto Mission { get; set; }
        public string StartHour { get; set; }
        public string EndHour { get; set; }
        public decimal? Prep { get; set; }
        public decimal? ExtraTransport { get; set; }
        public decimal? TotalHour { get; set; }
        public decimal? KMStart { get; set; }
        public decimal? KMEnd { get; set; }
        public decimal? KMTotal { get; set; }
        public decimal? Bought { get; set; }
        public decimal? Price { get; set; }
        public bool? Invoiced { get; set; }
        public int? Month { get; set; }
        public int? Year { get; set; }
        public int? MonthSal { get; set; }
        public int? YearSal { get; set; }
        public decimal? Hours { get; set; }
        public decimal? HoursSal { get; set; }
        public decimal? Salary { get; set; }
        public decimal? Price2 { get; set; }
        public bool? Invoiced2 { get; set; }
        public int? Month2 { get; set; }
        public int? Year2 { get; set; }
    }
}