using Cf.Libs.DataAccess.Entities.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cf.Libs.DataAccess.Mapping.Orders
{
    public class OrderConfigure : EntityTypeConfiguration<Order>
    {
        public override void Configure(EntityTypeBuilder<Order> builder)
        {
            base.Configure(builder);

            builder.ToTable(nameof(Order));
            builder.HasMany(x => x.OrderDetails).WithOne(y => y.Order);
        }
    }
}