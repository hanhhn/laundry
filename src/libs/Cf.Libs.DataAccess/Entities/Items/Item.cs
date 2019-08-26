using Cf.Libs.Core.Enums;
using Cf.Libs.Core.Infrastructure.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cf.Libs.DataAccess.Entities.Items
{
    public class Item : BaseEntity<int>
    {
        public string Image { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Highlights { get; set; }
        public int Order { get; set; }
        public ItemType ItemType { get; set; }

        ICollection<ItemRate> ItemRates { get; set; }
    }
}