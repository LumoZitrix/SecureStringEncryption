
// SecureString (Memory Safe) Encrypt & Decrypt by LumoZitrix //
internal static class Build_Cipher_Text
{
    public static byte[] BuildCipherText(byte[] salt, byte[] iv, int iterations, byte[] encrypted)
    {
        byte[] ciphertext = new byte[salt.Length + iv.Length + 4 + encrypted.Length];

        Buffer.BlockCopy(salt, 0, ciphertext, 0, salt.Length);
        Buffer.BlockCopy(iv, 0, ciphertext, salt.Length, iv.Length);
        Buffer.BlockCopy(BitConverter.GetBytes(iterations), 0, ciphertext, salt.Length + iv.Length, 4);
        Buffer.BlockCopy(encrypted, 0, ciphertext, salt.Length + iv.Length + 4, encrypted.Length);

        return ciphertext;
    }
}