using System;

namespace SistemParkir
{
    public class Kendaraan{
        public string NomorPolisi {get; set;}
        public JenisKendaraan JenisKendaraan {get; set;}
        public string Warna {get; set;}

        public Kendaraan(string nomorPolisi, JenisKendaraan jenisKendaraan, string warna)
        {
            NomorPolisi = nomorPolisi;
            JenisKendaraan = jenisKendaraan;
            Warna = warna;
        }
    }
}