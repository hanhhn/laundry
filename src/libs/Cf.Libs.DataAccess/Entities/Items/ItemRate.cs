﻿using Cf.Libs.Core.Infrastructure.Entity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cf.Libs.DataAccess.Entities.Items
{
    public class ItemRate : BaseEntity<int>
    {
        [ForeignKey("Item")]
        public int ItemId { get; set; }
        public decimal Rate { get; set; }
        public byte Tax { get; set; }
        public decimal DiscountRate { get; set; }
        public decimal Discount { get; set; }
        public byte Priority { get; set; }
        public bool IsActive { get; set; }
        public DateTime ApplyDate { get; set; }
        public DateTime ExpireDate { get; set; }

        public virtual Item Item { get; set; }
    }
}