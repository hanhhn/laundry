namespace Cf.Libs.Service.Dtos.Item
{
    public class ItemRequest
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Highlight { get; set; }
        public int SortOrder { get; set; }
        public string Type { get; set; }
        public int ComboId { get; set; }
    }
}