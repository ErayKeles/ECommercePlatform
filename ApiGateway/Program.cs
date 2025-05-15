var builder = WebApplication.CreateBuilder(args);

// YARP yap�land�rmas�n� y�kl�yoruz
builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

var app = builder.Build();

app.MapReverseProxy(); // Reverse proxy y�nlendirmeleri aktifle�ir

app.Run();
