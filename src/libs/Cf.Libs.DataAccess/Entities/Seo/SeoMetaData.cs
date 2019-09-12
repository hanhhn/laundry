using Cf.Libs.Core.Infrastructure.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cf.Libs.DataAccess.Entities.Seo
{
    public class SeoMetadata : IEntityRoot
    {
        public int Id { get; set; }
        [ForeignKey("SeoRecord")]
        public string RecordId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public virtual SeoRecord SeoRecord { get; set; }
    }
}