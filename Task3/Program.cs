using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Додаємо підтримку MVC (контролери + представлення)
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Увімкнення обробки статичних файлів (якщо є CSS/JS)
app.UseStaticFiles();

// Налаштування маршрутизації
app.UseRouting();

// (Не обов'язково, але якщо буде автентифікація/авторизація)
app.UseAuthorization();

// Додаємо маршрут за замовчуванням:
// http://localhost:5102 -> HomeController -> Index()
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();