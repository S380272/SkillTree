using Homework_SkillTree.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//  DbContext
builder.Services.AddDbContext<MyBlogContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("SkillTreeDatabase"));
    // 顯示參數值
    options.EnableSensitiveDataLogging();
    // 僅輸出 SQL 指令
    options.LogTo(
        Console.WriteLine,
        new[] { DbLoggerCategory.Database.Command.Name },
        LogLevel.Information);
});

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<Homework_SkillTree.Services.IAccountBookService, Homework_SkillTree.Services.AccountBookService>();

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
