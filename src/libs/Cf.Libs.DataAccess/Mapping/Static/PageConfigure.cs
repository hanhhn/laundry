using Cf.Libs.DataAccess.Entities.Static;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cf.Libs.DataAccess.Mapping.Static
{
    public class PageConfigure : EntityTypeConfiguration<Page>
    {
        public override void Configure(EntityTypeBuilder<Page> builder)
        {
            base.Configure(builder);

            builder.ToTable(nameof(Page));
        }
    }
}