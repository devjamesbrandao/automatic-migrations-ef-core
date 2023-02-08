using Automatic_migrations.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

// Add DbContext ao container
builder.Services.AddDbContext<ProdutoContext>(
    x => x.UseSqlite("Data Source = Produtos.db")
    .LogTo(Console.WriteLine, LogLevel.Information)
);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

// Migra as últimas mudanças no banco de dados durante a inicialização (migrations)
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider
                    .GetRequiredService<ProdutoContext>();
    
    // Aqui a migração é executada
    dbContext.Database.Migrate();
}

app.Run();
