using System;

namespace ITextSharpPDF.DTO
{
    public class InvoiceReportDto
    {
        public long Id { get; set; }
        public DateTime? Date { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public int? TotalMission { get; set; }
        public decimal? AvtPris { get; set; }
        public decimal? Smaksprover { get; set; }
        public decimal? Bestikk { get; set; }
        public decimal? BestikkPris { get; set; }
        public decimal? AccountPrice { get; set; }
        public decimal? RealKmTotal { get; set; }
        public decimal? KMPris { get; set; }
        public decimal? ExtraTransp { get; set; }
        public decimal? ExtraTranspPris { get; set; }
        public decimal? EqBought { get; set; }
        public decimal? PrepPris { get; set; }
        public decimal? Total { get; set; }
    }
}
