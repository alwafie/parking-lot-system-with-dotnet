using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemParkir
{
    public class Parkir
    {
        public List<Lot> Lots { get; set; }

        public Parkir(int totalLot)
        {
            Lots = new List<Lot>();
            for (int i = 1; i <= totalLot; i++)
            {
                Lots.Add(new Lot(i));
            }
        }

        public bool CheckInKendaraan(Kendaraan kendaraan)
        {
            var lotKosong = Lots.FirstOrDefault(l => !l.IsOccupied);

            if (lotKosong != null && (kendaraan.JenisKendaraan == JenisKendaraan.Mobil || kendaraan.JenisKendaraan == JenisKendaraan.Motor))
            {
                return lotKosong.CheckIn(kendaraan);
            }

            return false;
        }

        public bool CheckOutKendaraan(int nomorLot)
        {
            var lotDiIsi = Lots.FirstOrDefault(l => l.IsOccupied && l.NomorLot == nomorLot);
            return lotDiIsi?.CheckOut() ?? false;
        }

        public void Status()
        {
            Console.WriteLine("Slot   No.        Type    Registration No    Colour");
            Console.WriteLine("-------------------------------------------------------");

            foreach (var lot in Lots)
            {
                if (lot.IsOccupied)
                {
                    var kendaraan = lot.KendaraanParkir;
                    Console.WriteLine($"{lot.NomorLot,-8} {kendaraan.JenisKendaraan,-8} {kendaraan.NomorPolisi,-18} {kendaraan.Warna}");
                }
                else
                {
                    Console.WriteLine($"{lot.NomorLot,-8} {"Kosong",-12} {"-",-8} {"-",-18} {"-"}");
                }
            }
        }

        public List<Kendaraan> LaporanNomorPolisiGanjil()
        {
            var kendaraanGanjil = new List<Kendaraan>();

            foreach (var lot in Lots.Where(l => l.IsOccupied))
            {
                var nomorPolisiString = lot.KendaraanParkir.NomorPolisi;
                var parts = nomorPolisiString.Split('-');

                if (parts.Length == 3 && int.TryParse(parts[1], out int nomorPolisi))
                {
                    if (nomorPolisi % 2 != 0)
                    {
                        kendaraanGanjil.Add(lot.KendaraanParkir);
                    }
                }
            }

            return kendaraanGanjil;
        }


        public List<Kendaraan> LaporanNomorPolisiGenap()
        {
            var kendaraanGenap = new List<Kendaraan>();

            foreach (var lot in Lots.Where(l => l.IsOccupied))
            {
                var nomorPolisiString = lot.KendaraanParkir.NomorPolisi;
                var parts = nomorPolisiString.Split('-');

                if (parts.Length == 3 && int.TryParse(parts[1], out int nomorPolisi))
                {
                    if (nomorPolisi % 2 == 0)
                    {
                        kendaraanGenap.Add(lot.KendaraanParkir);
                    }
                }
            }

            return kendaraanGenap;
        }


        public List<Kendaraan> LaporanMobil()
        {
            var kendaraanMobil = new List<Kendaraan>();

            foreach (var lot in Lots.Where(l => l.IsOccupied))
            {
                if (lot.KendaraanParkir.JenisKendaraan == JenisKendaraan.Mobil)
                {
                    kendaraanMobil.Add(lot.KendaraanParkir);
                }
            }

            return kendaraanMobil;
        }

        public List<Kendaraan> LaporanMotor()
        {
            var kendaraanMotor = new List<Kendaraan>();

            foreach (var lot in Lots.Where(l => l.IsOccupied))
            {
                if (lot.KendaraanParkir.JenisKendaraan == JenisKendaraan.Motor)
                {
                    kendaraanMotor.Add(lot.KendaraanParkir);
                }
            }

            return kendaraanMotor;
        }

        public Dictionary<string, int> LaporanWarnaKendaraan()
        {
            var laporanWarna = new Dictionary<string, int>();

            foreach (var lot in Lots.Where(l => l.IsOccupied))
            {
                var warna = lot.KendaraanParkir.Warna;
                if (laporanWarna.ContainsKey(warna))
                {
                    laporanWarna[warna]++;
                }
                else
                {
                    laporanWarna.Add(warna, 1);
                }
            }

            return laporanWarna;
        }

    }
}