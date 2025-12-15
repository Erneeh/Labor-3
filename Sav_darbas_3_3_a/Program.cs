using System;
using System.IO;

namespace Sav_P3_2
{
    class Studentas
    {
        private string pavVrd;    // studento pavardė ir vardas
        private string grupe;     // studento grupė
        private int kiek;         // pažymių kiekis
        private int[] pazym;      // pažymiai (įvertinimai)
        private int suma;         // pagalbinis kintamasis
        private double vidurkis;  // pagalbinis kintamasis
        private string eilute;    // pagalbinis kintamasis

        public Studentas()
        {

        }

        public Studentas(string pavv, string grupe, int kiek, int[] pazym)
        {
            pavVrd = pavv;
            this.grupe = grupe;
            this.kiek = kiek;
            this.pazym = pazym;
            this.suma = 0;
            eilute = "";
            for (int j = 0; j < kiek; j++)
            {
                this.suma += pazym[j];
                eilute = eilute + String.Format("{0,3:d}   ", pazym[j]);
            }
            vidurkis = (suma * 1.0) / kiek;
        }

        public string ImtiPavv() { return pavVrd; }

        public string ImtiGr() { return grupe; }

        public int ImtiKiek() { return kiek; }

        public int ImtiPaz(int i) { return pazym[i]; }

        public int ImtiSuma() { return suma; }

        // Užklotas metodas ToString()
        public override string ToString()
        {
            string eilute1;
            eilute1 = string.Format("{0, -20}   {1, 2}  {2,-15} ", pavVrd, grupe, eilute);
            return eilute1;
        }

        // Užklotas metodas Equals()
        public override bool Equals(object objektas)
        {
            Studentas stud = objektas as Studentas;
            //return this.Equals(stud);
            return stud.pavVrd == pavVrd;
        }

        public bool Equals(Studentas stud)
        {
            return stud.pavVrd == pavVrd;
        }

        // Užklotas metodas GetHashCode()
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        // Užklotas operatorius ==
        public static bool operator ==(Studentas stud1, Studentas stud2)
        {
            //Console.WriteLine("Darbas");
            return stud1.pavVrd == stud2.pavVrd;
            // arba
            //int poz = String.Compare(stud1.pavVrd, stud2.pavVrd,
            //                           StringComparison.CurrentCulture);
            //return poz == 0;
        }

        // Užklotas operatorius !=
        public static bool operator !=(Studentas stud1, Studentas stud2)
        {
            return !(stud1.pavVrd == stud2.pavVrd);
            // arba
            //int poz = String.Compare(stud1.pavVrd, stud2.pavVrd,
            //                           StringComparison.CurrentCulture);
            //return poz != 0;
        }

        // Užklotas operatorius >
        public static bool operator >(Studentas stud1, Studentas stud2)
        {
            int poz = String.Compare(stud1.pavVrd, stud2.pavVrd,
                                     StringComparison.CurrentCulture);
            return poz > 0;
        }

        // Užklotas operatorius <
        public static bool operator <(Studentas stud1, Studentas stud2)
        {
            int poz = String.Compare(stud1.pavVrd, stud2.pavVrd,
                                     StringComparison.CurrentCulture);
            return poz < 0;
        }

        // Užklotas operatorius >=
        public static bool operator >=(Studentas stud1, Studentas stud2)
        {
            int poz = String.Compare(stud1.pavVrd, stud2.pavVrd,
                                     StringComparison.CurrentCulture);
            if ((stud1.vidurkis > stud2.vidurkis) ||
                ((stud1.pazym == stud2.pazym) && (poz > 0))) return true;
            else return false;
        }

        // Užklotas operatorius <=
        public static bool operator <=(Studentas stud1, Studentas stud2)
        {
            int poz = String.Compare(stud1.pavVrd, stud2.pavVrd,
                                     StringComparison.CurrentCulture);
            if ((stud1.vidurkis < stud2.vidurkis) ||
                ((stud1.pazym == stud2.pazym) && (poz < 0))) return true;
            else return false;
        }
    }

    class Grupe
    {
        private string grupe;     // studento grupė
        private int kiek;         // pažymių kiekis        
        private int suma;         // pažymių suma
        private double vidurkis;  // pažymių vidurkis

        public Grupe()
        {
             
        }

        public Grupe(string grupe, int kiek, int suma)
        {
            this.grupe = grupe;
            this.kiek = kiek;
            this.suma = suma;
            vidurkis = suma * 1.0 / kiek;
        }

        public string ImtiGr() { return grupe; }

        public int ImtiKiek() { return kiek; }

        public int ImtiSuma(int i) { return suma; }

        public void Deti(int kiek, int suma)
        {
            this.kiek += kiek;
            this.suma += suma;
            vidurkis = this.suma * 1.0 / this.kiek;
        }

        // Užklotas metodas ToString()
        public override string ToString()
        {
            string eilute;
            eilute = string.Format("{0, -20}   {1, 7:f2}", grupe, vidurkis);
            return eilute;
        }

        // Užklotas operatorius >=
        public static bool operator >=(Grupe gr1, Grupe gr2)
        {
            int poz = String.Compare(gr1.grupe, gr2.grupe,
                                     StringComparison.CurrentCulture);
            if ((gr1.vidurkis > gr2.vidurkis) ||
                ((gr1.vidurkis == gr2.vidurkis) && (poz < 0))) return true;
            else return false;
        }

        // Užklotas operatorius <=
        public static bool operator <=(Grupe gr1, Grupe gr2)
        {
            int poz = String.Compare(gr1.grupe, gr2.grupe,
                                     StringComparison.CurrentCulture);
            if ((gr1.vidurkis < gr2.vidurkis) ||
                ((gr1.vidurkis == gr2.vidurkis) && (poz > 0))) return true;
            else return false;
        }
    }

    class MasyvasStudentai
    {
        const int Cn = 50;         // studentų masyvo dydis
        private Studentas[] Studentai;  // studentų objektų masyvas
        private int kiek;                // studentų skaičius

        public MasyvasStudentai()
        {
            kiek = 0;
            Studentai = new Studentas[Cn];
        }
        public Studentas ImtiStudenta(int i) { return Studentai[i]; }

        public int ImtiKiek() { return kiek; }

        public void DėtiStudenta(Studentas obj) { Studentai[kiek++] = obj; }

        // Grąžina nurodyto studento stud indeksą,
        // priešingu atveju grąžina -1
        public int StudentoVieta(Studentas stud)
        {
            for (int i = 0; i < kiek; i++)
            {
                if (Studentai[i] == stud)
                    return i;
            }
            return -1;
        }
    }

    class Grupes
    {
        const int Cn = 50;         // grupių masyvo dydis
        private Grupe[] Gr;        // grupių objektų masyvas
        private int kiek;          // grupių skaičius

        public Grupes()
        {
            kiek = 0;
            Gr = new Grupe[Cn];
        }

        public Grupe ImtiGrupe(int i) { return Gr[i]; }

        public int ImtiKiek() { return kiek; }

        public void DėtiGr(Grupe obj) { Gr[kiek++] = obj; }
        public void Deti_j(int j, int kiek, int suma)
        {
            Gr[j].Deti(kiek, suma);

        }

        public int RastiGrupe(string pavadinimas)
        {
            for (int i = 0; i < kiek; i++)
            {
                if (string.Equals(Gr[i].ImtiGr(), pavadinimas,
                        StringComparison.CurrentCulture))
                    return i;
            }

            return -1;
        }

        public void MinMax()
        {
            int maxInd;     // elemento su didžiausia reikšme indeksas
            for (int i = 0; i < kiek - 1; i++)
            {
                maxInd = i;
                for (int j = i + 1; j < kiek; j++)
                {
                    if (Gr[j] <= Gr[maxInd])
                        maxInd = j;
                }
                Grupe gr = Gr[i];
                Gr[i] = Gr[maxInd];
                Gr[maxInd] = gr;
            }
        }
    }

    class Program
    {
        const int Cn = 100;
        const string CFd = "..\\..\\Duom.txt";
        const string CFr = "..\\..\\Rezultatai.txt";
        static void Main(string[] args)
        {
            if (File.Exists(CFr))
                File.Delete(CFr);
            string fakultetas = "";
            MasyvasStudentai Pazymiai = new MasyvasStudentai();
            SkaitytiStudKont(CFd, Pazymiai, ref fakultetas);
            SpausdintiStudKont1(CFr, Pazymiai, "Studentų sąrašas", fakultetas);

            Grupes Gr = SukurtiGrupe(Pazymiai);
            SpausdintiGrupes(CFr, Gr, "Grupių vidurkiai");

            Gr.MinMax();
            SpausdintiGrupes(CFr, Gr, "Grupių sąrašas po rikiavimo");
        }

        static void SkaitytiStudKont(string fv, MasyvasStudentai Studentai, ref string fakultetas)
        {
            using (StreamReader srautas = new StreamReader(fv))
            {
                string eilute;  // duomenų failo eilutė 
                fakultetas = srautas.ReadLine();
                int i = 0;
                while ((eilute = srautas.ReadLine()) != null)
                {
                    string[] eilDalis = eilute.Split(';'); // failo eilutės dalys
                    string pavVrd = eilDalis[0];
                    string grupe = eilDalis[1];
                    int kiek = int.Parse(eilDalis[2]);
                    string[] eilDalis1 = eilDalis[3].Split(' ');
                    int[] pazym = new int[kiek];
                    for (int j = 0; j < kiek; j++)
                    {
                        pazym[j] = int.Parse(eilDalis1[j]);
                    }
                    Studentas studentas = new Studentas(pavVrd, grupe, kiek, pazym);
                    Studentai.DėtiStudenta(studentas);
                    i++;
                }
            }
        }

        //****************************************************************
        static void SpausdintiStudKont(string fv, MasyvasStudentai Studentai,
                                     string antraste, string fakultetas)
        {
            const string virsus =
                  "------------------------------------------------------------------\r\n"
                + " Nr.  Pavardė ir vardas        Grupė          Pažymiai\r\n"
                + "------------------------------------------------------------------";
            using (var fr = File.AppendText(fv))
            {
                fr.WriteLine("\n      " + fakultetas);
                fr.WriteLine("\n      " + antraste);
                fr.WriteLine(virsus);
                for (int i = 0; i < Studentai.ImtiKiek(); i++)
                {
                    fr.Write("{0, 3}   {1, -20}  {2, 5}   ",
                           i + 1, Studentai.ImtiStudenta(i).ImtiPavv(), Studentai.ImtiStudenta(i).ImtiGr());
                    for (int j = 0; j < Studentai.ImtiStudenta(i).ImtiKiek(); j++)
                    {
                        fr.Write("{0,3}   ", Studentai.ImtiStudenta(i).ImtiPaz(j));
                    }
                    fr.WriteLine();
                }
                fr.WriteLine("------------------------------------------------------------------\n");
            }
        }

        static void SpausdintiStudKont1(string fv, MasyvasStudentai Studentai,
                                     string antraste, string fakultetas)
        {
            const string virsus =
                  "------------------------------------------------------------------\r\n"
                + " Nr.  Pavardė ir vardas     Grupė            Pažymiai\r\n"
                + "------------------------------------------------------------------";
            using (var fr = File.AppendText(fv))
            {
                fr.WriteLine("\n      Fakultetas: " + fakultetas);
                fr.WriteLine("      " + antraste);
                fr.WriteLine(virsus);
                for (int i = 0; i < Studentai.ImtiKiek(); i++)
                {
                    fr.WriteLine("{0, 3}   {1, -20}",
                           i + 1, Studentai.ImtiStudenta(i).ToString());
                }
                fr.WriteLine("------------------------------------------------------------------\n");
            }
        }
        //**************************************************************

        static void SpausdintiGrupes(string fv, Grupes Gr, string antraste)
        {
            const string virsus =
                " Grupė                Vidurkis\r\n"
                + "-------------------------------";
            using (var fr = File.AppendText(fv))
            {
                fr.WriteLine("\n      " + antraste);
                fr.WriteLine(virsus);
                for (int i = 0; i < Gr.ImtiKiek(); i++)
                {
                    fr.WriteLine("{0}", Gr.ImtiGrupe(i).ToString());
                }
            }
        }

        static Grupes SukurtiGrupe(MasyvasStudentai stud)
        {
            //sukuria nauja grupiu masyva
            Grupes gr = new Grupes();

            //pereina per kiekviena studenta pazymiu masyve
            for (int i = 0; i < stud.ImtiKiek(); i++)
            {

                //prilygina s objekta pasirinktam studentui pagal indeksa
                Studentas s = stud.ImtiStudenta(i);

                //prilygina kintamaji g studento grupes pavadiniumui
                string g = s.ImtiGr();


                //patikrina ar egzistuoja grupe grupiu masyve
                int j = gr.RastiGrupe(g);
                if (j == -1)
                {
                    //jeigu ne - prideda nauja grupe 
                    gr.DėtiGr(new Grupe(g, s.ImtiKiek(), s.ImtiSuma()));
                }
                else
                {

                    //jeigu egzistuoja - prideda prie jau egzistuojamos grupes kieki ir suma
                    gr.Deti_j(j, s.ImtiKiek(), s.ImtiSuma());
                }
            }

            return gr;
        }

    }
}
