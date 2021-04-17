using System.Text;

namespace TheLibrary.Core.Extensions
{
    public static class StringHelpers
    {
        public static string Atob(this string str)
        {
            string originalString;
            byte[] data = System.Convert.FromBase64String(str);
            originalString = Encoding.ASCII.GetString(data);

            return originalString;
        } 
    }
}
