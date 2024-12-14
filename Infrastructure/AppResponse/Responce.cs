using System.Net;
using Infrastructure.Services;

namespace Infrastructure.AppResponse;

public class Responce<T>
{
    public Responce(HttpStatusCode statusCode, string message)
    {
        Data=default;
        StatusCode = (int)statusCode;
        Message = message;
    }

    public Responce(T? data)
    {
        Data = data;
        StatusCode = 200;
        Message = "";
    }
    
    public int StatusCode{ get; set; }
    public T? Data { get; set; }
    public string? Message { get; set; }
}