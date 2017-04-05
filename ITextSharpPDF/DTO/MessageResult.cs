namespace ITextSharpPDF.DTO
{
    public enum ResultType
    {
        Error = -1,
        Info = 0,
        Success = 1,
    }

    public class MessageResult
    {
        public ResultType ResultType { get; set; }
        public string Data { get; set; }
        public string Message { get; set; }
    }
}