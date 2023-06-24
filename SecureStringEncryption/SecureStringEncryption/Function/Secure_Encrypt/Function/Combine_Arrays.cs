
// SecureString (Memory Safe) Encrypt & Decrypt by LumoZitrix //

internal static class Combine_Arrays
{
    public static byte[] CombineArrays(byte[] array1, byte[] array2)
    {
        byte[] combined = new byte[array1.Length + array2.Length];

        Buffer.BlockCopy(array1, 0, combined, 0, array1.Length);
        Buffer.BlockCopy(array2, 0, combined, array1.Length, array2.Length);

        return combined;
    }
}