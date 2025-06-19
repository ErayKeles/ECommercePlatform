var builder = WebApplication.CreateBuilder(args);

// Servisleri ekle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// MongoDB & RabbitMQ ayarlarý buraya
// builder.Services.Configure<MongoSettings>(builder.Configuration.GetSection("MongoDb"));
// builder.Services.AddSingleton<IOrderRepository, OrderRepository>();
// builder.Services.AddSingleton<IEventPublisher, RabbitMqPublisher>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
