using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labor3
{

    class Studentas
    {
        private string
            pavarde,
            vardas,
            grupe;

        private int[] pazymiai;
        private int pazkiekis;

        public Studentas()
        {
            pavarde = "";
            vardas = "";
            grupe = "";
            pazkiekis = 0;
            pazymiai = new int[20];
        }

        public void Deti(string pav,
            string vard,
            string grp,
            int[] paz,
            int pazkiek)
        {
            pavarde = pav;
            vardas = vard;
            grupe = grp;
            int index = 0;
            for (int i = 0; i < pazkiek; i++)
                pazymiai[index++] = paz[i];
            pazkiekis = index;
        }

        public override string ToString()
        {
            string eilute;
            eilute = string.Format("{0, -12} {1, -9} {2, -7}",
                pavarde, vardas, grupe);
            for (int i = 0; i < pazkiekis; i++)
            {
                eilute = eilute + string.Format("{0, 3:d}", pazymiai[i]);
            }
            return eilute;
        }


        //veikia kaip "metodas" jeigu yra callinamas sitas operatorius ! 
        // ir prie jo yra studento objektas - sitas bus naudojamas
        public static bool operator !(Studentas c1)
        {
            for (int i = 0; i < c1.pazkiekis; i++)
            {
                if (c1.pazymiai[i] < 9)
                    return true;
            }

            return false;
        }

        public static bool operator <=(Studentas st1,
            Studentas st2)
        {
            int p = String.Compare(st1.pavarde, st2.pavarde,
                StringComparison.CurrentCulture);
            int v = String.Compare(st1.vardas, st2.vardas,
                StringComparison.CurrentCulture);
            return (p < 0 || (p == 0 && v < 0));
        }

        public static bool operator >=(Studentas st1,
            Studentas st2)
        {
            int p = String.Compare(st1.pavarde, st2.pavarde,
                StringComparison.CurrentCulture);
            int v = String.Compare(st1.vardas, st2.vardas,
                StringComparison.CurrentCulture);
            return (p > 0 || (p == 0 && v > 0));
        }


    }

    class Fakultetas
    {
        const int CMax = 100;   //maksimalus studentu skaicius
        private Studentas[] St; //studentu duomenys
        private int n;          //studentu skaicius

        public Fakultetas()
        {
            n = 0;
            St = new Studentas[CMax];
        }

        public int Imti()
        {
            return n;
        }

        public Studentas Imti(int i)
        {
            return St[i];
        }

        public void Deti(Studentas ob)
        {
            St[n++] = ob;
        }
        

        public void Rikiuoti()
        {
            for (int i = 0; i < n - 1; i++)
            {
                Studentas min = St[i];
                int im = i;
                for (int j = i + 1; j < n; j++)
                    if (St[j] >= min)
                    {
                        min = St[j];
                        im = j;
                    }

                St[im] = St[i];
                St[i] = min;
            }
        }

    }

    


    internal class Program
    {
        const string CFd = "..\\..\\U1.txt";
        const string CFr = "..\\..\\Rezultatai.txt";

        static void Main(string[] args)
        {
            Fakultetas grupes = new Fakultetas();
            Fakultetas grupes1 = new Fakultetas();
            if (File.Exists(CFr))
                File.Delete(CFr);

            Skaityti(ref grupes, CFd);
            Spausdinti(grupes, CFr, " Pradinis studentu sarasas");

            Formuoti(grupes, ref grupes1);
            if (grupes1.Imti() > 0)
                Spausdinti(grupes1, CFr, " Naujas studentu sarasas");
            else
                using (var fr = File.AppendText(CFr))
                {
                    fr.WriteLine("Tokiu studentu nera");
                }

            Console.WriteLine("Programa baige darba!");

            //surikiuoja pagal/pries abeceles tvarka
            grupes1.Rikiuoti();
            Spausdinti(grupes1, CFr, " Rikiuotas sarasas");
        }

        static void Skaityti(ref Fakultetas grupe,
            string fv)
        {
            string pv, vrd, grp;
            int[] pz = new int[20];
            int pazkiekis;
            string[] lines = File.ReadAllLines(fv);
            foreach (string line in lines)
            {
                string[] parts = line.Split(';');
                pv = parts[0].Trim();
                vrd = parts[1].Trim();
                grp = parts[2].Trim();

                string[] eil = parts[3].Trim().Split(new[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries);
                pazkiekis = 0;
                foreach (string eilute in eil)
                {
                    int aa = int.Parse(eilute);
                    pz[pazkiekis++] = aa;
                }

                Studentas stud = new Studentas();
                stud.Deti(pv, vrd, grp, pz, pazkiekis);
                grupe.Deti(stud);
            }
        }

        static void Spausdinti(Fakultetas grupe, string fv, string antraste)
        {
            string virsus =
                "----------------------------------------\r\n"
                + " Pavarde     Vardas      Grupe     Pazymiai   \r\n"
                + "----------------------------------------";
            using (var fr = File.AppendText(fv))
            {
                fr.WriteLine(antraste);
                fr.WriteLine(virsus);
                for (int i = 0; i < grupe.Imti(); i++)
                    fr.WriteLine("{0}", grupe.Imti(i).ToString());
                fr.WriteLine("----------------------------------------");
            }
        }

        static void Formuoti(Fakultetas D,
            ref Fakultetas R)
        {
            for (int i = 0; i < D.Imti(); i++)
                if (!D.Imti(i))
                    ;
                else
                    R.Deti(D.Imti(i));
        }

    }
}
