using Cf.Libs.Core.Infrastructure.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cf.Libs.DataAccess.Entities.Common
{
    public class Ward : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string LatiLongTude { get; set; }

        [ForeignKey("District")]
        public int DistrictId { get; set; }
        public int SortOrder { get; set; }
        public bool IsPublished { get; set; }

        public virtual District District { get; set; }
    }
}
