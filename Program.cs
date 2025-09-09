using Microsoft.EntityFrameworkCore;
using AuthApi.Services;
using AuthApi.Repositories;
using AuthApi.Data;

var builder = WebApplication.CreateBuilder(args);

// ----------------------------
// PostgreSQL connection
// ----------------------------
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
    
// ----------------------------
// Register services
// ----------------------------

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserService, UserService>();

// Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();




// ----------------------------
// Build app and configure pipeline
// ---------------------------
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.UseHttpsRedirection();

app.Run();