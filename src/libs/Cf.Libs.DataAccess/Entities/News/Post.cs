using Cf.Libs.Core.Infrastructure.Entity;
using Cf.Libs.DataAccess.Entities.Common;
using System;
using System.Collections.Generic;

namespace Cf.Libs.DataAccess.Entities.News
{
    public class Post : BaseEntity<string>
    {
        public string UniqueUrl { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public bool IsPublished { get; set; }
        public DateTime PublishedDate { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
    }
}
