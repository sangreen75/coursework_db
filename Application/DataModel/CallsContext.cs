namespace Application
{
    using Application.DataModel;
    using Application.DataModel.InputData;
    using Application.DataModel.ResultData;
    using System.Data.Entity;

    public class CallsContext : DbContext
    {

        public CallsContext()
            : base("name=CallsContext")
        {
        }

        public virtual DbSet<Manager> Managers { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<CallCenter> CallCenters { get; set; }
        public virtual DbSet<AppointmentCall> AppointmentCalls { get; set; }
        public virtual DbSet<CallCenterDistribution> CallCenterDistribution { get; set; }
    }
}