using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// ������ �������� MVC (���������� + �������������)
builder.Services.AddControllersWithViews();

var app = builder.Build();

// ��������� ������� ��������� ����� (���� � CSS/JS)
app.UseStaticFiles();

// ������������ �������������
app.UseRouting();

// (�� ����'������, ��� ���� ���� ��������������/�����������)
app.UseAuthorization();

// ������ ������� �� �������������:
// http://localhost:5102 -> HomeController -> Index()
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();