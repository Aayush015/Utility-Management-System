using Microsoft.EntityFrameworkCore;
using UtilityServiceAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// ✅ 1. Add services to the container (including PostgreSQL connection)
builder.Services.AddControllers(); // Enables controller-based API
builder.Services.AddEndpointsApiExplorer(); // Enables API exploration
builder.Services.AddSwaggerGen(); // Enables Swagger UI

// ✅ 2. Configure PostgreSQL Database Connection
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// ✅ 3. Configure CORS Policy
var corsPolicy = "AllowAll";
builder.Services.AddCors(options =>
{
    options.AddPolicy(corsPolicy, policy =>
    {
        policy.AllowAnyOrigin() // Allows requests from any domain
              .AllowAnyMethod() // Allows all HTTP methods (GET, POST, PUT, DELETE, etc.)
              .AllowAnyHeader(); // Allows all headers
    });
});

// ✅ 4. Build the application
var app = builder.Build();

// ✅ 5. Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();
app.UseCors(corsPolicy); // ✅ Enable CORS
app.UseAuthorization();
app.MapControllers(); // Enables controller-based routing

app.Run();