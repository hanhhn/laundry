using Cf.Libs.Core.Infrastructure.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cf.Libs.DataAccess.Entities.Common
{
    public class District : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string LatiLongTude { get; set; }

        [ForeignKey("Province")]
        public int ProvinceId { get; set; }
        public int SortOrder { get; set; }
        public bool IsPublished { get; set; }

        public virtual Province Province { get; set; }
    }
}