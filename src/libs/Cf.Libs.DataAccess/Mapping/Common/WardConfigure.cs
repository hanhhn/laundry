using Cf.Libs.DataAccess.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cf.Libs.DataAccess.Mapping.Common
{
    public class WardConfigure : EntityTypeConfiguration<Ward>
    {
        public override void Configure(EntityTypeBuilder<Ward> builder)
        {
            base.Configure(builder);

            builder.ToTable(nameof(Ward));
        }
    }
}