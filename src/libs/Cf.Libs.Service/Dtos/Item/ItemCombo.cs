using Cf.Libs.Service.Dtos.Setting;
using System.Collections.Generic;

namespace Cf.Libs.Service.Dtos.Item
{
    public class ItemCombo : JumbotronDto
    {
        public IEnumerable<ItemDto> Items { get; set; }
    }
}
