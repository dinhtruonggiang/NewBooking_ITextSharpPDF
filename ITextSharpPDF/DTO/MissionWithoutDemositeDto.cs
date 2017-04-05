using System;

namespace ITextSharpPDF.DTO
{
  public class MissionWithoutDemositeDto
  {
    public long MissionId { get; set; }
    public DateTime Date { get; set; }
    public string CustomerName { get; set; }
    public string DemoWorkerName { get; set; }
    public string DemoSiteName { get; set; }
    public long DemoSiteId { get; set; }
    }
}
