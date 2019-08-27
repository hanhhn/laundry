using Cf.Libs.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cf.Libs.Service.Dtos.Item
{
    public class ItemRequest
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Highlights { get; set; }
        public int Order { get; set; }
        public ItemType Type { get; set; }
    }
}