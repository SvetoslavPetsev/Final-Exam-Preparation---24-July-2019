using System;
using System.Text.RegularExpressions;

namespace _02._Song_Encryption
{
    class Program
    {
        static void Main()
        {
            Regex pattern = new Regex(@"^(?<artist>[A-Z][a-z\' ]+)\:[A-Z]+(\s?[A-Z]+)*\b");

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }

                Match matchText = pattern.Match(input);

                if (matchText.Success)
                {
                    string encrypt = string.Empty;
                    int key = matchText.Groups["artist"].Value.Length;

                    foreach (char symbol in input)
                    {
                        char newSymbol = symbol;
                        if (symbol != ' ' && symbol != '\'')
                        {
                            if (symbol == ':')
                            {
                                newSymbol = '@';
                            }
                            else
                            {
                                newSymbol = (char)(symbol + key);

                                if (symbol <= 90 && newSymbol > 90)
                                {
                                    newSymbol = (char)(64 + (newSymbol - 64) % 26);
                                }
                                else if (symbol >= 97 && symbol <= 122 && newSymbol > 122)
                                {
                                    newSymbol = (char)(96 + (newSymbol - 96) % 26);
                                }
                                    
                            }
                        }
                        encrypt += newSymbol;
                    }
                    Console.WriteLine($"Successful encryption: {encrypt}");
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }
    }
}
