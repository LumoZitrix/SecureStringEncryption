
// SecureString (Memory Safe) Encrypt & Decrypt by LumoZitrix //

using System.Runtime.InteropServices;
using System.Security;

internal static class Secure_String_To_Bytes
{
    public static byte[] SecureStringToBytes(SecureString secureString)
    {
        IntPtr unmanagedString = IntPtr.Zero;
        try
        {
            unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(secureString);
            int length = secureString.Length * 2;
            byte[] bytes = new byte[length];
            Marshal.Copy(unmanagedString, bytes, 0, length);
            return bytes;
        }
        finally
        {
            Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
        }
    }
}