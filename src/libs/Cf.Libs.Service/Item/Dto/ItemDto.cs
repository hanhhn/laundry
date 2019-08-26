﻿using Cf.Libs.Core.Enums;
using Cf.Libs.Service.ItemRate.Dto;
using System.Collections.Generic;

namespace Cf.Libs.Service.Item.Dto
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