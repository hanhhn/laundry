using Cf.Libs.Core.Infrastructure.Entity;

namespace Cf.Libs.DataAccess.Entities.Configuration
{
    public class Setting : BaseEntity<string>
    {
        public string Name { get; set; }

        public string Value { get; set; }
    }
}
