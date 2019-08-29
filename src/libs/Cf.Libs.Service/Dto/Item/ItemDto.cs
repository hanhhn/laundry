using Cf.Libs.Core.Enums;
using Cf.Libs.Service.Dto.ItemRate;
using System.Collections.Generic;

namespace Cf.Libs.Service.Dto.Item
{
    public class ItemDto
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Highlights { get; set; }
        public int Order { get; set; }
        public ItemType ItemType { get; set; }

        public ICollection<ItemRateDto> ItemRates { get; set; }
    }
}