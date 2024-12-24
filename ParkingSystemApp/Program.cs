using System;

namespace SistemParkir
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Selamat datang di Sistem Parkir .NET!");

            Console.Write("Masukkan jumlah total lot parkir: ");
            int totalLot;
            while (!int.TryParse(Console.ReadLine(), out totalLot) || totalLot <= 0)
            {
                Console.WriteLine("Jumlah lot tidak valid. Harap masukkan angka positif.");
            }

            var parkir = new Parkir(totalLot); 

            bool running = true;
            while (running)
            {
                Console.WriteLine("\nPilih Aksi:");
                Console.WriteLine("1. Check-in Kendaraan");
                Console.WriteLine("2. Check-out Kendaraan");
                Console.WriteLine("3. Status");
                Console.WriteLine("4. Laporan Nomor Polisi Ganjil");
                Console.WriteLine("5. Laporan Nomor Polisi Genap");
                Console.WriteLine("6. Laporan Jenis Kendaraan - Motor");
                Console.WriteLine("7. Laporan Jenis Kendaraan - Mobil");
                Console.WriteLine("8. Laporan Warna Kendaraan");
                Console.WriteLine("0. Keluar");

                var pilihan = Console.ReadLine();
                switch (pilihan)
                {
                    case "1":
                        Console.Write("Masukkan Nomor Polisi: ");
                        string nomorPolisi = Console.ReadLine();
                        Console.Write("Masukkan Jenis Kendaraan (Mobil/Motor): ");
                        string jenisKendaraanInput = Console.ReadLine();
                        JenisKendaraan jenisKendaraan;

                        if (!Enum.TryParse(jenisKendaraanInput, true, out jenisKendaraan))
                        {
                            Console.WriteLine("Jenis kendaraan tidak valid. Harap masukkan 'Mobil' atau 'Motor'.");
                            break;
                        }

                        Console.Write("Masukkan Warna Kendaraan: ");
                        string warna = Console.ReadLine();

                        var kendaraan = new Kendaraan(nomorPolisi, jenisKendaraan, warna);
                        if (parkir.CheckInKendaraan(kendaraan))
                            Console.WriteLine("Kendaraan berhasil check-in.");
                        else
                            Console.WriteLine("Lot penuh atau kendaraan tidak valid.");
                        break;

                    case "2":
                        Console.Write("Masukkan Nomor Lot Kendaraan yang ingin check-out: ");
                        if (int.TryParse(Console.ReadLine(), out int nomorLotCheckOut))
                        {
                            if (parkir.CheckOutKendaraan(nomorLotCheckOut))
                                Console.WriteLine("Kendaraan berhasil check-out.");
                            else
                                Console.WriteLine("Kendaraan tidak ditemukan pada lot tersebut.");
                        }
                        else
                        {
                            Console.WriteLine("Nomor lot tidak valid.");
                        }
                        break;

                    case "3":
                        parkir.Status();
                        break;

                    case "4":
                        var kendaraanGanjil = parkir.LaporanNomorPolisiGanjil();
                        Console.WriteLine($"Kendaraan Ganjil: {kendaraanGanjil.Count}");
                        break;

                    case "5":
                        var kendaraanGenap = parkir.LaporanNomorPolisiGenap();
                        Console.WriteLine($"Kendaraan Genap: {kendaraanGenap.Count}");
                        break;

                    case "6":
                        var kendaraanMotor = parkir.LaporanMotor();
                        Console.WriteLine($"Motor: {kendaraanMotor.Count}");
                        break;

                    case "7":
                        var kendaraanMobil = parkir.LaporanMobil();
                        Console.WriteLine($"Mobil: {kendaraanMobil.Count}");
                        break;

                    case "8":
                        var warnaLaporan = parkir.LaporanWarnaKendaraan();
                        foreach (var warnaKendaraan in warnaLaporan)
                            Console.WriteLine($"{warnaKendaraan.Key}: {warnaKendaraan.Value}");
                        break;

                    case "0":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Pilihan tidak valid.");
                        break;
                }
            }
        }
    }
}
