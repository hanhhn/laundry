using Cf.Libs.DataAccess.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cf.Libs.DataAccess.Mapping.Common
{
    public class TagConfigure : EntityTypeConfiguration<Tag>
    {
        public override void Configure(EntityTypeBuilder<Tag> builder)
        {
            base.Configure(builder);
            builder.ToTable(nameof(Tag));
            builder.HasOne(x => x.Post).WithMany(x => x.Tags);
        }
    }
}