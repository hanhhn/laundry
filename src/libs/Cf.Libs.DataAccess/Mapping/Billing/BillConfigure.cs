using Cf.Libs.DataAccess.Entities.Billing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cf.Libs.DataAccess.Mapping.Billing
{
    public class BillConfigure : EntityTypeConfiguration<Bill>
    {
        public override void Configure(EntityTypeBuilder<Bill> builder)
        {
            base.Configure(builder);

            builder.ToTable(nameof(Bill));
            builder.HasMany(x => x.BillDetails).WithOne(y => y.Bill);
        }
    }
}