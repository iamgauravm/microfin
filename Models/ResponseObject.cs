namespace MicroFIN.Models;

public class ResponseObject<T>
{
    public ResponseObject(T _data)
    {
        data = _data;
        Success = true;
    }
    public ResponseObject(T _data,bool success, string errorMsg)
    {
        data = _data;
        Success = success;
        Message = errorMsg;
    }
    public bool Success { get; set; }
    public string Message { get; set; }
    public T data { get; set; }
    
}