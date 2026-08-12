using CleanArchitectureMvc.Domain.Account;
using CleanArchitectureMvc.Infra.IoC;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddInfrastructure(builder.Configuration);

WebApplication app = builder.Build();

ISeedUserRoleInitial seedUserRoleInitial = app.Services.GetRequiredService<ISeedUserRoleInitial>();

// Configure the HTTP request pipeline.
if(!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseRouting();

seedUserRoleInitial.SeedRoles();
seedUserRoleInitial.SeedUsers();

app.UseAuthentication();
app.UseAuthorization();
app.MapStaticAssets();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
).WithStaticAssets();
app.Run();