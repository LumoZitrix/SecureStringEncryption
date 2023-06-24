
// SecureString (Memory Safe) Encrypt & Decrypt by LumoZitrix //

using System.Security;

internal static class Encrypt_Data
{
    public static void EncryptData()
    {
        using SecureString plainText = Get_Secure_String.GetSecureString("\nEnter the string to encrypt");
        using SecureString password = Get_Secure_String.GetSecureString("\nEnter the password");
        int iterations = Config.RandomIterations();
        byte[] encrypted = Encrypt_String_To_Bytes.EncryptStringToBytes(plainText, password, iterations);
        string encryptedString = encrypted != null ? Convert.ToBase64String(encrypted) : string.Empty;
        Console.WriteLine($"\nEncrypted string: {encryptedString}");
    }
}