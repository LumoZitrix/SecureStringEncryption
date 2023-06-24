
// SecureString (Memory Safe) Encrypt & Decrypt by LumoZitrix //

using System.Security;
using System.Security.Cryptography;

internal static class Encrypt_String_To_Bytes
{
    public static byte[] EncryptStringToBytes(SecureString plainText, SecureString password, int iterations)
    {
        try
        {
            byte[] salt = Config.GenerateSalt();
            byte[] passwordBytes = SecureString_To_Bytes.SecureStringToBytes(password);
            byte[] derivedKey = Config.DeriveKey(passwordBytes, salt, iterations);
            using Aes aes = Aes.Create();
            Config.ConfigureAesParameters(aes);
            byte[] iv = Config.GenerateIV(aes);
            byte[] encrypted = Encrypt_With_Aes.EncryptWithAes(plainText, derivedKey, aes, iv);
            byte[] ciphertext = Build_Cipher_Text.BuildCipherText(salt, iv, iterations, encrypted);
            byte[] hmacKey = Hmac_Function.ExtractHmacKey(derivedKey);
            byte[] hmacValue = Hmac_Function.ComputeHmac(ciphertext, hmacKey);
            byte[] result = Combine_Arrays.CombineArrays(ciphertext, hmacValue);
            Zero_Memory.ZeroMemory(passwordBytes, derivedKey, hmacKey, ciphertext, hmacValue, encrypted);

            return result;
        }
        catch (Exception ex)
        {
            throw new Exception("Encryption failed: " + ex.Message);
        }
    }

}