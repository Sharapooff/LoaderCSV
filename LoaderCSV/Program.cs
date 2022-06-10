using LoaderCSV.Classes;

Console.WriteLine("Loader CSV App начала работу!");
//----------------------------- SqlServer ---------------------------
Loader loader = new Loader("appsettings.json", "SqlServer");
int? CountInserted = await loader.LoadCSVAsync("B:/D1rew.csv", 2, ";", "\\n");
if (CountInserted.HasValue)
    if (CountInserted.Value == -1)
        Console.WriteLine($"Ошибка добавлеия записей: {CountInserted}");
    else
        Console.WriteLine($"Добавлено запией: {CountInserted}");
Console.WriteLine("Loader CSV App завершила работу.");
Console.Read();