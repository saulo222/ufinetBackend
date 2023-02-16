using DOMAIN_CORE.Class;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PERSITENCE_CORE.GetTask.Command
{
    public class CustomersConfig : IEntityTypeConfiguration<Customers>
    {
        public void Configure(EntityTypeBuilder<Customers> builder)
        {
            builder.HasKey(e => e.CustomerID);

            builder.ToTable("Customers");

        }
    }
}
