var builder = WebApplication.CreateBuilder(args);

// YARP yapýlandýrmasýný yüklüyoruz
builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

var app = builder.Build();

app.MapReverseProxy(); // Reverse proxy yönlendirmeleri aktifleþir

app.Run();
