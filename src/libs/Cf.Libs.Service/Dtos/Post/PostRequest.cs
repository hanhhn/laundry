namespace Cf.Libs.Service.Dtos.Post
{
    public class PostRequest
    {
        public string Id { get; set; }
        public string UniqueUrl { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public bool IsPublished { get; set; }
        public string[] Tags { get; set; }
    }
}