namespace X.Domain.Shared;

public class ErrorResult
{
    public int StatusCode { get; set; }
    public string Message { get; set; }
    public string StackTrace { get; set; }
    public string TraceId { get; set; }
}
