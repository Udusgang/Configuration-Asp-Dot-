using Configuration_Asp_Dot_;
using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<ParentOptions>(builder.Configuration.GetSection("parent"));
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
        await context.Response.WriteAsync(app.Configuration.GetValue<string>("test","default one") + "\n");//if test not found default is used
        /* $ENV: Parent__Child2 = "Value from Child2"*/    //for config key from environment
    });
});

app.Run();
