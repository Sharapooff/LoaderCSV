using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using WebAppViewParams.Contexts;
using WebAppViewParams.Models;

namespace WebAppViewParams.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetParametrsAsync(string json_param)
        {
            String jsondata = "yohoho";

            // int? numberOfRowInserted;
            string json = "";

            var builder_SqlServer = new ConfigurationBuilder();
            builder_SqlServer.SetBasePath(Directory.GetCurrentDirectory());// установка пути к текущему каталогу
            builder_SqlServer.AddJsonFile("appsettings.json");// получаем конфигурацию из файла appsettings.json
            var config = builder_SqlServer.Build();// создаем конфигурацию
            string connectionString_SqlServer = config.GetConnectionString("SqlServer");// получаем строку подключения
            var optionsBuilder_SqlServer = new DbContextOptionsBuilder<ApplicationContext>();// опции контекста
            var options_SqlServer = optionsBuilder_SqlServer.UseSqlServer(connectionString_SqlServer).Options;

            try
            {
                using (ApplicationContext db = new ApplicationContext(options_SqlServer))
                {
                    Console.WriteLine("Подключение открыто");
                    //Вывод информации о подключении
                    Console.WriteLine($"\tСтрока подключения: {connectionString_SqlServer}");
                    //db.Database.EnsureDeleted(); //удаляем бд если она существует
                    //db.Database.EnsureCreated(); //если бд не существует, то она создается заново
                    //заносим данные из файла csv
                    var paramList = db.Parametrs.FromSqlRaw("SELECT * FROM dbo.Parametrs").ToList();
                    Console.WriteLine($"Добавлено объектов: ...");

                    jsondata = JsonSerializer.Serialize(paramList);

                }

            }
            catch (Exception ex)
            {
                string exept = ex.Message;
            }

            return Json(jsondata);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}