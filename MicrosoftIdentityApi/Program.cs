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

// Identity hizmetlerini AppUser ve IdentityRole<Guid> ile yapýlandýrýyoruz.
// AppUser, kullanýcýlarý temsil eden sýnýf; IdentityRole<Guid> ise roller için kullanýlan sýnýf.
builder.Services.AddIdentity<AppUser, IdentityRole<Guid>>(options =>
{
    // Parolanýn alfa-numerik olmayan karakterler içermesini zorunlu tutmayacak.
    options.Password.RequireNonAlphanumeric = false;

    // Parolanýn en az bir rakam içermesini zorunlu tutmayacak.
    options.Password.RequireDigit = false;

    // Parolanýn en az bir küçük harf içermesini zorunlu tutmayacak.
    options.Password.RequireLowercase = false;

    // Parolanýn en az bir büyük harf içermesini zorunlu tutmayacak.
    options.Password.RequireUppercase = false;

    // Parolanýn minimum uzunluðunu 1 karakter olarak ayarlayacak.
    options.Password.RequiredLength = 1;

    options.User.RequireUniqueEmail = true;
})
// Identity yapýlandýrmasýnda kullanýcý ve rol yönetimi için AppDbContext'i kullanacak.
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
