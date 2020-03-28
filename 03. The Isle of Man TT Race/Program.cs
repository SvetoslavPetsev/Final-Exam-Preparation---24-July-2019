using System;
using System.Text.RegularExpressions;

namespace _03._The_Isle_of_Man_TT_Race
{
    class Program
    {
        static void Main()
        {
            Regex pattern = new Regex(@"([\#\$\%\*\&])(?<racer>[A-Za-z]+)\1=(?<num>[0-9]+)!!(?<encrypt>.+)");

            while (true)
            {
                string input = Console.ReadLine();

                Match code = pattern.Match(input);
                if (code.Success)
                {
                    string racerName = code.Groups["racer"].Value;
                    int key = int.Parse(code.Groups["num"].Value);
                    string encrypt = code.Groups["encrypt"].Value;

                    if (key == encrypt.Length)
                    {
                        string decript = string.Empty;
                        foreach (char symbol in encrypt)
                        {
                            decript += (char)(symbol + key);
                        }

                        Console.WriteLine($"Coordinates found! {racerName} -> {decript}");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Nothing found!");
                    }
                    
                }
                else
                {
                    Console.WriteLine("Nothing found!");
                }
            }
        }
    }
}
