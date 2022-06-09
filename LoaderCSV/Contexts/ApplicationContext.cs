
using Microsoft.EntityFrameworkCore;
using LoaderCSV.Models;

namespace LoaderCSV.Contexts
{
    internal class ApplicationContext : DbContext
    {
        public DbSet<TableParam> Parametrs => Set<TableParam>(); //{ get; set; } = null!; //{ get; set; }

        //передача в конструктор базового класса объекта DbContextOptions, который инкапсулирует параметры конфигурации
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            //Database.EnsureCreated(); //если бд не существует, то она создается заново
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseLazyLoadingProxies(); //для ленивой загрузки EF
        }
    }
}
