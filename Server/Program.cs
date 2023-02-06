using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Radzen;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.ModelBuilder;
using Microsoft.AspNetCore.OData;
using TravelLibrary.Server.Data;
using Microsoft.AspNetCore.Identity;
using TravelLibrary.Server.Models;
using Microsoft.AspNetCore.Components.Authorization;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<ContextMenuService>();
builder.Services.AddSingleton(sp =>
{
    // Get the address that the app is currently running at
    var server = sp.GetRequiredService<IServer>();
    var addressFeature = server.Features.Get<IServerAddressesFeature>();
    string baseAddress = addressFeature.Addresses.First();
    return new HttpClient{BaseAddress = new Uri(baseAddress)};
});
builder.Services.AddScoped<TravelLibrary.Server.dbTravelLIBService>();
builder.Services.AddDbContext<TravelLibrary.Server.Data.dbTravelLIBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("dbTravelLIBConnection"));
});
builder.Services.AddControllers().AddOData(opt =>
{
    var oDataBuilderdbTravelLIB = new ODataConventionModelBuilder();
    oDataBuilderdbTravelLIB.EntitySet<TravelLibrary.Server.Models.dbTravelLIB.Autore>("Autores");
    oDataBuilderdbTravelLIB.EntitySet<TravelLibrary.Server.Models.dbTravelLIB.AutoresHasLibro>("AutoresHasLibros").EntityType.HasKey(entity => new
    {
    entity.autores_id, entity.libros_ISBN
    });
    oDataBuilderdbTravelLIB.EntitySet<TravelLibrary.Server.Models.dbTravelLIB.Editoriale>("Editoriales");
    oDataBuilderdbTravelLIB.EntitySet<TravelLibrary.Server.Models.dbTravelLIB.Libro>("Libros");
    opt.AddRouteComponents("odata/dbTravelLIB", oDataBuilderdbTravelLIB.GetEdmModel()).Count().Filter().OrderBy().Expand().Select().SetMaxTop(null).TimeZone = TimeZoneInfo.Utc;
});
builder.Services.AddScoped<TravelLibrary.Client.dbTravelLIBService>();
builder.Services.AddHttpClient("TravelLibrary.Server").AddHeaderPropagation(o => o.Headers.Add("Cookie"));
builder.Services.AddHeaderPropagation(o => o.Headers.Add("Cookie"));
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();
builder.Services.AddScoped<TravelLibrary.Client.SecurityService>();
builder.Services.AddDbContext<ApplicationIdentityDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("dbTravelLIBConnection"));
});
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>().AddEntityFrameworkStores<ApplicationIdentityDbContext>().AddDefaultTokenProviders();
builder.Services.AddControllers().AddOData(o =>
{
    var oDataBuilder = new ODataConventionModelBuilder();
    oDataBuilder.EntitySet<ApplicationUser>("ApplicationUsers");
    var usersType = oDataBuilder.StructuralTypes.First(x => x.ClrType == typeof(ApplicationUser));
    usersType.AddProperty(typeof(ApplicationUser).GetProperty(nameof(ApplicationUser.Password)));
    usersType.AddProperty(typeof(ApplicationUser).GetProperty(nameof(ApplicationUser.ConfirmPassword)));
    oDataBuilder.EntitySet<ApplicationRole>("ApplicationRoles");
    o.AddRouteComponents("odata/Identity", oDataBuilder.GetEdmModel()).Count().Filter().OrderBy().Expand().Select().SetMaxTop(null).TimeZone = TimeZoneInfo.Utc;
});
builder.Services.AddScoped<AuthenticationStateProvider, TravelLibrary.Client.ApplicationAuthenticationStateProvider>();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.UseHeaderPropagation();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();
app.MapControllers();
app.MapFallbackToPage("/_Host");
app.Services.CreateScope().ServiceProvider.GetRequiredService<ApplicationIdentityDbContext>().Database.Migrate();
app.Run();