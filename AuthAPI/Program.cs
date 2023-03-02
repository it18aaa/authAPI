

using AuthAPI.Helpers;
using AuthAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();


builder.Services.AddMvc();
builder.Services.AddControllers();

// pull our settings into strongly typed object from appsettings...
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

// config di container
builder.Services.AddScoped<IUserService,  UserService>();


// add a bit of swagger!

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseMiddleware<JwtMiddleware>();

//app.UseHttpsRedirection();
//app.UseAuthorization();

app.MapControllers();

//app.Run("http://localhost:4000");
app.Run();
