using System;
using System.Security;

namespace Projet
{
    public static class Security
    {
        public static string CachePasse()
        {
            ConsoleKeyInfo key;
            string code = "";
            while (true)
            {
                key = Console.ReadKey(true);
                if (Char.IsNumber(key.KeyChar))
                {
                    Console.Write("*");
                    code += key.KeyChar;
                }
                else if (key.Key == ConsoleKey.Enter) return code;
            }
        }
    }
}