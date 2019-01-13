using System.Text;

namespace siof.Common.Extensions
{
    public static class ByteArrayExtensions
    {
        public static string ToUTF8String(this byte[] array)
        {
            return array.IfNotNull(arr => Encoding.UTF8.GetString(array), null);
        }
        
        public static string ToHex(this byte[] bytes, bool upperCase = false)
        {
            StringBuilder result = new StringBuilder(bytes.Length * 2);

            foreach (var t in bytes)
                result.Append(t.ToString(upperCase ? "X2" : "x2"));

            return result.ToString();
        }
    }
}
