using Cf.Libs.Core.Infrastructure.Entity;
using System.Collections.Generic;

namespace Cf.Libs.DataAccess.Entities.Seo
{
    public class SeoRecord : IEntityRoot
    {
        public string Id { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string Keywords { get; set; }
        public string Description { get; set; }

        public virtual ICollection<SeoMetadata> SeoMetadatas { get; set; }
    }
}