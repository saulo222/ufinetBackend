using DOMAIN_CORE.Class;
using Microsoft.EntityFrameworkCore;
using PERSITENCE_CORE.Aggregates;

namespace PERSITENCE_CORE.GetTask.Command
{
    public class MainContextCustomers : DbContext, IContextWorkUnit
    {


        public MainContextCustomers(DbContextOptions<MainContextCustomers> options)
            : base(options)
        {
        }

        DbSet<Customers> _Property;


        public DbSet<Customers> Property
        {
            get { return _Property ?? (_Property = base.Set<Customers>()); }
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
            modelBuilder.ApplyConfiguration(new CustomersConfig());
   
        }
    }
}
