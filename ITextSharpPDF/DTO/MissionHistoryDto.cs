using System;

namespace ITextSharpPDF.DTO
{
    public class MissionHistoryDto 
    {
        public long Id { get; set; }
        public long? MissionId { get; set; }
        public MissionDto Mission { get; set; }
        public long? ActionBy { get; set; }
        public string ActionByName { get; set; }
        public DateTime? ActionDate { get; set; }
        public string Notes { get; set; }
        public string Status { get; set; }
    }
}