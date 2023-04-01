using System.Text;

namespace SquaredEncryption;

internal class Program
{
    public static string alphabet = "АБВГДЕЄЖЗИІЇКЛМНОПРСТУФХЦЧШЬЮЯ";

   

    static void Main(string[] args)
    {
        
        Console.WriteLine("Абетка \"Шифр Трисеміуса\": " + alphabet);
        Console.WriteLine("Початковий текст: 'Блаженний муж, що серед ґвалту й гуку стоїть, як дуб посеред бур і грому, на згоду з підлістю не простягає руку, волить зламатися, ніж поклониться злому. Іван ФРАНКО' \n");


        Console.WriteLine("запищіть ключ");
        string? key = Console.ReadLine();

        string? keyAlphabetUpRaw = key?.ToUpper() + alphabet;
        keyAlphabetUpRaw = new string(keyAlphabetUpRaw.Distinct().ToArray());
        string? keyAlphabetDownRaw = keyAlphabetUpRaw.ToLower();


        int i = 0;
        var CopyCharacters = keyAlphabetUpRaw.ToCharArray();

        while (i + 5 < CopyCharacters.Length)
        {
            char c = CopyCharacters[i];
            CopyCharacters[i] = CopyCharacters[i + 5];
            CopyCharacters[i + 5] = c;
            i++;
        }
         
        char[]? keyAlphabetUp = CopyCharacters;
        char[]? keyAlphabetDown = new string(keyAlphabetUp).ToLower().ToCharArray();
        string? result = "";
        string? result1 = "";
        string inputText = "Блаженний муж, що серед ґвалту й гуку стоїть, як дуб посеред бур і грому, на згоду з підлістю не простягає руку, волить зламатися, ніж поклониться злому. Іван ФРАНКО"; 
        foreach (char character in inputText)
        {
            
            if (keyAlphabetUp.Contains(character))
            {
                i = Array.IndexOf(keyAlphabetUpRaw.ToCharArray(), character);
                if (i < keyAlphabetUp.Length) result += keyAlphabetUp[i];
            }
            if (keyAlphabetDown.Contains(character))
            {
                i = Array.IndexOf(keyAlphabetDownRaw.ToCharArray(), character) ;
                if (i < keyAlphabetDown.Length) result += keyAlphabetDown[i];
            }
        }
        foreach (char character in result)
        {

            if (keyAlphabetUpRaw.Contains(character))
            {
                i = Array.IndexOf(keyAlphabetUp, character);
                if (i < keyAlphabetUpRaw.Length) result1 += keyAlphabetUpRaw.ToCharArray()[i];
            }
            if (keyAlphabetDownRaw.Contains(character))
            {
                i = Array.IndexOf(keyAlphabetDown, character);
                if (i < keyAlphabetDownRaw.Length) result1 += keyAlphabetDownRaw.ToCharArray()[i];
            }
        }

        Console.WriteLine("\nзашифрованний текст");
        Console.WriteLine( result );
        Console.WriteLine("\nдешифрованний текст");
        Console.WriteLine( result1);
        Console.ReadKey();

    }

   
}