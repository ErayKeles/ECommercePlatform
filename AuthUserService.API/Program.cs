var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// JWT, Redis, DbContext, AutoMapper gibi ek servis kay�tlar� buraya eklenir
// �rn:
// builder.Services.AddDbContext<AppDbContext>();
// builder.Services.AddAutoMapper(typeof(Program));
// builder.Services.AddScoped<IAuthService, AuthService>();

var app = builder.Build();

// Swagger sadece Dev ortam�nda aktif olsun
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection(); // sadece https �al���yorsa
app.UseAuthorization();    // Authentication da olacaksa app.UseAuthentication(); eklenmeli

app.MapControllers();

app.Run();
