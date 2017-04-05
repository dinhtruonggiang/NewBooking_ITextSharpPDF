using System;

namespace ITextSharpPDF.DTO
{
    public class UnconfirmedMissionReportDto
    {
        public long ID { get; set; }
        public string Oppdragsgiver { get; set; }
        public string DemoSite { get; set; }
        public DateTime Date { get; set; }
        public int Status { get; set; }
        public string Comment { get; set; }
        public string ContactPerson { get; set; }
        public int RegionId { get; set; }
        public string Region { get; set; }
        public string DemoWorker { get; set; }
    }
}
