using Cf.Libs.DataAccess.Entities.News;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cf.Libs.DataAccess.Mapping.News
{
    public class PostConfigure : EntityTypeConfiguration<Post>
    {
        public override void Configure(EntityTypeBuilder<Post> builder)
        {
            base.Configure(builder);

            builder.ToTable(nameof(Post));
        }
    }
}