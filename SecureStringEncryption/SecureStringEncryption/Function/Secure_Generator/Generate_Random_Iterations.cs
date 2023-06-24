
// SecureString (Memory Safe) Encrypt & Decrypt by LumoZitrix //

internal static class Generate_Random_Iterations
{
    public static int GenerateRandomIterations(int min, int max)
    {
        Random random = new();
        return random.Next(min, max);
    }
}