public class Program
{
    //enum buah sesuai tabel
    public enum Buah { Apel, Aprikot, Alpukat, Pisang, Paprika, Blackberry, Ceri, Kelapa, Jagung, Kurma, Durian, Anggur, Melon, Semangka };
    public class KodeBuah
    {
        //mereturn kodebuah index ke sesuai dari enum
        public String getKodeBuah(Buah buah)
        {
            String[] kodeBuah = {"A00", "B00", "C00", "D00", "E00", "F00", "H00", "I00", "J00", "K00", "L00", "M00", "N00", "O00" };
            return (kodeBuah[(int)buah]);
        }
    }
    //menjalankan fungsi
    public static void Main(string[] args)
    {   
        KodeBuah buah = new KodeBuah();
        Console.WriteLine("Kode Buah: "+ Buah.Apel + " adalah " + buah.getKodeBuah(Buah.Apel));
    }
}