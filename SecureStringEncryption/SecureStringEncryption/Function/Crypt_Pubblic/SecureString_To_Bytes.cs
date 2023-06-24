
// SecureString (Memory Safe) Encrypt & Decrypt by LumoZitrix //

using System.Security;

internal static class SecureString_To_Bytes
{
    public static byte[] SecureStringToBytes(SecureString secureString)
    {
        return Secure_String_To_Bytes.SecureStringToBytes(secureString);
    }
}