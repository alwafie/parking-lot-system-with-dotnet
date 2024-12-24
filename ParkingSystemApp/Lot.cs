namespace SistemParkir
{
    public class Lot
    {
        public int NomorLot { get; set; }
        public Kendaraan? KendaraanParkir { get; set; }
        public bool IsOccupied => KendaraanParkir != null;
        public Lot(int nomorLot)
        {
            NomorLot = nomorLot;
            KendaraanParkir = null;
        }
        public bool CheckIn(Kendaraan kendaraan)
        {
            if (IsOccupied)
                return false;

            KendaraanParkir = kendaraan;
            return true;
        }

        public bool CheckOut()
        {
            if (!IsOccupied)
                return false;

            KendaraanParkir = null;
            return true;
        }
    }
}