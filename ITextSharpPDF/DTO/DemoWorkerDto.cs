using System;

namespace ITextSharpPDF.DTO
{
  public class DemoWorkerDto
  {
    public DemoWorkerDto()
    {

    }
    public long Id { get; set; }
    public long DemoWorkerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string PostalCode { get; set; }
    public string City { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public bool? ReceiveMail { get; set; }
    public int? Status { get; set; }
    public string CellPhone { get; set; }
    public int? RegionId { get; set; }
    public int? Availability { get; set; }
    public decimal? RegularSalary { get; set; }

    #region Salary extend properties
    public decimal? Regular { get; set; }
    public decimal? Extra { get; set; }
    public int? Month { get; set; }
    public WorkingDaySettingDto WorkingDaySetting { get; set; }
    #endregion

    public decimal? ExtraSalary { get; set; }
    public bool? Car { get; set; }
    public DateTime? BirthDate { get; set; }
    public bool? PhonePaid { get; set; }
    public string ShirtSize { get; set; }
    public string JacketSize { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public int? SalaryNo { get; set; }
    public bool? Boss { get; set; }
    public int? DateValue { get; set; }
    public int? MonthValue { get; set; }
    public string FullName => $"{FirstName} {LastName}";
    public bool? Ended { get; set; }
    public DateTime? EndedDate { get; set; }

  }
}
