using System.Text;

namespace Message;
public class Message 
{

    private static readonly Dictionary<char, string> keypadMap = new Dictionary<char, string>()
    {
        {'1', "&'("},
        {'2', "ABC"},
        {'3', "DEF"},
        {'4', "GHI"},
        {'5', "JKL"},
        {'6', "MNO"},
        {'7', "PQRS"},
        {'8', "TUV"},
        {'9', "WXYZ"}
    };


    public static String OldPhonePad(string input)
    {
        if (string.IsNullOrWhiteSpace(input)) return string.Empty;

        string output = string.Empty;
        char previousDigit = ' ';
        int pressCount = 0;

        foreach (char c in input)
        {
            if (c == '#') 
            {
                break;
            }
            else if (c == ' ') 
            {
                if (previousDigit != ' ')
                {
                    output += GetValue(previousDigit, pressCount);
                }
                
                previousDigit = ' ';
                pressCount = 0;
            }
            else if (c == '*') 
            {
                // Remove last char when previousDigit is not null and output has value
                if (previousDigit == ' ' & output.Length > 0)
                {
                    output = output.Substring(0, output.Length - 1);
                }
                
                previousDigit = ' ';
                pressCount = 0;
            }
            else if (keypadMap.ContainsKey(c))
            {
                if (c == previousDigit)
                {
                    pressCount++;
                }
                else
                {
                    if (previousDigit != ' ')
                    {
                        output += GetValue(previousDigit, pressCount);
                    }

                    previousDigit = c;
                    pressCount = 1;
                }
            }
        }

        if (previousDigit != ' ')
        {
            output += GetValue(previousDigit, pressCount);
        }


        return output;


    }

    private static char GetValue(char number, int count) {
        string chars = keypadMap[number];
        int index = (count - 1) % chars.Length;
        return chars[index];
    }



    public static void Main(string[] args)
    {
        Console.WriteLine(OldPhonePad("222 2 22#"));
        Console.WriteLine(OldPhonePad("222 2 221222 2777#"));
        Console.WriteLine(OldPhonePad("8 88777444666*664#"));
    }
}
