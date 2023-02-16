using DOMAIN_CORE.Class;
using Microsoft.EntityFrameworkCore;
using PERSITENCE_CORE.Aggregates;

namespace PERSITENCE_CORE.GetTask.Command
{
    public class MainContextGetUsers : DbContext, IContextWorkUnit
    {


        public MainContextGetUsers(DbContextOptions<MainContextGetUsers> options)
            : base(options)
        {
        }

        DbSet<User> _Property;


        public DbSet<User> Property
        {
            get { return _Property ?? (_Property = base.Set<User>()); }
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
            modelBuilder.ApplyConfiguration(new UsersConfig());
   
        }
    }
}
