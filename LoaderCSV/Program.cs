using Microsoft.Data.SqlClient;
using System.Data;
using LoaderCSV.Models;
using LoaderCSV.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

Console.WriteLine("Loader CSV App Started!");
//----------------------------- SqlServer ---------------------------
var builder_SqlServer = new ConfigurationBuilder();
builder_SqlServer.SetBasePath(Directory.GetCurrentDirectory());// установка пути к текущему каталогу
builder_SqlServer.AddJsonFile("appsettings.json");// получаем конфигурацию из файла appsettings.json
var config = builder_SqlServer.Build();// создаем конфигурацию
string connectionString_SqlServer = config.GetConnectionString("SqlServer");// получаем строку подключения
var optionsBuilder_SqlServer = new DbContextOptionsBuilder<ApplicationContext>();// опции контекста
var options_SqlServer = optionsBuilder_SqlServer.UseSqlServer(connectionString_SqlServer).Options;

using (ApplicationContext db = new ApplicationContext(options_SqlServer))
{
    Console.WriteLine("Подключение открыто");
    //Вывод информации о подключении
    Console.WriteLine($"\tСтрока подключения: {connectionString_SqlServer}");
    await db.Database.EnsureDeletedAsync(); //удаляем бд если она существует
    await db.Database.EnsureCreatedAsync(); //если бд не существует, то она создается заново
    //заносим данные из файла csv
    int numberOfRowInserted = db.Database.ExecuteSqlRaw("BULK INSERT dbo.Parametrs FROM 'B:/D1rew.csv' WITH (FIRSTROW = 2, CHECK_CONSTRAINTS, KEEPNULLS, FIELDTERMINATOR = ';', ROWTERMINATOR = '\\n')");
    Console.WriteLine($"Добавлено объектов: {numberOfRowInserted}");
}
Console.WriteLine("Программа завершила работу.");
Console.Read();
#region Дополнительный вариант - подключаемся к БД и добавляем в нее записи через ADO.net
//string newConnectionString = "Server=(localdb)\\mssqllocaldb;Database=importCSVre;Trusted_Connection=True;";
//using (SqlConnection connection = new SqlConnection(newConnectionString))
//{
//    await connection.OpenAsync();
//    SqlCommand command = new SqlCommand();
//    // добавляем записи
//    string sqlExpression = "BULK INSERT dbo.Parametrs FROM 'B:/D1rew.csv' WITH (FIRSTROW = 2, CHECK_CONSTRAINTS, KEEPNULLS, FIELDTERMINATOR = ';', ROWTERMINATOR = '\\n')";
//    command = new SqlCommand(sqlExpression, connection);
//    try
//    {
//        int number = await command.ExecuteNonQueryAsync();
//        Console.WriteLine($"Добавлено объектов: {number}");
//    }
//    catch (Exception ex)
//    {
//        Console.WriteLine(ex.Message);
//    }
//}
//Console.WriteLine("Подключение закрыто...");
#endregion
