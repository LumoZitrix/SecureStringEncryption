
// SecureString (Memory Safe) Encrypt & Decrypt by LumoZitrix //

using System.Security.Cryptography;

internal static class Generate_Salt
{
    public static byte[] GenerateSalt()
    {
        byte[] salt = Config.Salt();

        using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt);
        }

        return salt;
    }
}