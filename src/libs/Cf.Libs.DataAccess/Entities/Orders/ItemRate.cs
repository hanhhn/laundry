using Cf.Libs.Core.Infrastructure.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cf.Libs.DataAccess.Entities.Orders
{
    public class ItemRate : BaseEntity<int>
    {
        public int ItemId { get; set; }

        public decimal Rate { get; set; }

        public decimal DiscountRate { get; set; }

        public decimal Discount { get; set; }

        public byte Priority { get; set; }

        public bool IsActive { get; set; }

        DateTime ApplyDate { get; set; }

        DateTime ExpireDate { get; set; }
    }
}
