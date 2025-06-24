using System;

namespace KonversiKalkulatorPilihan
{
    class Program
    {
        static void Main()
        {
            bool berjalan = true;

            while (berjalan)
            {
                Console.Clear();
                Console.WriteLine("=== PROGRAM KALKULATOR & KONVERSI ===\n");
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Konversi Bilangan");
                Console.WriteLine("2. Kalkulator Aritmatika");
                Console.WriteLine("0. Keluar");
                Console.Write("\nPilih menu (0-2): ");

                string pilihan = Console.ReadLine();

                switch (pilihan)
                {
                    case "1":
                        MenuKonversi();
                        break;
                    case "2":
                        MenuKalkulator();
                        break;
                    case "0":
                        berjalan = false;
                        break;
                    default:
                        Console.WriteLine("Pilihan tidak valid. Harap masukkan angka 0, 1, atau 2.");
                        Pause();
                        break;
                }
            }

            Console.WriteLine("\nTerima kasih telah menggunakan aplikasi ini.");
        }

        static void MenuKonversi()
        {
            Console.Clear();
            Console.WriteLine("=== KONVERSI BILANGAN ===");
            Console.WriteLine("Aturan: Masukkan bilangan bulat (positif atau negatif).");
            Console.Write("Masukkan bilangan desimal: ");

            if (int.TryParse(Console.ReadLine(), out int angka))
            {
                int nilaiAbs = Math.Abs(angka);
                string prefix = angka < 0 ? "-" : "";

                Console.WriteLine("\n--- Hasil Konversi ---");
                Console.WriteLine($"Desimal      : {angka}");
                Console.WriteLine($"Biner        : {prefix}{Convert.ToString(nilaiAbs, 2)}");
                Console.WriteLine($"Oktal        : {prefix}{Convert.ToString(nilaiAbs, 8)}");
                Console.WriteLine($"Heksadesimal : {prefix}{Convert.ToString(nilaiAbs, 16).ToUpper()}");
            }
            else
            {
                Console.WriteLine("Input tidak valid. Masukkan bilangan bulat.");
            }

            Pause();
        }

        static void MenuKalkulator()
        {
            Console.Clear();
            Console.WriteLine("=== KALKULATOR ARITMATIKA ===");

            // Pilih basis bilangan pertama
            Console.WriteLine("\nPilih basis untuk bilangan pertama:");
            Console.WriteLine("1. Desimal");
            Console.WriteLine("2. Biner");
            Console.WriteLine("3. Oktal");
            Console.WriteLine("4. Heksadesimal");
            Console.Write("Pilihan basis (1-4): ");
            string basis1Input = Console.ReadLine();

            int basis1 = basis1Input switch
            {
                "1" => 10,
                "2" => 2,
                "3" => 8,
                "4" => 16,
                _ => -1
            };

            if (basis1 == -1)
            {
                Console.WriteLine("Basis bilangan pertama tidak valid.");
                Pause();
                return;
            }

            Console.Write($"Masukkan bilangan pertama: ");
            string angka1Str = Console.ReadLine();

            // Pilih basis bilangan kedua
            Console.WriteLine("\nPilih basis untuk bilangan kedua:");
            Console.WriteLine("1. Desimal");
            Console.WriteLine("2. Biner");
            Console.WriteLine("3. Oktal");
            Console.WriteLine("4. Heksadesimal");
            Console.Write("Pilihan basis (1-4): ");
            string basis2Input = Console.ReadLine();

            int basis2 = basis2Input switch
            {
                "1" => 10,
                "2" => 2,
                "3" => 8,
                "4" => 16,
                _ => -1
            };

            if (basis2 == -1)
            {
                Console.WriteLine("Basis bilangan kedua tidak valid.");
                Pause();
                return;
            }

            Console.Write($"Masukkan bilangan kedua : ");
            string angka2Str = Console.ReadLine();

            Console.Write("Masukkan operator (+, -, *, /): ");
            string op = Console.ReadLine();

            try
            {
                int angka1 = Convert.ToInt32(angka1Str, basis1);
                int angka2 = Convert.ToInt32(angka2Str, basis2);

                int hasil = op switch
                {
                    "+" => angka1 + angka2,
                    "-" => angka1 - angka2,
                    "*" => angka1 * angka2,
                    "/" => angka2 != 0 ? angka1 / angka2 : throw new DivideByZeroException("Pembagian dengan nol!"),
                    _ => throw new InvalidOperationException("Operator tidak dikenali.")
                };

                Console.WriteLine($"\nHasil: {angka1} {op} {angka2} = {hasil}");
                Console.WriteLine("Dalam Desimal     : " + hasil);
                Console.WriteLine("Dalam Biner       : " + Convert.ToString(hasil, 2));
                Console.WriteLine("Dalam Oktal       : " + Convert.ToString(hasil, 8));
                Console.WriteLine("Dalam Heksadesimal: " + Convert.ToString(hasil, 16).ToUpper());
            }
            catch (FormatException)
            {
                Console.WriteLine("Input bilangan tidak valid untuk basis yang dipilih.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Kesalahan: {ex.Message}");
            }

            Pause();
        }

        static void Pause()
        {
            Console.Write("\nTekan ENTER untuk melanjutkan...");
            Console.ReadLine();
        }
    }
}
