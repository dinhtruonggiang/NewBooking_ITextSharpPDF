using System;

namespace ITextSharpPDF.DTO
{
    public class PriceGroupDto
    {
        public PriceGroupDto()
        {
        }

        public int Id { get; set; }
        public int Group { get; set; }
        public decimal? Regular { get; set; }
        public decimal? Extra { get; set; }
        public decimal? Prep { get; set; }
        public decimal? Driving { get; set; }
        public bool Active { get; set; }
        public DateTime? FromDate { get; set; }
    }
}