using Cf.Libs.DataAccess.Entities.Items;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cf.Libs.DataAccess.Mapping.Items
{
    public class PriceConfigure : EntityTypeConfiguration<Price>
    {
        public override void Configure(EntityTypeBuilder<Price> builder)
        {
            base.Configure(builder);

            builder.ToTable(nameof(Price));
            builder.Property(x => x.ApplyDate).HasColumnType("timestamp");
            builder.Property(x => x.ExpireDate).HasColumnType("timestamp");
        }
    }
}