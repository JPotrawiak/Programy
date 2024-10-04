

namespace _1._tablice_listy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = ReadInt("Podaj liczbę n:", 0, int.MaxValue);

            string[] names = new string[n];
            int[] ages = new int[n];

            for (int i = 0; i < n; i++)
            {
                names[i] = ReadString($"Podaj imię osoby {i+1}:");
                ages[i] = ReadInt($"Podaj wiek osoby {i+1}:", 0, 150);
            }
            List<string> namesStartsWithA = names.Where(name => name.StartsWith("A", StringComparison.OrdinalIgnoreCase)).ToList();
        }

        private static string ReadString(string prompt)
        {
            string result;
            bool valid;
            do
            {
                Console.Write(prompt);
                result = Console.ReadLine();
                if (string.IsNullOrEmpty(result) || string.IsNullOrWhiteSpace(result))
                {
                    Console.WriteLine("Podaj nie pusty ciąg znaków");
                }
            } while (string.IsNullOrEmpty(result));
            return result;
        }

        private static int ReadInt(string prompt, int low, int high)
        {
            int result;
            bool valid;
            do
            {
                Console.WriteLine(prompt);
                valid = int.TryParse(Console.ReadLine(), out result) && result >= low && result <= high;
                if (!valid)
                {
                    Console.WriteLine($"Podaj liczbę z zakresu {low} - {high}");
                }
            } while (!valid);
            return result;
        }
    }
}

//•	Napisz program, który wczytuje z klawiatury liczbę n, a następnie n imion i wieków osób.
//•	Użyj tablicy, aby przechować wczytane imiona i wieki.
//•	Użyj listy, aby przechować tylko te imiona, które zaczynają się na literę A.
//•	Użyj słownika, aby przechować pary (imie, wiek) dla wszystkich osób, których wiek jest większy niż 18 lat.
//•	Wypisz na ekranie zawartość tablicy, listy i słownika.