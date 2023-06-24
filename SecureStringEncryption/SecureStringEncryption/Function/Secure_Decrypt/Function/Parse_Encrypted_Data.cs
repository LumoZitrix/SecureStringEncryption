
// SecureString (Memory Safe) Encrypt & Decrypt by LumoZitrix //
internal static class Parse_Encrypted_Data
{
    public static void ParseEncryptedData(byte[] encryptedData, byte[] salt, byte[] iv, out int iterations, out byte[] encrypted, byte[] hmacValue)
    {
        Buffer.BlockCopy(encryptedData, 0, salt, 0, salt.Length);
        Buffer.BlockCopy(encryptedData, salt.Length, iv, 0, iv.Length);
        Buffer.BlockCopy(encryptedData, salt.Length + iv.Length, BitConverter.GetBytes(iterations = BitConverter.ToInt32(encryptedData, salt.Length + iv.Length)), 0, 4);
        encrypted = new byte[encryptedData.Length - salt.Length - iv.Length - 4 - hmacValue.Length];
        Buffer.BlockCopy(encryptedData, salt.Length + iv.Length + 4, encrypted, 0, encrypted.Length);
        Buffer.BlockCopy(encryptedData, encryptedData.Length - hmacValue.Length, hmacValue, 0, hmacValue.Length);
    }
}