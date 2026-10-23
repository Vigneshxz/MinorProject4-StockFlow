
using MinorProject4.Web.Components;

var builder = WebApplication.CreateBuilder(args);

// MySQL database connection
var connectionString =
    builder.Configuration.GetConnectionString("StockFlow")
    ?? throw new InvalidOperationException(
        "StockFlow connection string is missing.");

builder.Services.AddSingleton(
    new MinorProject4.Data.DbConnectionFactory(connectionString));
    builder.Services.AddScoped<MinorProject4.Data.ProductRepository>();
    builder.Services.AddScoped<MinorProject4.Data.SupplierRepository>();
    builder.Services.AddScoped<MinorProject4.Data.CategoryRepository>();
    builder.Services.AddScoped<MinorProject4.Data.PurchaseOrderRepository>();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute(
    "/not-found", createScopeForStatusCodePages: true);

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
