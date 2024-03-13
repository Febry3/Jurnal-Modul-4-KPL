using System.Security.Cryptography.X509Certificates;

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

    //enum dari posisi yang ada
    public enum Posisi { Berdiri, Terbang, Tengkurap, Jongkok};
    //enum dari aksi yang dapat dilakukan
    public enum Action { tombolW, tombolX, tombolS, tidakMenekan};
    


    //membuat class posisikarakter
    public class PosisiKarakterGame
    {
        //inisiasi kondisi awal karakter
        public Posisi posisiSekarang = Posisi.Berdiri;
        //membuat class transisi
        public class Transition
        {
            public Posisi stateAwal;
            public Posisi stateAkhir;
            public Action action;
            public Transition(Posisi stateAwal, Posisi stateAkhir, Action action)
            {
                this.stateAwal = stateAwal;
                this.stateAkhir = stateAkhir;
                this.action = action;
            }
        }
        //membuat segala kondisi yang mungkin terjadi dari aksi penekanan tombol
        Transition[] transition =
        {
            new Transition(Posisi.Berdiri, Posisi.Terbang, Action.tombolW),
            new Transition(Posisi.Terbang, Posisi.Berdiri, Action.tombolS),
            new Transition(Posisi.Terbang, Posisi.Jongkok, Action.tombolX),
            new Transition(Posisi.Berdiri, Posisi.Jongkok, Action.tombolS),
            new Transition(Posisi.Jongkok, Posisi.Berdiri, Action.tombolW),
            new Transition(Posisi.Jongkok, Posisi.Tengkurap, Action.tombolS),
            new Transition(Posisi.Tengkurap, Posisi.Jongkok, Action.tombolW),
        };
        //method untuk mendapat state akhir setelah diberi aksi
        public Posisi getNextState(Posisi stateAwal, Action action)
        {
            Posisi stateAkhir = stateAwal;

            for (int i = 0; i < transition.Length; i++)
            {
                Transition transisi = transition[i];
                if (stateAwal == transisi.stateAwal && action == transisi.action)
                {
                    return transisi.stateAkhir;
                    
                }
            }

            return stateAkhir;
        }
        // method untuk mengoutputkan kondisi akhir ketika berdiri dan tengkurap
        public void menjalankanKarakter(Action action)
        {   
            
            posisiSekarang = getNextState(posisiSekarang, action);
            if (posisiSekarang == Posisi.Berdiri)
            {
                Console.WriteLine("Posisi Standby");
            }
            if (posisiSekarang == Posisi.Tengkurap)
            {
                Console.WriteLine("Posisi Istirahat");
            }
            
            
        }
    }




    //menjalankan fungsi
    public static void Main(string[] args)
    {   
        //KodeBuah buah = new KodeBuah();
        //Console.WriteLine("Kode Buah: "+ Buah.Apel + " adalah " + buah.getKodeBuah(Buah.Apel));

        PosisiKarakterGame p1 = new PosisiKarakterGame();
        //Posiis awal berdiri
        p1.menjalankanKarakter(Action.tombolW);
        //menekan tombol w sehingga posisi karakter menjadi terbang dari berdiri
        p1.menjalankanKarakter(Action.tombolS);
        //Menekan tombol S sehingga posisi karakter menjadi berdiri dari terbang
    }
}