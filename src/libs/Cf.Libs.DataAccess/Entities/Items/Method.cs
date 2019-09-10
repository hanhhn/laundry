using Cf.Libs.Core.Infrastructure.Entity;
using System.Collections.Generic;

namespace Cf.Libs.DataAccess.Entities.Items
{
    public class Method : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool EnableDiscount { get; set; }
        public int SortOrder { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}