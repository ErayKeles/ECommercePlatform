using NotificationService;
using NotificationService.Messaging;
using NotificationService.Services;

var builder = Host.CreateApplicationBuilder(args);

// Hosted service
builder.Services.AddHostedService<Worker>();

// RabbitMQ Listener + Mail Sender gibi servisleri ekle
builder.Services.AddSingleton<IRabbitMqListener, RabbitMqListener>();
builder.Services.AddSingleton<IMailSender, MailSender>();

var host = builder.Build();
host.Run();
