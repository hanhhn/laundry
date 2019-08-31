﻿using Cf.Libs.Core.Enums;
using Cf.Libs.Core.Infrastructure.Entity;

namespace Cf.Libs.DataAccess.Entities.Items
{
    public class Method : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Discount { get; set; }
        public bool EnableDiscount { get; set; }
        public MethodType Type { get; set; }
    }
}