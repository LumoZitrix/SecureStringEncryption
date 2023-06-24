
// SecureString (Memory Safe) Encrypt & Decrypt by LumoZitrix //

using System.Security;

internal static class Decrypt_Data
{
    public static void DecryptData()
    {
        using SecureString encryptedString = Get_Secure_String.GetSecureString("\nEnter the encrypted string");
        using SecureString password = Get_Secure_String.GetSecureString("\nEnter the password");
        string insecureString = To_Insecure_String.ToInsecureString(encryptedString);
        if (insecureString != null)
        {
            byte[] encryptedData = Convert.FromBase64String(insecureString);
            string decrypted = Decrypt_String_From_Bytes.DecryptStringFromBytes(encryptedData, password);
            Console.WriteLine($"\nDecrypted string: {decrypted}");
        }
        else
        {
            Console.WriteLine("\nInvalid encrypted string.");
        }
    }
}