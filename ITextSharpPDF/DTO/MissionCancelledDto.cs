using System;

namespace ITextSharpPDF.DTO
{
    public class MissionCancelledDto
    {
        public long MissionId { get; set; }
        public DateTime Date { get; set; }
        public long CancellationTypeId { get; set; }
        public string Customer { get; set; }
        public string Product { get; set; }
        public string DemoSite { get; set; }
        public string TypeName { get; set; }
        public string DemoWorker { get; set; }
        public string Reason { get; set; }
        public string Active { get; set; }
        public string Comment { get; set; }
    }
}
