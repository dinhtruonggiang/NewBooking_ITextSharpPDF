using System;

namespace ITextSharpPDF.DTO
{
    public class BlockedDemoWorkerDto
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public long DemoWorkerId { get; set; }
        public string DemoWorkerName { get; set; }
        public string CustomerName { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string Note { get; set; }
        public bool IsForeverBlocked { get; set; }
    }
}
