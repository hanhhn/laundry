using Cf.Libs.Core.Enums;
using Cf.Libs.Core.Infrastructure.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cf.Libs.DataAccess.Entities.Service
{
    public class Method : BaseEntity<int>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public MethodType MethodType { get; set; }

        public decimal Discount { get; set; }

        public bool EnableDiscount { get; set; }
    }
}
