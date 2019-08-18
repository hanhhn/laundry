using Cf.Libs.Core.Infrastructure.Entity;
using System;

namespace Cf.Libs.DataAccess.Entities.Service
{
    public class Coupon : BaseEntity<int>
    {
        string Code { get; set; }

        int Apply { get; set; }

        int Count { get; set; }

        DateTime ApplyDate { get; set; }

        DateTime ExpireDate { get; set; }
    }
}