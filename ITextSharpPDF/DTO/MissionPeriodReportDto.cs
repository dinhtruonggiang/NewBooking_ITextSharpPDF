using System;

namespace ITextSharpPDF.DTO
{
    public class MissionPeriodReportDto
    {
        public long MissionId { get; set; }
        public DateTime? Date { get; set; }
        public string Product { get; set; }
        public string DemoSiteName { get; set; }
        public string Received { get; set; }
        public string Samples { get; set; }
        public string Sales { get; set; }
        public string FeedbackCustomer { get; set; }
        public string Other { get; set; }
        public string FeedbackDemoSite { get; set; }
        public string Comment { get; set; }
        public string DemoWorkerName { get; set; }
    }
}
