using AzAppDevContainer.App.Data;
using AzAppDevContainer.App.Domain;
using Microsoft.EntityFrameworkCore;

var myAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigins,
        policy =>
        {
            policy
                .AllowAnyHeader()
                .AllowAnyOrigin()
                .AllowAnyMethod();
        });
});

var connectionString = builder.Configuration.GetConnectionString("AzApp");
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

using var scope = app.Services.CreateScope();
var db = scope.ServiceProvider.GetService<DataContext>();
db.Database.Migrate();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(myAllowSpecificOrigins);

app.MapPost("/customer", async (Customer customer, DataContext context) =>
    {
        await context.Customers.AddAsync(customer);
        await context.SaveChangesAsync();
        return Results.Created($"/customer/{customer.Id}", customer);
    })
    .WithName("Create Customer")
    .WithOpenApi();

app.MapGet("/customer/{id}", async (int id, DataContext context) =>
    {
        var customer = await context.Customers.Where(p => p.Id == id).FirstOrDefaultAsync();
        return customer is null ? Results.NotFound() : Results.Ok(customer);
    })
    .WithName("Get Customer")
    .WithOpenApi();

app.Run();