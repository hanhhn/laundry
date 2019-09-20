using Cf.Libs.DataAccess.Entities.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cf.Libs.DataAccess.Mapping.Orders
{
    public class TrackingConfigure : EntityTypeConfiguration<Tracking>
    {
        public override void Configure(EntityTypeBuilder<Tracking> builder)
        {
            base.Configure(builder);

            builder.ToTable(nameof(Tracking));
        }
    }
}