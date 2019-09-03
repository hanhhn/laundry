namespace Cf.Libs.Service.Dtos.Adresss
{
    public class AddressUnitDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Prefix { get; set; }
        public string FullName => string.Format("{0} {1}", Prefix, Name);
    }
}