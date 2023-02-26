using RazorPageEFCDemo.Data;
using RazorPageEFCDemo.Services.Repositories.EFC.Model;
using RazorPageEFCDemo.Services.Repositories.General.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<EFCDemoContext>();

builder.Services.AddSingleton<IItemRepository, EFCItemRepository>();
builder.Services.AddSingleton<ICustomerRepository, EFCCustomerRepository>();
builder.Services.AddSingleton<IOrderRepository, EFCOrderRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<EFCDemoContext>();
    context.Database.EnsureCreated();
    // DbInitializer.Initialize(context);
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
