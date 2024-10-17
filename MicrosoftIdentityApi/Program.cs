using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MicrosoftIdentityApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
});

// Identity hizmetlerini AppUser ve IdentityRole<Guid> ile yap�land�r�yoruz.
// AppUser, kullan�c�lar� temsil eden s�n�f; IdentityRole<Guid> ise roller i�in kullan�lan s�n�f.
builder.Services.AddIdentity<AppUser, IdentityRole<Guid>>(options =>
{
    // Parolan�n alfa-numerik olmayan karakterler i�ermesini zorunlu tutmayacak.
    options.Password.RequireNonAlphanumeric = false;

    // Parolan�n en az bir rakam i�ermesini zorunlu tutmayacak.
    options.Password.RequireDigit = false;

    // Parolan�n en az bir k���k harf i�ermesini zorunlu tutmayacak.
    options.Password.RequireLowercase = false;

    // Parolan�n en az bir b�y�k harf i�ermesini zorunlu tutmayacak.
    options.Password.RequireUppercase = false;

    // Parolan�n minimum uzunlu�unu 1 karakter olarak ayarlayacak.
    options.Password.RequiredLength = 1;

    options.User.RequireUniqueEmail = true;
})
// Identity yap�land�rmas�nda kullan�c� ve rol y�netimi i�in AppDbContext'i kullanacak.
.AddEntityFrameworkStores<AppDbContext>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
