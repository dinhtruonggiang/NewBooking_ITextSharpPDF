namespace ITextSharpPDF.DTO
{
    public class MissionAttachmentDto 
    {
        public long Id { get; set; }
        public long? MissionId { get; set; }
        public MissionDto Mission { get; set; }
        public string FileName { get; set; }
        public string FileLocation { get; set; }
        public int? Order { get; set; }
    }
}