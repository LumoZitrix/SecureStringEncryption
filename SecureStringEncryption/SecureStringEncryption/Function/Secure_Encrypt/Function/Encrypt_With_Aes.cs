
// SecureString (Memory Safe) Encrypt & Decrypt by LumoZitrix //

using System.Security;
using System.Security.Cryptography;

internal static class Encrypt_With_Aes
{
    public static byte[] EncryptWithAes(SecureString plainText, byte[] derivedKey, Aes aes, byte[] iv)
    {
        using ICryptoTransform encryptor = aes.CreateEncryptor(derivedKey, iv);
        byte[] plainTextBytes = SecureString_To_Bytes.SecureStringToBytes(plainText);
        byte[] encrypted = encryptor.TransformFinalBlock(plainTextBytes, 0, plainTextBytes.Length);
        Zero_Memory.ZeroMemory(plainTextBytes);

        return encrypted;
    }
}