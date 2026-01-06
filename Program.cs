using backend.Data;
using backend.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// ---------------- DATABASE ----------------
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// ---------------- CORS ----------------
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy
            .WithOrigins("http://localhost:8080")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

// ---------------- CONTROLLERS ----------------
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// ---------------- SWAGGER + JWT ----------------
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter JWT token like: Bearer {your token}"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

// ---------------- APPLICATION SERVICES ----------------
builder.Services.AddScoped<OtpService>();
builder.Services.AddScoped<JwtService>();
builder.Services.AddScoped<EmailService>();

// In-memory / singleton services (as per your design)
builder.Services.AddSingleton<AMLService>();
builder.Services.AddSingleton<CountryRiskService>();
builder.Services.AddSingleton<DocumentService>();
builder.Services.AddSingleton<UserRoleService>();
builder.Services.AddScoped<TradeApplicationService>();
builder.Services.AddSingleton<LcAmendmentService>();
builder.Services.AddSingleton<BankGuaranteeService>();
builder.Services.AddSingleton<BgClaimService>();
builder.Services.AddScoped<PreShipmentService>();
builder.Services.AddScoped<PostShipmentService>();
builder.Services.AddSingleton<ApprovalService>();
builder.Services.AddSingleton<ApprovalStore>();
builder.Services.AddScoped<IReportsService, ReportsService>();
builder.Services.AddScoped<IMasterService, MasterService>();
builder.Services.AddScoped<BillDiscountingService>();

// ---------------- JWT AUTH ----------------
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],

        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!)
        ),

        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddAuthorization();

var app = builder.Build();



Console.WriteLine(
    BCrypt.Net.BCrypt.HashPassword("Admin123")
);


// ---------------- MIDDLEWARE ORDER ----------------
app.UseSwagger();
app.UseSwaggerUI();

app.UseRouting();

app.UseCors("AllowFrontend");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
