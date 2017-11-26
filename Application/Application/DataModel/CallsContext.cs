namespace Application
{
    using Application.DataModel;
    using Application.DataModel.InputData;
    using Application.DataModel.ResultData;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class CallsContext : DbContext
    {
        // Контекст настроен для использования строки подключения "CallsContext" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "Application.CallsContext" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "CallsContext" 
        // в файле конфигурации приложения.
        public CallsContext()
            : base("name=CallsContext")
        {
        }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<CallCenter> CallCenters { get; set; }
        public DbSet<AppointmentCall> AppointmentCalls { get; set; }
        // Добавьте DbSet для каждого типа сущности, который требуется включить в модель. Дополнительные сведения 
        // о настройке и использовании модели Code First см. в статье http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}