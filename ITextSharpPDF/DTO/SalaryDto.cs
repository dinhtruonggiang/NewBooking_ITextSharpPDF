using System;

namespace ITextSharpPDF.DTO
{
    public class SalaryDto
    {
        public long Id { get; set; }
        public long DemoWorkerId { get; set; }
        public decimal? Regular { get; set; }
        public decimal? Extra { get; set; }
        public int? Month { get; set; }
        public DateTime? FromDate { get; set; }
        public long SalaryId { get; set; }
        public bool InitialSalary { get; set; }
        public bool IsCreate { get; set; }
        public bool IsUpdate { get; set; }
    }
}
