using Cf.Libs.DataAccess.Entities.Common;
using Cf.Libs.DataAccess.Entities.Items;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Cf.Libs.DataAccess.Seed
{
    public class CfSeedDefault
    {
        public static void Seeding(ModelBuilder builder)
        {
            SeedAddress(builder);

            SeedMethod(builder);
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
            hue.Default(true, "system");
            builder.Entity<Province>().HasData(hue);

            var tpHue = new District
            {
                Id = 1,
                Name = "Tp Huế",
                Prefix = "Thành phố",
                ProvinceId = 1,
                SortOrder = 1,
                IsPublished = true,
            };
            tpHue.Default(true, "system");
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
            anHoa.Default(true, "system");

            var anCuu = new Ward
            {
                Id = 2,
                Name = "Phú Bình",
                Prefix = "Phường",
                DistrictId = 1,
                SortOrder = 1,
                IsPublished = true,
            };
            anCuu.Default(true, "system");

            var phuHoa = new Ward
            {
                Id = 3,
                Name = "Phú Hòa",
                Prefix = "Phường",
                DistrictId = 1,
                SortOrder = 1,
                IsPublished = true,
            };
            phuHoa.Default(true, "system");

            var phuThuan = new Ward
            {
                Id = 4,
                Name = "Phú Thuận",
                Prefix = "Phường",
                DistrictId = 1,
                SortOrder = 1,
                IsPublished = true,
            };
            phuThuan.Default(true, "system");

            var tayLoc = new Ward
            {
                Id = 5,
                Name = "Tây Lộc",
                Prefix = "Phường",
                DistrictId = 1,
                SortOrder = 1,
                IsPublished = true,
            };
            tayLoc.Default(true, "system");
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
            daNang.Default(true, "system");
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
            lienChieu.Default(true, "system");
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
            hoaKhanhBac.Default(true, "system");

            var hoaKhanhNam = new Ward
            {
                Id = 7,
                Name = "Hòa Khánh Nam",
                Prefix = "Phường",
                DistrictId = 2,
                SortOrder = 1,
                IsPublished = true,
            };
            hoaKhanhNam.Default(true, "system");
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
                Type = Core.Enums.MethodType.Dry.ToString()
            };
            method4.Default(true, "system");

            var method5 = new Method
            {
                Id = 5,
                Name = "Comfort",
                Description = "Comfort",
                SortOrder = 1,
                EnableDiscount = false,
                Type = Core.Enums.MethodType.Soft.ToString()
            };
            method5.Default(true, "system");

            var method6 = new Method
            {
                Id = 6,
                Name = "Downy",
                Description = "Downy",
                SortOrder = 1,
                EnableDiscount = false,
                Type = Core.Enums.MethodType.Soft.ToString()
            };
            method6.Default(true, "system");

            var method7 = new Method
            {
                Id = 7,
                Name = "Ủi hơi nước miển phí",
                Description = "Ủi hơi nước miển phí",
                SortOrder = 1,
                EnableDiscount = false,
                Type = Core.Enums.MethodType.Straight.ToString()
            };
            method7.Default(true, "system");

            builder.Entity<Method>().HasData(method1, method2, method3, method4, method5, method6, method7);
        }
    }
}