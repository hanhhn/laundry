using Cf.Libs.Core.Enums;
using Cf.Libs.Core.Infrastructure.Entity;
using System.Collections.Generic;

namespace Cf.Libs.DataAccess.Entities.Items
{
    public class Item : BaseEntity<int>
    {
        public string Image { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Highlights { get; set; }
        public int Order { get; set; }
        public ItemType Type { get; set; }

        public virtual ICollection<ItemRate> ItemRates { get; set; }
    }
}