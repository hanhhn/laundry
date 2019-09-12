using Cf.Libs.DataAccess.Entities.Seo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cf.Libs.DataAccess.Mapping.Seo
{
    public class SeoMetadataConfigure : EntityTypeConfiguration<SeoMetadata>
    {
        public override void Configure(EntityTypeBuilder<SeoMetadata> builder)
        {
            base.Configure(builder);

            builder.ToTable(nameof(SeoMetadata));
            builder.HasOne(x => x.SeoRecord).WithMany(y => y.SeoMetadatas);
        }
    }
}