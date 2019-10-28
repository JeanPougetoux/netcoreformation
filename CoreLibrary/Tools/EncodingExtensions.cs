using System;
using System.Collections.Generic;
using System.Text;

namespace CoreLibrary.Tools
{
    public static class EncodingExtensions
    {
        public static byte[] ToBytes(this string input)
        {
            return Encoding.UTF8.GetBytes(input);
        }
    }
}
