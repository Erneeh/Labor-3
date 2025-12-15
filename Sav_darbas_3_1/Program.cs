using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savarankiškas_darbas_3_1
{
    class Studentas
    {
        private string pavVrd;  // studento pavardė ir vardas
        private int pazym;      // pažymys (įvertinimas)

        public Studentas()
        {

        }

        public Studentas(string pavv)
        {
            pavVrd = pavv;
            this.pazym = 0;
        }

        public Studentas(string pavv, int pazym)
        {
            pavVrd = pavv;
            this.pazym = pazym;
        }

        public string ImtiPavv() { return pavVrd; }

        public int ImtiPazym() { return pazym; }

        // Užklotas metodas ToString()
        public override string ToString()
        {
            string eilute;
            eilute = string.Format("{0, -20}   {1, 2}", pavVrd, pazym);
            return eilute;
        }






        //// Užklotas metodas GetHashCode()
        //public override int GetHashCode()
        //{
        //    Console.WriteLine("GetHashCode");
        //    return base.GetHashCode();
        //}

        public override bool Equals(object obj)
        {
            return obj is Studentas studentas &&
                   pavVrd == studentas.pavVrd;
        }

        public override int GetHashCode()
        {
            return 1313545832 + EqualityComparer<string>.Default.GetHashCode(pavVrd);
        }


        // Užklotas operatorius >

        //pirma patikrina kurio skaicius didesnis - jeigu stud1 > stud2 - printina stud1
        //jeigu stud1 == stud2, tikrina pagal kurio abeceles raide yra didesne  pvz - B > A
        // stud1 = A B 10
        // stud2 = A C 10        TAI STUD2 > STUD1

        //stud1 = A C 10
        //stud2 = A B 10     TAI STUD1 > STUD2

        //stud1 = A B 10
        //stud2 = A C 6          tai stud1>stud2 
        public static bool operator >(Studentas stud1, Studentas stud2)
        {
            int poz = String.Compare(stud1.pavVrd, stud2.pavVrd,
                                     StringComparison.CurrentCulture);
            return (stud1.pazym > stud2.pazym ||
                    (stud1.pazym == stud2.pazym && poz > 0));

        }

        // Užklotas operatorius <

        //pirma patikrina kurio skaicius mazesnis - jeigu stud1 < stud2 - printina stud1
        //jeigu stud1 == stud2, tikrina pagal kurio abeceles raide yra mazesne  pvz - A < B
        // stud1 = A B 10
        // stud2 = A C 10        TAI STUD1 < STUD2

        //stud1 = A C 10
        //stud2 = A B 10     TAI STUD2 < STUD1

        //stud1 = A B 10
        //stud2 = A C 6    stud2 < stud1
        public static bool operator <(Studentas stud1, Studentas stud2)
        {
            int poz = String.Compare(stud1.pavVrd, stud2.pavVrd,
                                     StringComparison.CurrentCulture);
            return (stud1.pazym < stud2.pazym ||
                    (stud1.pazym == stud2.pazym && poz < 0));
        }

        //visi atsakymai false nes nera override funkcijos - kuri pakeistu ju reiksme/logika

        //kai tikrina ar lygu be override - nesvarbu kokie duomenys yra tikrinimi ir ar jie lygus, jeigu 2 skirtingi objektai, jie niekada nebus lygus
        //pvz 2 ID korteles - jos gali buti identiskos, bet jos yra dvi skirtingos korteles - false

        //kai naudojam override - mes patikrinam butent tuos parametrus kuriu mums reikia - pvz ID KORTELES VARDAS/PAVARDE/MEDZIAGA - ir jeigu sutampa - true

        //public override bool Equals(object stud)
        //{
        //    if (stud == null || !(stud is Studentas))
        //        return false;

        //    Studentas stud2 = (Studentas)stud;

        //    return this.pavVrd == stud2.pavVrd;
        //}


    }

    class Program
    {
        static void Main(string[] args)
            
        {

            Studentas stud1 = new Studentas("Pavardenis Vardenis", 7);
            Studentas stud2 = new Studentas("Pavardenis Vardenis", 7);
            Studentas stud3 = new Studentas("Pavardenis Vardenis", 10);

            // I dalis
            Console.WriteLine();
            Console.WriteLine("stud1:   " + stud1);
            Console.WriteLine("stud2:   " + stud2.ToString());
            Console.WriteLine("stud3:   " + stud3.ToString());
            Console.WriteLine();
            Console.WriteLine("Užkloto operatoriaus > panaudojimo tyrimas");
            Console.WriteLine();
            Console.WriteLine("Lyginami stud1 ir stud3 objektai:");
            if (stud1 > stud3)
                Console.WriteLine("Atsakymas: stud1 > stud3.");
            else
                Console.WriteLine("Atsakymas: stud1 < stud3 arba stud1 = stud3.");
            Console.WriteLine();
            Console.WriteLine();


            // Equals panaudojimo tyrimas
            // I dalis
            Console.WriteLine("Equals panaudojimo tyrimas");
            Console.WriteLine();
            object stud11 = stud1;
            object stud12 = stud2;
            Console.WriteLine("stud11:   " + stud11.ToString());
            Console.WriteLine("stud12:   " + stud12.ToString());
            Console.WriteLine("I lyginimas");
            Console.WriteLine("stud11.Equals(stud12), Tipai objects");
            if (stud11.Equals(stud12))
                Console.WriteLine("LYGU.");
            else
                Console.WriteLine("NELYGU.");
            Console.WriteLine();

            // II dalis            
            var stud31 = stud1;
            var stud32 = stud2;
            Console.WriteLine("stud31:   " + stud31.ToString());
            Console.WriteLine("stud32:   " + stud32.ToString());
            Console.WriteLine("II lyginimas");
            Console.WriteLine("stud31.Equals(stud32), Tipai su var");
            if (stud31.Equals(stud32))
                Console.WriteLine("LYGU1.");
            else
                Console.WriteLine("NELYGU1.");
            Console.WriteLine();

            // III dalis
            Console.WriteLine("stud1:   " + stud1.ToString());
            Console.WriteLine("stud1:   " + stud1.ToString());
            Console.WriteLine("III lyginimas");
            Console.WriteLine("Equals (stud1, stud2), Tipai Studentas");
            if (Equals(stud1, stud2))
                Console.WriteLine("LYGU2.");
            else
                Console.WriteLine("NELYGU2.");
            Console.WriteLine();


            // IV dalis
            Console.WriteLine("stud1:   " + stud1.ToString());
            Console.WriteLine("stud1:   " + stud1.ToString());
            Console.WriteLine("IV lyginimas");
            Console.WriteLine("stud1.Equals(stud2), Tipai Studentas");
            if (stud1.Equals(stud2))
                Console.WriteLine("LYGU3.");
            else
                Console.WriteLine("NELYGU3.");
            Console.WriteLine();
        }
    }
}

