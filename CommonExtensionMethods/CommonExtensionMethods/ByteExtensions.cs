using System.Text;

namespace CommonExtensionMethods
{
    public static class ByteExtensions
    {
        public static string ToUtf8String(this byte[] bytes)
        {
            return Encoding.UTF8.GetString(bytes);
        }
    }
}