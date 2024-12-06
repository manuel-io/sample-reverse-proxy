using Yarp.ReverseProxy.Forwarder;

public class CustomTransformer : HttpTransformer
{
    public virtual async ValueTask TransformRequestAsync(HttpContext httpContext, HttpRequestMessage proxyRequest)
    {
        var requestBody = await httpContext.Request.ReadBodyAsync();
        Console.WriteLine($"Request to /test: {requestBody}");
    }

    public virtual async ValueTask TransformResponseAsync(HttpContext httpContext, HttpResponseMessage proxyResponse)
    {
        var responseBody = await proxyResponse.Content.ReadAsStringAsync();
        Console.WriteLine($"Response from /test: {responseBody}");
    }
}

public static class HttpExtensions
{
    public static async Task<string> ReadBodyAsync(this HttpRequest request)
    {
        request.EnableBuffering();
        var buffer = new byte[Convert.ToInt32(request.ContentLength)];
        await request.Body.ReadAsync(buffer, 0, buffer.Length);
        var bodyAsText = System.Text.Encoding.UTF8.GetString(buffer);
        request.Body.Position = 0;
        return bodyAsText;
    }
}