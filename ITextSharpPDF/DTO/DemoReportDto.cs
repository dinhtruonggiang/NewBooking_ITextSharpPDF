using System;

namespace ITextSharpPDF.DTO
{
    public class DemoReportDto
    {
        public long ID { get; set; }
        public string Product { get; set; }
        public DateTime? Date { get; set; }
        public string DemoSite { get; set; }
        public string Received { get; set; }
        public string Samples { get; set; }
        public string Sale { get; set; }
        public string Benefits { get; set; }
        public string DemoEquipment { get; set; }
        public string Reception { get; set; }
        public int Status { get; set; }
        public string Comment { get; set; }
        public string DemoWorker { get; set; }
    }
}
