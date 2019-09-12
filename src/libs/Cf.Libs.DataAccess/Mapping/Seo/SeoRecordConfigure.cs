using Cf.Libs.DataAccess.Entities.Seo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cf.Libs.DataAccess.Mapping.Orders
{
    public class SeoRecordConfigure : EntityTypeConfiguration<SeoRecord>
    {
        public override void Configure(EntityTypeBuilder<SeoRecord> builder)
        {
            base.Configure(builder);

            builder.ToTable(nameof(SeoRecord));
        }
    }
}