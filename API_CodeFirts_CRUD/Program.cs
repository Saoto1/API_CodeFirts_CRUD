using DB_Entidades;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Conexion a la DB
builder.Services.AddDbContext<DBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("BibliotecaConnection"));

});


var app = builder.Build();

//Inicia una migracion, para la creacion de lka base de datos, esto se ejecuta,cada vez
//que se inicia el proyecto.
//using (var scope = app.Services.CreateScope())
//{ 
//    var context = scope.ServiceProvider.GetRequiredService<DBContext>();
//    context.Database.Migrate();

//}

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
