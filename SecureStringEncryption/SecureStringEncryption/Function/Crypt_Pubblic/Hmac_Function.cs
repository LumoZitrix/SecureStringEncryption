
// SecureString (Memory Safe) Encrypt & Decrypt by LumoZitrix //

using System.Security.Cryptography;

internal static class Hmac_Function
{
    public static byte[] ComputeHmac(byte[] ciphertext, byte[] hmacKey)
    {
        using HMACSHA512 hmac = new(hmacKey);
        return hmac.ComputeHash(ciphertext);
    }

    public static void ValidateHmac(byte[] encryptedData, byte[] hmacValue, byte[] hmacKey)
    {
        using HMACSHA512 hmac = new(hmacKey);
        byte[] hmacComputed = hmac.ComputeHash(encryptedData, 0, encryptedData.Length - hmacValue.Length);
        if (!Costant_Time.ConstantTimeComparison(hmacComputed, hmacValue))
        {
            throw new Exception("HMAC validation failed.");
        }
    }

    public static byte[] ExtractHmacKey(byte[] derivedKey)
    {
        byte[] hmacKey = Config.HmacKeys();
        Buffer.BlockCopy(derivedKey, 0, hmacKey, 0, 32);
        return hmacKey;
    }
}