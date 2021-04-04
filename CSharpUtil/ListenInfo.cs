using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpUtil
{
    static class ListenInfo
    {
        static string ListenPassword(string prompt)
        {
            Console.Write(prompt);

            var input = new StringBuilder();
            for (; ; )
            {
                var keyinfo = Console.ReadKey(true);
                switch (keyinfo.Key)
                {
                    case ConsoleKey.Escape:
                        // Cancell
                        Console.WriteLine();
                        return null;
                    case ConsoleKey.Enter:
                        // Confirm
                        Console.WriteLine();
                        return input.ToString();
                    case ConsoleKey.Backspace:
                        // Back
                        if (0 < input.Length)
                            input.Length -= 1;
                        else
                            Console.Beep();
                        break;
                    default:
                        if (char.IsLetter(keyinfo.KeyChar))
                        {
                            // Not shift
                            if ((keyinfo.Modifiers & ConsoleModifiers.Shift) == 0)
                            {
                                input.Append(keyinfo.KeyChar);
                            }
                            // shift
                            else
                            {
                                // caps lock
                                if (Console.CapsLock)
                                    input.Append(char.ToLower(keyinfo.KeyChar));
                                else
                                    input.Append(char.ToUpper(keyinfo.KeyChar));
                            }
                        }
                        else if (!char.IsControl(keyinfo.KeyChar))
                        {
                            input.Append(keyinfo.KeyChar);
                        }
                        else
                        {
                            Console.Beep();
                        }
                        break;
                }
            }
        }
    }
}
