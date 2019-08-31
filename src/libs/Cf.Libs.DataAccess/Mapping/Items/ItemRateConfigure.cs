using Cf.Libs.DataAccess.Entities.Items;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cf.Libs.DataAccess.Mapping.Items
{
    public class ItemRateConfigure : EntityTypeConfiguration<ItemRate>
    {
        public override void Configure(EntityTypeBuilder<ItemRate> builder)
        {
            base.Configure(builder);

            builder.ToTable(nameof(ItemRate));
        }
    }
}