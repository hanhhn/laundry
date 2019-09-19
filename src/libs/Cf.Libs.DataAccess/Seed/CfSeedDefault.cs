﻿using Cf.Libs.Core.Enums;
using Cf.Libs.DataAccess.Entities.Common;
using Cf.Libs.DataAccess.Entities.Configuration;
using Cf.Libs.DataAccess.Entities.Items;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Cf.Libs.DataAccess.Seed
{
    public class CfSeedDefault
    {
        public static void Seeding(ModelBuilder builder)
        {
            //SeedAddress(builder);

            //SeedMethod(builder);

            //SeedSetting(builder);

            //SeedItem(builder);
        }

        private static void SeedAddress(ModelBuilder builder)
        {
            #region hue
            var hue = new Province
            {
                Id = 1,
                Name = "Huế",
                Prefix = string.Empty,
                SortOrder = 1,
                IsPublished = true,
            };
            builder.Entity<Province>().HasData(hue);

            var tpHue = new District
            {
                Id = 1,
                Name = "Huế",
                Prefix = "Tp",
                ProvinceId = 1,
                SortOrder = 1,
                IsPublished = true,
            };
            builder.Entity<District>().HasData(tpHue);

            var anHoa = new Ward
            {
                Id = 1,
                Name = "An Hòa",
                Prefix = "Phường",
                DistrictId = 1,
                SortOrder = 1,
                IsPublished = true,
            };

            var anCuu = new Ward
            {
                Id = 2,
                Name = "Phú Bình",
                Prefix = "Phường",
                DistrictId = 1,
                SortOrder = 1,
                IsPublished = true,
            };

            var phuHoa = new Ward
            {
                Id = 3,
                Name = "Phú Hòa",
                Prefix = "Phường",
                DistrictId = 1,
                SortOrder = 1,
                IsPublished = true,
            };

            var phuThuan = new Ward
            {
                Id = 4,
                Name = "Phú Thuận",
                Prefix = "Phường",
                DistrictId = 1,
                SortOrder = 1,
                IsPublished = true,
            };

            var tayLoc = new Ward
            {
                Id = 5,
                Name = "Tây Lộc",
                Prefix = "Phường",
                DistrictId = 1,
                SortOrder = 1,
                IsPublished = true,
            };
            builder.Entity<Ward>().HasData(anHoa, anCuu, phuHoa, phuThuan, tayLoc);
            #endregion


            #region danang
            var daNang = new Province
            {
                Id = 2,
                Name = "Đà Nẵng",
                Prefix = string.Empty,
                SortOrder = 1,
                IsPublished = true,
            };
            builder.Entity<Province>().HasData(daNang);

            var lienChieu = new District
            {
                Id = 2,
                Name = "Liên Chiểu",
                Prefix = "Quận",
                ProvinceId = 2,
                SortOrder = 1,
                IsPublished = true,
            };
            builder.Entity<District>().HasData(lienChieu);

            var hoaKhanhBac = new Ward
            {
                Id = 6,
                Name = "Hòa Khánh Bắc",
                Prefix = "Phường",
                DistrictId = 2,
                SortOrder = 1,
                IsPublished = true,
            };

            var hoaKhanhNam = new Ward
            {
                Id = 7,
                Name = "Hòa Khánh Nam",
                Prefix = "Phường",
                DistrictId = 2,
                SortOrder = 1,
                IsPublished = true,
            };
            builder.Entity<Ward>().HasData(hoaKhanhBac, hoaKhanhNam);
            #endregion
        }

        private static void SeedMethod(ModelBuilder builder)
        {
            var method1 = new Method
            {
                Id = 1,
                Name = "Giặt hấp",
                Description = "Giặt hấp",
                SortOrder = 1,
                EnableDiscount = false,
                Type = Core.Enums.MethodType.Clean.ToString()
            };
            method1.Default(true, "system");

            var method2 = new Method
            {
                Id = 2,
                Name = "Giặt sấy",
                Description = "Giặt sấy",
                SortOrder = 1,
                EnableDiscount = false,
                Type = Core.Enums.MethodType.Clean.ToString()
            };
            method2.Default(true, "system");

            var method3 = new Method
            {
                Id = 3,
                Name = "Chỉ giặt",
                Description = "Chỉ giặt",
                SortOrder = 1,
                EnableDiscount = false,
                Type = Core.Enums.MethodType.Clean.ToString()
            };
            method3.Default(true, "system");

            var method4 = new Method
            {
                Id = 4,
                Name = "Chỉ sấy",
                Description = "Chỉ sấy",
                SortOrder = 1,
                EnableDiscount = false,
                Type = Core.Enums.MethodType.Clean.ToString()
            };
            method4.Default(true, "system");

            var method5 = new Method
            {
                Id = 5,
                Name = "Comfort",
                Description = "Comfort",
                SortOrder = 1,
                EnableDiscount = false,
                Type = Core.Enums.MethodType.Other.ToString()
            };
            method5.Default(true, "system");

            var method6 = new Method
            {
                Id = 6,
                Name = "Downy",
                Description = "Downy",
                SortOrder = 1,
                EnableDiscount = false,
                Type = Core.Enums.MethodType.Clean.ToString()
            };
            method6.Default(true, "system");

            var method7 = new Method
            {
                Id = 7,
                Name = "Ủi hơi nước miển phí",
                Description = "Ủi hơi nước miển phí",
                SortOrder = 1,
                EnableDiscount = false,
                Type = Core.Enums.MethodType.Clean.ToString()
            };
            method7.Default(true, "system");

            var method8 = new Method
            {
                Id = 8,
                Name = "7h - 11h",
                Description = "<strong> Phí: </strong> 10.000đ <small>(dưới 5km)</small>",
                SortOrder = 1,
                EnableDiscount = false,
                Type = Core.Enums.MethodType.Delivery.ToString()
            };
            method8.Default(true, "system");

            var method9 = new Method
            {
                Id = 9,
                Name = "13h - 15h",
                Description = "<strong> Phí: </strong> 10.000đ <small>(dưới 5km)</small>",
                SortOrder = 1,
                EnableDiscount = false,
                Type = Core.Enums.MethodType.Delivery.ToString()
            };
            method9.Default(true, "system");

            var method10 = new Method
            {
                Id = 10,
                Name = "3kg / 1 lần giặt",
                Description = "<strong>10.000đ <small>(dưới 5km)</small>",
                SortOrder = 1,
                EnableDiscount = false,
                Type = Core.Enums.MethodType.Delivery.ToString()
            };
            method10.Default(true, "system");

            var method11 = new Method
            {
                Id = 11,
                Name = "5kg / 1 lần giặt",
                Description = "<strong>Miễn phí vận chuyển </strong><small>(dưới 5km)</small>",
                SortOrder = 1,
                EnableDiscount = false,
                Type = Core.Enums.MethodType.Combo.ToString()
            };
            method11.Default(true, "system");

            var method12 = new Method
            {
                Id = 12,
                Name = "10kg / 1 lần giặt",
                Description = "<strong>Miễn phí vận chuyển</strong>",
                SortOrder = 1,
                EnableDiscount = false,
                Type = Core.Enums.MethodType.Combo.ToString()
            };
            method12.Default(true, "system");

            builder.Entity<Method>().HasData(method1, method2, method3, method4, method5, method6, method7, method8, method9, method10, method11, method12);
        }

        private static void SeedSetting(ModelBuilder builder)
        {
            var link = new Setting
            {
                Name = SettingKey.Company.ToString(),
                Value = "{\"Brand\":\"GIẶT SẠCH\",\"Logo\":\"https://i.imgur.com/1CXl1BP.png\",\"Name\":\"Công Ty TNHH Thương Mại Công Nghệ GIAT SACH\",\"Address\":\"201/2, Lê Văn Việt, Quận 9, Hồ Chí Minh\",\"Email\":\"giatsach.vn@outlook.com\",\"Phone\":\"0866.667.670\",\"Website\":\"giatsach.vn\",\"Copyright\":\"<h4>Copyright © 2019 GiatSach</h4>\",\"Facebook\":\"https://www.facebook.com/giatsach.vn\",\"Instagram\":\"https://www.instagram.com/giatsach.vn\",\"Youtube\":\"https://www.youtube.com/giatsach.vn\",\"AppStore\":\"https://www.facebook.com/giatsach.vn\",\"GooglePlay\":\"https://www.facebook.com/giatsach.vn\",\"GoogleMap\":\" \"}"
            };
            link.Default(true, "system");

            builder.Entity<Setting>().HasData(link);
        }


        private static void SeedItem(ModelBuilder builder)
        {
            var item1 = new Item
            {
                Id = 1,
                Name = "Giặt thường 1",
                Description = "<ul class=\"content\"><li class=\"checked\"><span class=\"icon\"><i class=\"fa fa-check\"></i></span><divclass=\"text\">Unlimited private questions and answers</div></li><li class=\"checked\"><span class=\"icon\"><i class=\"fa fa-check\"></i></span><divclass=\"text\">Unlimited private questions and answers</div></li><li class=\"checked\"><span class=\"icon\"><i class=\"fa fa-check\"></i></span><divclass=\"text\">Unlimited private questions and answers</div></li></ul>",
                SortOrder = 1,
                Type = Core.Enums.ItemType.Laundry.ToString(),
                MethodId = 10
            };
            item1.Default(true, "system");


            var item2 = new Item
            {
                Id = 2,
                Name = "Giặt thường 2",
                Description = "<ul class=\"content\"><li class=\"checked\"><span class=\"icon\"><i class=\"fa fa-check\"></i></span><divclass=\"text\">Unlimited private questions and answers</div></li><li class=\"checked\"><span class=\"icon\"><i class=\"fa fa-check\"></i></span><divclass=\"text\">Unlimited private questions and answers</div></li><li class=\"checked\"><span class=\"icon\"><i class=\"fa fa-check\"></i></span><divclass=\"text\">Unlimited private questions and answers</div></li><li class=\"checked\"><span class=\"icon\"><i class=\"fa fa-check\"></i></span><divclass=\"text\">Unlimited private questions and answers</div></li></ul>",
                SortOrder = 1,
                Type = Core.Enums.ItemType.Laundry.ToString(),
                MethodId = 11
            };
            item2.Default(true, "system");


            var item3 = new Item
            {
                Id = 3,
                Name = "Giặt thường 3",
                Description = "<ul class=\"content\"><li class=\"checked\"><span class=\"icon\"><i class=\"fa fa-check\"></i></span><divclass=\"text\">Unlimited private questions and answers</div></li><li class=\"checked\"><span class=\"icon\"><i class=\"fa fa-check\"></i></span><divclass=\"text\">Unlimited private questions and answers</div></li><li class=\"checked\"><span class=\"icon\"><i class=\"fa fa-check\"></i></span><divclass=\"text\">Unlimited private questions and answers</div></li><li class=\"checked\"><span class=\"icon\"><i class=\"fa fa-check\"></i></span><divclass=\"text\">Unlimited private questions and answers</div></li><li class=\"checked\"><span class=\"icon\"><i class=\"fa fa-check\"></i></span><divclass=\"text\">Unlimited private questions and answers</div></li></ul>",
                SortOrder = 1,
                Type = Core.Enums.ItemType.Laundry.ToString(),
                MethodId = 12
            };
            item3.Default(true, "system");

            builder.Entity<Item>().HasData(item1, item2, item3);
        }
    }
}