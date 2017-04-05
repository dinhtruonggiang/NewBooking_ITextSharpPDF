using System;

namespace ITextSharpPDF.DTO
{
    public class MissionReportDto
    {
        public long MissionId { get; set; }
        public DateTime Date { get; set; }
        public string Customer { get; set; }
        public string Demosite { get; set; }
        public string DemoWorker { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Contact { get; set; }
        public string Region { get; set; }
        public string Phone { get; set; }
        public string CellPhone { get; set; }
        public string Product { get; set; }
    }
}
