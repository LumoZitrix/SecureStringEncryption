
// SecureString (Memory Safe) Encrypt & Decrypt by LumoZitrix //

using System.Security;

internal static class Get_Secure_String
{
    public static SecureString GetSecureString(string prompt)
    {
        Console.Write(prompt + ": ");
        SecureString secureString = new();
        ConsoleKeyInfo key;
        while ((key = Console.ReadKey(true)).Key != ConsoleKey.Enter)
        {
            if (key.Key == ConsoleKey.Backspace)
            {
                if (secureString.Length > 0)
                {
                    secureString.RemoveAt(secureString.Length - 1);
                    Console.Write("\b \b");
                }
            }
            else if (key.KeyChar != '\u0000' && !char.IsControl(key.KeyChar))
            {
                secureString.AppendChar(key.KeyChar);
                Console.Write("*");
            }
        }
        Console.WriteLine();
        secureString.MakeReadOnly();
        return secureString;
    }
}