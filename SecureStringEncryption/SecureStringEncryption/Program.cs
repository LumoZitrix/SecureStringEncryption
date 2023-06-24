
// SecureString (Memory Safe) Encrypt & Decrypt by LumoZitrix //

using System.Diagnostics;

internal class Program
{
    private static void Main()
    {
        try
        {
            Console.WriteLine("SecureString (Memory Safe) Encrypt & Decrypt by LumoZitrix");

            while (true)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Encryption");
                Console.WriteLine("2. Decryption");
                Console.WriteLine("0. Exit");
                Console.Write("Choice: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    if (choice == 0)
                    {
                        Process.GetCurrentProcess().Kill();
                        break;
                    }
                    else if (choice == 1)
                    {
                        Encrypt_Data.EncryptData();
                        PressAnyKeyToContinue();
                    }
                    else if (choice == 2)
                    {
                        Decrypt_Data.DecryptData();
                        PressAnyKeyToContinue();
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice.");
                        PressAnyKeyToContinue();
                    }

                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Please enter a valid number.");
                    PressAnyKeyToContinue();
                    Console.Clear();
                    continue;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
            PressAnyKeyToContinue();
        }

        _ = Console.ReadLine();
    }
    private static void PressAnyKeyToContinue()
    {
        Console.WriteLine("\nPress any key to continue...");
        _ = Console.ReadKey();
    }
}
