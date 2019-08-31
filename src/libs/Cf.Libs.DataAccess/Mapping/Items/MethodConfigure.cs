using Cf.Libs.DataAccess.Entities.Items;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cf.Libs.DataAccess.Mapping.Items
{
    public class MethodConfigure : EntityTypeConfiguration<Method>
    {
        public override void Configure(EntityTypeBuilder<Method> builder)
        {
            base.Configure(builder);

            builder.ToTable(nameof(Method));
        }
    }
}