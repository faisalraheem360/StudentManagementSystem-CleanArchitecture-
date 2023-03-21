using CleanARCHiLMS_Application;
using CleanARCHiLMS_Infrastructure;
using Microsoft.EntityFrameworkCore;
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("https://localhost:7245"
                                              );
                      });
});
// add services to Configuration
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddMvc();
builder.Services.AddSwaggerGen();

//Add database Service 
builder.Services.AddDbContext<StudentDBContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),b=>b.MigrationsAssembly("CleanARCHiLMS_Api")));
builder.Services.AddScoped<IStudentServices, StudentServices>();
builder.Services.AddScoped<IStudentRepos, StudentRepos>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(MyAllowSpecificOrigins);
app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Student}/{action=Index}");

app.MapControllers();
app.Run();
