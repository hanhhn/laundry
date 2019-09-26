using Cf.Libs.DataAccess.Entities.Billing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cf.Libs.DataAccess.Mapping.Billing
{
    public class BillDetailConfigure : EntityTypeConfiguration<BillDetail>
    {
        public override void Configure(EntityTypeBuilder<BillDetail> builder)
        {
            base.Configure(builder);

            builder.ToTable(nameof(BillDetail));
        }
    }
}