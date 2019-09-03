using Cf.Libs.DataAccess.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Cf.Libs.DataAccess.Seed
{
    public class CfSeedDefault
    {
        public static void Seeding(ModelBuilder builder)
        {
            SeedAddress(builder);
        }

        private static void SeedAddress(ModelBuilder builder)
        {
            var anHoa = new Ward
            {
                Name = "An Hòa",
                Prefix = "Phường",
                SortOrder = 1,
                IsPublished = true,
            };
            anHoa.Default(true, 0);

            var anCuu = new Ward
            {
                Name = "Phú Bình",
                Prefix = "Phường",
                SortOrder = 1,
                IsPublished = true,
            };
            anCuu.Default(true, 0);

            var phuHoa = new Ward
            {
                Name = "Phú Hòa",
                Prefix = "Phường",
                SortOrder = 1,
                IsPublished = true,
            };
            phuHoa.Default(true, 0);

            var phuThuan = new Ward
            {
                Name = "Phú Thuận",
                Prefix = "Phường",
                SortOrder = 1,
                IsPublished = true,
            };
            phuThuan.Default(true, 0);

            var tayLoc = new Ward
            {
                Name = "Tây Lộc",
                Prefix = "Phường",
                SortOrder = 1,
                IsPublished = true,
            };
            tayLoc.Default(true, 0);

            var tpHue = new District
            {
                Name = "Tp Huế",
                Prefix = "Thành phố",
                SortOrder = 1,
                IsPublished = true,
                Wards = new List<Ward> { anHoa, anCuu, phuHoa, phuThuan, tayLoc }
            };
            tpHue.Default(true, 0);

            var hue = new Province
            {
                Name = "Huế",
                Prefix = string.Empty,
                SortOrder = 1,
                IsPublished = true,
                Districts = new List<District> { tpHue }
            };
            hue.Default(true, 0);
            builder.Entity<Province>().HasData(hue);

            var hoaKhanhBac = new Ward
            {
                Name = "Hòa Khánh Bắc",
                Prefix = "Phường",
                SortOrder = 1,
                IsPublished = true,
            };

            var hoaKhanhNam = new Ward
            {
                Name = "Hòa Khánh Nam",
                Prefix = "Phường",
                SortOrder = 1,
                IsPublished = true,
            };

            var lienChieu = new District
            {
                Name = "Liên Chiểu",
                Prefix = "Quận",
                SortOrder = 1,
                IsPublished = true,
                Wards = new List<Ward> { hoaKhanhBac, hoaKhanhNam }
            };

            var daNang = new Province
            {
                Name = "Đà Nẵng",
                Prefix = string.Empty,
                SortOrder = 1,
                IsPublished = true,
                Districts = new List<District> { lienChieu }
            };
            daNang.Default(true, 0);
            builder.Entity<Province>().HasData(daNang);
        }
    }
}