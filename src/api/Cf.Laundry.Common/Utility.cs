using System;
using System.Security.Cryptography;

namespace Cf.Laundry.Common
{
    public static class Utility
    {
        public static string GetDigits()
        {
            var bytes = new byte[4];
            var rng = RandomNumberGenerator.Create();
            rng.GetBytes(bytes);
            uint random = BitConverter.ToUInt32(bytes, 0) % 10000;
            return string.Format("{0:D4}", random);
        }
    }
}
