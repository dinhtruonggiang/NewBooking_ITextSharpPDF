using System.Collections.Generic;

namespace ITextSharpPDF.DTO
{
    public class ResponsePagingObject<T>
    {
        public int ItemsCount { get; set; }
        public List<T> Data { get; set; }
    }
}
