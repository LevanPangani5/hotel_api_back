using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using WebApplication1;
using WebApplication1.Data;
using WebApplication1.Data.Model;
using WebApplication1.Services;
using WebApplication1.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Handle loopings during eager/lazy/... loadings || rewrite default JSON serializer settings: extra fields in response object
builder.Services.AddControllers()
 .AddJsonOptions(options =>
 {
     options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
     options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
 });

//Sql dadabase connection
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//automapper for DTO mapping
builder.Services.AddAutoMapper(typeof(Program).Assembly);

//Services dependency injection
builder.Services.AddScoped<ILectorService, LectorService>();
builder.Services.AddScoped<IAuthManager, AuthService>();
builder.Services.AddScoped<IHotelService, HotelService>();
builder.Services.AddScoped<IRoomService, RoomService>();
builder.Services.AddScoped<IBookingService, BookingService>();

//For identity 
//builder.Services.AddAuthentication();
//builder.Services.ConfigureIdentity();
builder.Services.AddIdentity<User, IdentityRole>()
       .AddEntityFrameworkStores<ApplicationDbContext>()
       .AddDefaultTokenProviders();

//Configuring JWT
builder.Services.ConfigureJWT(builder.Configuration);

//Allow Cors
builder.Services.AddCors(o =>
{
    o.AddPolicy("AllowAll", builder =>
     builder.AllowAnyOrigin()
     .AllowAnyMethod()
     .AllowAnyHeader());
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//Add swagger settings for JWT auth
builder.Services.AddSwaggerGen(c=>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT autherization header using the Beearer scheme.
          Example: Bearer yourToken123",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
          new OpenApiSecurityScheme
          {
              Reference= new OpenApiReference
              {
                  Type= ReferenceType.SecurityScheme,
                  Id="Bearer"
              },
              Scheme="Oauth2",
              Name="Bearer",
              In= ParameterLocation.Header
          },
          new List<string>()
        //  new ListenOptionsConnectionLoggingExtensions<string>
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigureExceptionHandler();

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
