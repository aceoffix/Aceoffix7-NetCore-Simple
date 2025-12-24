var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Aceoffix configuration is mandatory.
builder.Services.AddAceoffixAcewServer();//Available starting from Aceoffix v7.3.1.1

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
//Aceoffix configuration is mandatory.
//Note: These two lines of code must be placed before app.UseRouting().
app.UseAceoffixAcewServer();//Available starting from Aceoffix v7.3.1.1
app.UseMiddleware<AceoffixNetCore.AceServer.ServerHandlerMiddleware>();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
