using System.Security.Cryptography;
using System.Text;

namespace CommonInfra
{
    public class EncryptionHelper
    {
        public static byte[] GetHashForString(string stringData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                //Can be replaced by other hashing method
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(stringData));
                return bytes;
            }
        }
    }
}
