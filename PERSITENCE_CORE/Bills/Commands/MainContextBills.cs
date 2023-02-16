using DOMAIN_CORE.Class;
using Microsoft.EntityFrameworkCore;
using PERSITENCE_CORE.Aggregates;

namespace PERSITENCE_CORE.GetTask.Command
{
    public class MainContextBills : DbContext, IContextWorkUnit
    {


        public MainContextBills(DbContextOptions<MainContextBills> options)
            : base(options)
        {
        }

        DbSet<Bills> _Property;


        public DbSet<Bills> Property
        {
            get { return _Property ?? (_Property = base.Set<Bills>()); }
        }


        public void SetDetached<Entity>(Entity item) where Entity : class
        {
            Entry(item).State = EntityState.Detached;
        }


        public int Save()
        {
            return base.SaveChangesAsync().GetAwaiter().GetResult();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new BillsConfig());
   
        }
    }
}
