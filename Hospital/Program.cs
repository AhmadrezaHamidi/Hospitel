using Microsoft.EntityFrameworkCore;
using Hospital.Services;
using Hospital.Repository;
using MediatR;
using System.Reflection;
using Hospital.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;

using Hospital.Infrastructure.Data.Context;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Hospital.Infrastructure.Cryptography;

var builder = WebApplication.CreateBuilder(args);

var contectionString = builder.Configuration.GetConnectionString("Clinic_DB");
builder.Services.AddDbContext<ApplicationContext>(options =>
    {
        options.UseSqlServer(contectionString);
    });


// builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//     .AddJwtBearer(option =>
//     {
//         option.RequireHttpsMetadata = false;
//         option.SaveToken = true;

//         option.TokenValidationParameters = new TokenValidationParameters()
//         {
//             ClockSkew = TimeSpan.Zero,
//             RequireExpirationTime = true,
//             ValidateLifetime = true,
//             ValidateIssuer = true,
//             ValidIssuer = "SampleJwtIssuer",
//             ValidateAudience = true,
//             ValidAudience = "SampleJwtAudience",
//             ValidateIssuerSigningKey = true,
//             IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("akndgakl98qauhf9qhwhasufh9ush0SHF08ASHFAUHSF8")),

//         };
//     });


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<TokenGenerator>();
builder.Services.AddScoped<DoctorRepository>();
builder.Services.AddScoped<ReservationRepository>();
builder.Services.AddScoped<ShiftRepository>();
builder.Services.AddSingleton<IAES, AesOperator>();

builder.Services.AddMediatR(typeof(Program).GetTypeInfo().Assembly);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    AppplicationDtosConfigurations
    .Instance
    .Initialize();

    app.UseSwagger();

    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();

app.Run();
