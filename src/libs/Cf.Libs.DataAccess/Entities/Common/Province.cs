using Cf.Libs.Core.Infrastructure.Entity;
using System.Collections.ObjectModel;

namespace Cf.Libs.DataAccess.Entities.Common
{
    public class Province : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string TelephoneCode { get; set; }
        public string ZipCode { get; set; }
        public string CountryCode { get; set; }
        public int SortOrder { get; set; }
        public bool IsPublished { get; set; }

        public virtual Collection<District> Districts { get; set; }
    }
}
