
// SecureString (Memory Safe) Encrypt & Decrypt by LumoZitrix //

using System.Runtime.InteropServices;
using System.Security;

internal static class To_Insecure_String
{
    public static string ToInsecureString(SecureString secureString)
    {
        IntPtr unmanagedString = IntPtr.Zero;
        try
        {
            unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(secureString);
            return Marshal.PtrToStringUni(unmanagedString) ?? string.Empty;
        }
        finally
        {
            Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
        }
    }
}