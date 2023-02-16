using DOMAIN_CORE.Class;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PERSITENCE_CORE.GetTask.Command
{
    public class BillsConfig : IEntityTypeConfiguration<Bills>
    {
        public void Configure(EntityTypeBuilder<Bills> builder)
        {
            builder.HasKey(e => e.BillID);

            builder.ToTable("Bills");

        }
    }
}
