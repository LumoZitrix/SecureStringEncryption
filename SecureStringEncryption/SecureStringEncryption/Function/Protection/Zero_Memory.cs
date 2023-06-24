
// SecureString (Memory Safe) Encrypt & Decrypt by LumoZitrix //

using System.Security;

internal static class Zero_Memory
{
    public static void ZeroMemory(params Array[] arrays)
    {
        foreach (Array array in arrays)
        {
            if (array != null)
            {
                Array.Clear(array, 0, array.Length);

                Type? elementType = array.GetType().IsArray ? array.GetType().GetElementType() : null;

                if (elementType != null && (!elementType.IsPrimitive || (elementType.IsValueType && !elementType.IsPrimitive)))
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        if (array.GetValue(i) is Array nestedArray)
                        {
                            try
                            {
                                ZeroMemory(nestedArray);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Exception occurred while clearing nested array: {ex.Message}");
                            }
                        }
                        else
                        {
                            try
                            {
                                if (array.GetValue(i) is SecureString secureString)
                                {
                                    secureString.Dispose();
                                }
                                array.SetValue(null, i);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Exception occurred while clearing array element: {ex.Message}");
                            }
                        }
                    }
                }
            }
        }
    }

}