using System;
using System.Security.Cryptography;

namespace Cf.Laundry.Common
{
    public static class Utility
    {
        public static string GetDigits(int digit = 4)
        {
            var bytes = new byte[4];
            var rng = RandomNumberGenerator.Create();
            rng.GetBytes(bytes);
            uint random = BitConverter.ToUInt32(bytes, 0) % uint.Parse("1".PadRight(digit, '0'));
            return string.Format("{0:D" + digit + "}", random);
        }
    }
}
