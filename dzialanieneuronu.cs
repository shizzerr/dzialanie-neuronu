using System;
using System.IO;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Tworzymy pętlę dzięki której można wygodnie powtórzyć działanie programu
            int i = 1;
            do
            {
                //Deklarujemy zmienne
                int
                    X1, X2, Net, Rand1, Rand2,
                    W1 = -2,
                    W2 = 3,
                    B = -6,
                    Y = 0;
                string Dane;
                Random random = new Random();
                StreamWriter SW;
                //Sprawdzamy czy podana lokalizacja istnieje
                if (Directory.Exists(@"C:\Klan17"))
                {
                    Console.WriteLine("\nLokalizacja została odnaleziona");
                }
                else
                {
                    //Jeżeli lokalizacja nie istnieje program tworzy ją
                    Directory.CreateDirectory(@"C:\Klan17");
                    File.Create(@"C:\Klan17\dane.txt").Dispose();
                }
                //Wprowadzamy losowe wartości do pliku z danymi
                Rand1 = random.Next(1, 100);
                Rand2 = random.Next(1, 100);
                string randoms = $"{Rand1},{Rand2}";
                File.WriteAllText(@"C:\Klan17\dane.txt", randoms);

                //Tworzymy zmienne z lokalizacjami plików
                string patchR = @"C:\Klan17\dane.txt";
                string patchW = @"C:\Klan17\wynik.txt";
                //Sprawdzamy czy istnieje plik w danej lokalizacji
                if (File.Exists(patchR))
                {
                    //Wczytujemy dane z pliku o nazwie "dane.txt"
                    Dane = File.ReadAllText(patchR);
                    Console.WriteLine("Dane z pliku zostały wczytane");

                    //Konwertujemy dane ze stringa do tablicy zawierającej wartości intowe
                    int[] Dane2 = Dane.Split(',').Select(int.Parse).ToArray();

                    //Przypisujemy przekonwertowane dane do zmiennych X1 oraz X2 następnie wypisujemy je na ekranie
                    X1 = Dane2[0];
                    X2 = Dane2[1];
                    Console.WriteLine("Wczytana liczba X1 to: {0}", X1);
                    Console.WriteLine("Wczytana liczba X2 to: {0}", X2);

                    //Definujemy sieć
                    Net = X1 * W1 + X2 * W2 + 1 * B;
                    if (Net > 0)
                    {
                        Y = 1;
                    }
                    else
                    {
                        Y = 0;
                    }
                    //Wypisujemy na ekranie wynik działania programu
                    Console.WriteLine($"Liczba wyjściowa Y dla wartości X1 = {X1} oraz X2 = {X2} wynosi: {Y}");

                    //String zawierający dane do zapisu w pliku txt
                    string result = $"Liczba wyjściowa Y dla wartości X1 = {X1} oraz X2 = {X2} wynosi: {Y}";

                    //Sprawdzamy czy istnieje plik wynik.txt w podanej lokalizacji a jeśli nie to tworzymy go
                    if (File.Exists(patchW))
                    {
                        //Zapisujemy wynik w pliku "wynik.txt"
                        //File.WriteAllText(patchW, result);
                        SW = File.AppendText(patchW);
                        SW.WriteLine(result);
                        SW.Close();
                        Console.WriteLine("Dane zostały zapisane do pliku");

                    }
                    else
                    {
                        //Jeżeli plik nie został odnaleziony, program tworzy nowy plik oraz zapisuje w nim dane
                        File.Create(patchW).Dispose();
                        Console.WriteLine("Plik nie został odnaleziony, więc został utworzony w podanej lokalizacji");
                        SW = File.AppendText(patchW);
                        SW.WriteLine(result);
                        SW.Close();
                        Console.WriteLine("Dane zostały zapisane do pliku");
                    }
                }
                else
                {
                    //W przypadku gdy plik nie zostanie odnaleziony program wyświetli komunikat
                    Console.WriteLine("Podany plik nie istnieje");
                }
                //Pytamy użytkownika czy chce powtórzyć działanie programy wartość 0 zamknie program, wartość 1 powtórzy go
                Console.WriteLine("Czy chcesz powtórzyć działanie programu?");
                Console.Write("Wpisz 1 jeśli tak lub dowolną inną liczbę jeśli nie: ");
                try
                {
                    i = Convert.ToInt32(Console.ReadLine());
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Wprowadzono błędny znak, program zostanie zamknięty.");
                    i = 0;
                    Console.ReadKey(true);
                }
            } while (i == 1);
        }
    }
}