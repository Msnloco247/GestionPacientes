
using System.Security.Cryptography;
using System.Text;

namespace GestionPacientes2.Core.Application.Helpers
{
    public class PasswordEncryptation
    {
        public static string ComputeSha256Hash(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                //covierte password a bytes
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();

                // Pasa los bytes a builder
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i]);
                }
                return builder.ToString();
            }
        }
    }
}
