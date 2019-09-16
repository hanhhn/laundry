using System.Collections.Generic;

namespace Cf.Libs.Service.Dtos.Page
{
    public class PageDto
    {
        public string Id { get; set; }
        public string UniqueUrl { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public IEnumerable<string> Tags { get; set; }
    }
}
