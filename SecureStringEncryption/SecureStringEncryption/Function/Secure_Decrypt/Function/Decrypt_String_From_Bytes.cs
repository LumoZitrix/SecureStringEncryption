
// SecureString (Memory Safe) Encrypt & Decrypt by LumoZitrix //

using System.Security;
using System.Security.Cryptography;
using System.Text;

internal static class Decrypt_String_From_Bytes
{
    public static string DecryptStringFromBytes(byte[] encryptedData, SecureString password)
    {
        try
        {
            Config.DecryptSetting(out byte[] hmacValue, out byte[] salt, out byte[] iv);
            Parse_Encrypted_Data.ParseEncryptedData(encryptedData, salt, iv, out int iterations, out byte[] encrypted, hmacValue);

            byte[] passwordBytes = SecureString_To_Bytes.SecureStringToBytes(password);
            byte[] derivedKey = Config.DeriveKey(passwordBytes, salt, iterations);
            byte[] hmacKey = Hmac_Function.ExtractHmacKey(derivedKey);

            Hmac_Function.ValidateHmac(encryptedData, hmacValue, hmacKey);

            using Aes aes = Aes.Create();
            Config.ConfigureAesParameters(aes);

            StringBuilder resultBuilder = new();

            using (ICryptoTransform decryptor = aes.CreateDecryptor(derivedKey, iv))
            {
                byte[] decrypted = decryptor.TransformFinalBlock(encrypted, 0, encrypted.Length);
                _ = resultBuilder.Append(Encoding.UTF8.GetString(decrypted));
                Zero_Memory.ZeroMemory(decrypted, encryptedData);
            }

            Zero_Memory.ZeroMemory(passwordBytes, derivedKey, hmacKey, hmacValue);

            return resultBuilder.ToString();
        }
        catch (Exception ex)
        {
            throw new Exception("Decryption failed: " + ex.Message);
        }
    }
}
