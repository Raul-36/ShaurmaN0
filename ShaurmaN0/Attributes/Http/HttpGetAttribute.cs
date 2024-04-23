namespace ShaurmaN0.Attributes.Http;

using ShaurmaN0.Attributes.Http.Base;

public class HttpGetAttribute : HttpAttribute
{
    public HttpGetAttribute() : base("GET")
    {
    }
}