using System.Security.Cryptography;
using System.Text;

namespace StoresAPI.Util
{
    public static class MD5Helper
    {
        public static string CreateHashMD5(string input)
        {
            var salt = ConfigurationHelper.Get()["SaltKey"];
            StringBuilder sBuilder = new();
            MD5 md5Hash = MD5.Create();

            // Convert string to bytes
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input + ':' + salt));

            // Format everty byte as an hex
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }
    }
}
