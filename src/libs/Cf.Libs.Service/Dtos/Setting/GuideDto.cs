using Cf.Libs.Core.BaseObject;

namespace Cf.Libs.Service.Dtos.Setting
{
    public class GuideDto
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string[] Steppers { get; set; }
    }
}