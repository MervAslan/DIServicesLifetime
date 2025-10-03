using DI_Services_Lifetime.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<ISingletonGuidService, SingletonGuidService>(); // Singleton: same instance for every request and every service
builder.Services.AddScoped<IScopedGuidService, ScopedGuidService>(); // Scoped: same instance for a single request, different instance for different requests (you can see if you refresh the page)
builder.Services.AddTransient<ITransientGuidService, TransientGuidService>(); // Transient: different instance for every service and every request (you can see if you refresh the page)


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
