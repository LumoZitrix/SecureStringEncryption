
// SecureString (Memory Safe) Encrypt & Decrypt by LumoZitrix //

internal static class Costant_Time
{
    public static bool ConstantTimeComparison(byte[] a, byte[] b)
    {
        if (a.Length != b.Length)
        {
            return false;
        }

        uint diff = (uint)a.Length ^ (uint)b.Length;
        for (int i = 0; i < a.Length && i < b.Length; i++)
        {
            diff |= (uint)(a[i] ^ b[i]);
        }

        return diff == 0;
    }
}