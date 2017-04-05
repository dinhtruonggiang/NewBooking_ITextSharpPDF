using System;

namespace ITextSharpPDF.DTO
{
    public class AbsenceDto
    {
        public long Id { get; set; }
        public long DemoWorkerId { get; set; }
        public DemoWorkerDto DemoWorker { get; set; }
        public int CategoryId { get; set; }
        public AbsenceCategoryDto Category { get; set; }

        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string Note { get; set; }
        public bool Active { get; set; }
        public string SelectedDates { get; set; }
    }
}