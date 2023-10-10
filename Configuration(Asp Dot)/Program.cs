using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
var app = builder.Build();

app.UseRouting();
app.MapControllers();
app.UseEndpoints(endpoints =>
{
    endpoints.Map("/", async context =>
    {
        await context.Response.WriteAsync(app.Configuration["test"]);//directly 
        await context.Response.WriteAsync(app.Configuration.GetValue<string>("test") + "\n");//using getvalue

    });
});

app.Run();
