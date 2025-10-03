using System.Data;
using BookingApp.Application.Interfaces;
using BookingApp.Infrastructure.Repositories;
using BookingApp.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using BookingApp.Application.Interfaces.Admin;
using BookingApp.Infrastructure.Services.Admin;

var builder = WebApplication.CreateBuilder(args);

// Add CORS FIRST - before any other services
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins(
                "http://localhost:5173",    // Vite dev server
                "http://localhost:3000",    // React dev server
                "http://192.168.31.8",      // Your backend IP
                "http://localhost"          // Localhost
            )
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();  // Add this if you're using cookies/auth
    });
});

builder.Services.AddControllers().AddJsonOptions(opts =>
{
    opts.JsonSerializerOptions.Converters.Add(new BookingApp.Infrastructure.Serialization.DateOnlyConverter());
    opts.JsonSerializerOptions.PropertyNamingPolicy = null;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "BookingApp API", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter 'Bearer' [space] and then your valid token."
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
            new string[] { }
        }
    });
});


builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddScoped<IUserProfileService, UserProfileService>();
builder.Services.AddScoped<IFlightService, FlightService>();
builder.Services.AddScoped<IHotelService, HotelService>();
builder.Services.AddScoped<IAmenityService, AmenityService>();
builder.Services.AddScoped<IHotelDetailService, HotelDetailService>();
builder.Services.AddScoped<IHotelRoomService, HotelRoomService>();
builder.Services.AddScoped<ISimilarPropertyService, SimilarPropertyService>();
builder.Services.AddScoped<IHotelDiningService, HotelDiningService>();
builder.Services.AddScoped<IHotelLocationService, HotelLocationService>();
builder.Services.AddScoped<IHotelPolicyService, HotelPolicyService>();
builder.Services.AddScoped<IFlightFareService, FlightFareService>();
builder.Services.AddScoped<IHotelBookingService, HotelBookingService>();
builder.Services.AddScoped<IFlightBookingService, FlightBookingService>();
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<IUserManagementService, UserManagementService>();
builder.Services.AddScoped<IAdminOverviewService, AdminOverviewService>();
builder.Services.AddScoped<IAdminFlightService, AdminFlightService>();
builder.Services.AddScoped<IAdminHotelSearchService, AdminHotelSearchService>();
builder.Services.AddScoped<IAdminAmenityService, AdminAmenityService>();
builder.Services.AddScoped<IAdminHotelDiningService, AdminHotelDiningService>();
builder.Services.AddScoped<IAdminHotelLocationService, AdminHotelLocationService>();
builder.Services.AddScoped<IAdminHotelPolicyService, AdminHotelPolicyService>();
builder.Services.AddScoped<IAdminHotelRoomService, AdminHotelRoomService>();
builder.Services.AddScoped<IAdminHotelService, AdminHotelService>();
builder.Services.AddScoped<IAdminSimilarPropertyService, AdminSimilarPropertyService>();
builder.Services.AddScoped<IAdminBookingService, AdminBookingService>();
builder.Services.AddScoped<IAdminFlightFareService, AdminFlightFareService>();
builder.Services.AddScoped<ICoTravellerService, CoTravellerService>();
builder.Services.AddScoped<ICloudStorageService, CloudStorageService>();

builder.Services.AddScoped<IDbConnection>(sp =>
    new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserProfileRepository, UserProfileRepository>();
builder.Services.AddScoped<IFlightRepository, FlightRepository>();
builder.Services.AddScoped<IHotelRepository, HotelRepository>();
builder.Services.AddScoped<ICoTravellerRepository, CoTravellerRepository>();
builder.Services.AddScoped<IAmenityRepository, AmenityRepository>();
builder.Services.AddScoped<IHotelDetailRepository, HotelDetailRepository>();
builder.Services.AddScoped<IHotelRoomRepository, HotelRoomRepository>();
builder.Services.AddScoped<ISimilarPropertyRepository, SimilarPropertyRepository>();
builder.Services.AddScoped<IHotelDiningRepository, HotelDiningRepository>();
builder.Services.AddScoped<IHotelLocationRepository, HotelLocationRepository>();
builder.Services.AddScoped<IHotelPolicyRepository, HotelPolicyRepository>();
builder.Services.AddScoped<IFlightFareRepository, FlightFareRepository>();
builder.Services.AddScoped<IHotelBookingRepository, HotelBookingRepository>();
builder.Services.AddScoped<IFlightBookingRepository, FlightBookingRepository>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IUserManagementRepository, UserManagementRepository>();
builder.Services.AddScoped<IAdminOverviewRepository, AdminOverviewRepository>();
builder.Services.AddScoped<IAdminFlightRepository, AdminFlightRepository>();
builder.Services.AddScoped<IAdminHotelSearchRepository, AdminHotelSearchRepository>();
builder.Services.AddScoped<IAdminAmenitiesRepository, AdminAmenitiesRepository>();
builder.Services.AddScoped<IAdminHotelDiningRepository, AdminHotelDiningRepository>();
builder.Services.AddScoped<IAdminHotelLocationRepository, AdminHotelLocationRepository>();
builder.Services.AddScoped<IAdminHotelPolicyRepository, AdminHotelPolicyRepository>();
builder.Services.AddScoped<IAdminHotelRoomRepository, AdminHotelRoomRepository>();
builder.Services.AddScoped<IAdminHotelRepository, AdminHotelRepository>();
builder.Services.AddScoped<IAdminSimilarPropertyRepository, AdminSimilarPropertyRepository>();
builder.Services.AddScoped<IAdminBookingRepository, AdminBookingRepository>();
builder.Services.AddScoped<IAdminFlightFareRepository, AdminFlightFareRepository>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddSingleton(new RazorpayConfig
{
    Key = "rzp_test_HDLC1terx8qsOw",
    Secret = "cSp2QVNmuWYPuNpssNrHyEyA"
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
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
            Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"]))
    };

    options.Events = new JwtBearerEvents
    {
        OnTokenValidated = context =>
        {
            var identity = context.Principal?.Identity as ClaimsIdentity;
            var claim = identity?.FindFirst("UserAuthId");
            if (claim != null)
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, claim.Value));
            return Task.CompletedTask;
        }
    };
});

// ========== BUILD THE APP ==========
var app = builder.Build();
// ===================================

// ========== MIDDLEWARE CONFIGURATION ==========

// 1. CORS first (use the policy you defined above)
app.UseCors("AllowFrontend");

// 2. Routing
app.UseRouting();

// 3. Authentication & Authorization
app.UseAuthentication();
app.UseAuthorization();

// 4. Swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "BookingApp API v1");
});

// 5. Endpoints
app.MapGet("/", context =>
{
    context.Response.Redirect("/swagger");
    return Task.CompletedTask;
});

app.MapControllers();

app.Run();