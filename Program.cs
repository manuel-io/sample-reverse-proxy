using Yarp.ReverseProxy.Transforms;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"))
    .AddTransforms(builderContext =>
    {
        builderContext.AddRequestTransform(async transformContext =>
        {
            var transform = new CustomTransformer();
            await transform.TransformRequestAsync(transformContext.HttpContext, transformContext.ProxyRequest);
        });
        builderContext.AddResponseTransform(async transformContext =>
        {
            var transform = new CustomTransformer();
            await transform.TransformResponseAsync(transformContext.HttpContext, transformContext.ProxyResponse);
        });
    });

builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenLocalhost(5027, listenOptions =>
    {
        listenOptions.UseHttps();
    });
});

var app = builder.Build();

app.UseHttpsRedirection();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapReverseProxy();
});

app.Run();