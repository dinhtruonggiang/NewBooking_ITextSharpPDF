using System;

namespace ITextSharpPDF.DTO
{
    public class MissionDto
    {
        public long Id { get; set; }
        public long DemoSiteId { get; set; }
        public DemoSiteDto DemoSite { get; set; }
        public long? CustomerId { get; set; }
        public CustomerDto Customer { get; set; }
        public long? DemoWorkerId { get; set; }
        public DemoWorkerDto DemoWorker { get; set; }
        public DateTime Date { get; set; }
        public string DateVal { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Other { get; set; }
        public string Product { get; set; }
        public string Dress { get; set; }
        public bool? ReportCustomer { get; set; }
        public string DemoSiteContactName { get; set; }
        public DateTime? PrintedDate { get; set; }
        public string Info { get; set; }
        public string Samples { get; set; }
        public string Sales { get; set; }
        public string FeedbackCustomer { get; set; }
        public string FeedBackDemoSite { get; set; }
        public string Comment { get; set; }
        public string Accessories { get; set; }
        public string GUID { get; set; }
        public string Initials { get; set; }
        public long? CustomerId2 { get; set; }
        public CustomerDto Customer2 { get; set; }
        public string Product2 { get; set; }
        public string Split { get; set; }
        public string Samples2 { get; set; }
        public string Sales2 { get; set; }
        public string Accessories2 { get; set; }
        public int? Seen { get; set; }
        public DateTime? DemoWorkerPrintedDate { get; set; }
        public DateTime? Customer1PrintedDate { get; set; }
        public DateTime? Customer2PrintedDate { get; set; }
        public int? ReportNo { get; set; }
        public string Received { get; set; }
        public string ProductCat1 { get; set; }
        public string ProductCat2 { get; set; }
        public string ProductSubCat1 { get; set; }
        public string ProductSubCat2 { get; set; }
        public string ShopContactPersonName { get; set; }
        public string ShopAgreedUponPlacement { get; set; }
        public bool? IsMissionCompleted { get; set; }
        public string[] SelectedEquipments { get; set; }
        public string[] Attachments { get; set; }
        public decimal? Price { get; set; }
        public decimal? Price2 { get; set; }
        public bool? IsSendSms { get; set; }
        public long? UnConfirmMissionId { get; set; }
        public bool? IsAssignedMission { get; set; }
        public GoodDto[] MissionGoods { get;set;}
        public string Front { get; set; }
        public string Rollups { get; set; }
    }
}