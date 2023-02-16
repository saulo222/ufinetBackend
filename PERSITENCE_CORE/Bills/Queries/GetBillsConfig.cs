using DOMAIN_CORE.Class;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PERSITENCE_CORE.GetTask.Command
{
    public class GetBillsConfig : IEntityTypeConfiguration<GetBills>
    {
        public void Configure(EntityTypeBuilder<GetBills> builder)
        {
            builder.HasKey(e => e.BillID);

            builder.ToTable("Bills");

        }
    }
}
