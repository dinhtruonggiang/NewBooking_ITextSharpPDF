namespace ITextSharpPDF.DTO
{
    public class SalaryReportDto
    {
        public long? DemoWorkerId { get; set; }
        public long? PersonellID { get; set; }
        public string Medarbeider { get; set; }
        public int? AntallOppdrag { get; set; }
        public decimal? TimerHverdag { get; set; }
        public decimal? TimerLordag { get; set; }
        public decimal? Tlf { get; set; }
        public decimal? KmTotal { get; set; }
        public decimal? Kj { get; set; }
        public decimal? Utlegg { get; set; }
        public decimal? SalaryTotal { get; set; }
        public decimal? Total { get; set; }
        public int? MonthSal { get; set; }
        public int? Month { get; set; }
        public int? SalaryNo { get; set; }
    }
}
