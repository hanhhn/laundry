using Cf.Libs.Core.Infrastructure.Entity;
using Cf.Libs.DataAccess.Entities.News;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cf.Libs.DataAccess.Entities.Common
{
    public class Tag : IEntityRoot
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("News")]
        public string NewsId { get; set; }

        public virtual  Post Post { get; set; }
    }
}
