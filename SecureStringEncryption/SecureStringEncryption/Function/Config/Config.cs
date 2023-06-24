using System.Security.Cryptography;

// SecureString (Memory Safe) Encrypt & Decrypt by LumoZitrix //

internal static class Config
{
    public static void ConfigureAesParameters(Aes aes)
    {
        aes.KeySize = 256;
        aes.BlockSize = 128;
        aes.Mode = CipherMode.CBC;
        aes.Padding = PaddingMode.PKCS7;
    }
    public static int RandomIterations()
    {
        int min = 500000;
        int max = 1500000;
        return Generate_Random_Iterations.GenerateRandomIterations(min, max);
    }
    public static byte[] HmacKeys()
    {
        return new byte[32];
    }
    public static void DecryptSetting(out byte[] hmacValue, out byte[] salt, out byte[] iv)
    {
        hmacValue = new byte[64];
        salt = new byte[16];
        iv = new byte[16];
    }
    public static byte[] DeriveKey(byte[] passwordBytes, byte[] salt, int iterations)
    {
        using Rfc2898DeriveBytes pbkdf2 = new(passwordBytes, salt, iterations, HashAlgorithmName.SHA512);
        return pbkdf2.GetBytes(32);
    }
    public static byte[] GenerateIV(Aes aes)
    {
        aes.GenerateIV();
        return aes.IV;
    }
    public static byte[] GenerateSalt()
    {
        return Generate_Salt.GenerateSalt();
    }
    public static byte[] Salt()
    {
        return new byte[16];
    }
}