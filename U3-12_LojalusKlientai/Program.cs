//IFD-5/1_Undzėnas_Ernestas_U3-12
//U3-13 lojalus klientai
// Tekstiniame faile yra lojalių parduotuvės klientų sąrašas: kortelės
// numeris, sukaupta virtualių pinigų suma, dažniausiai perkamos prekės
// pavadinimas, nupirktas kiekis, šiai prekei išleista pinigų suma. Parašykite
// programą, kuri spausdintų lojalių klientų duomenis lentele, surastų
// didžiausią populiariausiai prekei išleistą sumą, suskaičiuotų vidutinę
// virtualių pinigų sumą. Papildykite programą veiksmais, kurie leistų pasiūlyti
// klientams jų populiariausią prekę su nuolaida nuo vidutinės šios prekės kainos.
// Nuolaida klientui gali būti suteikiama, jeigu jo išleista pinigų suma ir nupirktas
// prekės kiekis viršija nurodytus dydžius. Pastarieji kartu su nuolaidos dydžiu
// įvedami klaviatūra. Sudarytą nuolaidų sąrašą programa turi spausdinti surikiuotą
// pagal prekės kainą ir kortelės numerį didėjimo tvarka.

using System;
using System.IO; //reikalinga skaitymui iš failo (StreamReader) 


namespace U3_12_LojalusKlientai
{

    /// <summary>
    /// Klasė kliento duomenims aprašyti
    /// </summary>
    class Klientas
    {
        private string kortelesNumeris, // kliento korteles numeris
            perkamiausiosPrekesPavadinimas; // kliento perkamiausia preke

        private double virtualusPinigai, // kliento sukaupti pinigai
            isleistiPinigai, //kliento isleisti pinigai
            prekesKaina; // prekes kaina

        private int nupirktasKiekis; // nupirktas kiekis

        /// <summary>
        /// Konstruktorius be parametrų
        /// </summary>
        public Klientas()
        {
            kortelesNumeris = "";
            perkamiausiosPrekesPavadinimas = "";
            virtualusPinigai = 0.0;
            isleistiPinigai = 0.0;
            nupirktasKiekis = 0;
            prekesKaina = (nupirktasKiekis > 0)
                ?
                (isleistiPinigai * 1.0 / nupirktasKiekis)
                : 0.0;
        }

        /// <summary>
        /// Konstruktorius su parametrais
        /// </summary>
        /// <param name="kortelesNumeris">korteles Numeris</param>
        /// <param name="virtualusPinigai">sukaupti pinigai</param>
        /// <param name="perkamiausiosPrekesPavadinimas">
        /// perkamiausia preke</param>
        /// <param name="nupirktasKiekis">nupirktas kiekis</param>
        /// <param name="isleistiPinigai">isleista suma</param>
        public Klientas(string kortelesNumeris, double virtualusPinigai,
            string perkamiausiosPrekesPavadinimas,
            int nupirktasKiekis, double isleistiPinigai)
        {
            this.kortelesNumeris = kortelesNumeris;
            this.perkamiausiosPrekesPavadinimas = perkamiausiosPrekesPavadinimas;
            this.virtualusPinigai = virtualusPinigai;
            this.isleistiPinigai = isleistiPinigai;
            this.nupirktasKiekis = nupirktasKiekis;
            prekesKaina = (nupirktasKiekis > 0)
                ?
                (isleistiPinigai * 1.0 / nupirktasKiekis)
                : 0.0;

        }

        /// <summary>
        /// Sukuria klienta su duotais parametrais
        /// </summary>
        /// <param name="kortNr">korteles numeris</param>
        /// <param name="prekesPav">prekes pavadinimas</param>
        /// <param name="vrtPinigai">sukaupti pinigai</param>
        /// <param name="islaidos">isleista suma</param>
        /// <param name="kiekis">nupirktas kiekis</param>
        public void PridetiKlienta(string kortNr,
            string prekesPav,
            double vrtPinigai,
            double islaidos,
            int kiekis)
        {
            kortelesNumeris = kortNr;
            perkamiausiosPrekesPavadinimas = prekesPav;
            virtualusPinigai = vrtPinigai;
            isleistiPinigai = islaidos;
            nupirktasKiekis = kiekis;
            prekesKaina = (nupirktasKiekis > 0)
                ? (isleistiPinigai * 1.0 / kiekis)
                : 0.0;
            ;
        }

        /// <summary>
        /// Grąžina kortelės numeri
        /// </summary>
        /// <returns></returns>
        public string ImtiKortelesNumeri()
        {
            return kortelesNumeris;
        }

        /// <summary>
        /// Grąžina perkamiausia prekę
        /// </summary>
        /// <returns></returns>
        public string ImtiPerkamiausiaPreke()
        {
            return perkamiausiosPrekesPavadinimas;
        }
        /// <summary>
        /// Grąžina sukauptus pinigus
        /// </summary>
        /// <returns></returns>
        public double ImtiVirtualiusPinigus()
        {
            return virtualusPinigai;
        }

        /// <summary>
        /// grąžina išleistus pinigus
        /// </summary>
        /// <returns></returns>
        public double ImtiIsleistusPinigus()
        {
            return isleistiPinigai;
        }

        /// <summary>
        /// grąžina nupirkta kiekį
        /// </summary>
        /// <returns></returns>
        public int ImtiNupirktaKieki()
        {
            return nupirktasKiekis;
        }

        /// <summary>
        /// grąžina prekės kainą
        /// </summary>
        /// <returns></returns>
        public double ImtiPrekesKaina()
        {
            return prekesKaina;
        }
        /// <summary>
        /// Spausdinimo funkcija
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string eilute;
            eilute = string.Format("{0, -13} {1, -10} {2, -9} {3, -8} {4}",
                kortelesNumeris, virtualusPinigai, perkamiausiosPrekesPavadinimas,
                nupirktasKiekis, isleistiPinigai);
            return eilute;
        }

        /// <summary>
        /// Spausdinimo funkcija su skirtingu parametru
        /// </summary>
        /// <returns></returns>
        public string ToStringSuKaina()
        {
            string eilute;
            eilute = string.Format("{0, -13} {1, -10} {2, -9} {3, -8} {4}",
                kortelesNumeris, virtualusPinigai, perkamiausiosPrekesPavadinimas,
                nupirktasKiekis, prekesKaina);
            return eilute;
        }

        /// <summary>
        /// Užklotas metodas patikrinimui
        /// </summary>
        /// <param name="klientas1">1 kliento objektas</param>
        /// <param name="klientas2">2 kliento objektas</param>
        /// <returns></returns>
        public static bool operator <=(Klientas klientas1, Klientas klientas2)
        {
            int pozicija = String.Compare(klientas1.kortelesNumeris,
                klientas2.kortelesNumeris, StringComparison.CurrentCulture);
            if ((klientas1.prekesKaina > klientas2.prekesKaina) ||
                ((klientas1.prekesKaina == klientas2.prekesKaina) && (pozicija > 0)))
                return true;
            return false;
        }

        /// <summary>
        /// Užklotas metodas patikrinimui
        /// </summary>
        /// <param name="klientas1">1 kliento objektas</param>
        /// <param name="klientas2">2 kliento objektas</param>
        /// <returns></returns>
        public static bool operator >=(Klientas klientas1,
            Klientas klientas2)
        {
            int pozicija = String.Compare(klientas1.kortelesNumeris,
                klientas2.kortelesNumeris, StringComparison.CurrentCulture);
            if ((klientas1.prekesKaina < klientas2.prekesKaina) ||
                ((klientas1.prekesKaina == klientas2.prekesKaina) && (pozicija < 0)))
                return true;
            return false;
        }


    }
    /// <summary>
    /// Klasė prekės duomenims
    /// </summary>
    class Preke
    {


        private string prekesPavadinimas; //prekes pavadinimas
        private int bendrasKiekis; // prekių bendras kiekis
        private double bendraSuma, vidutineKaina; // bendra suma ir vidutine kaina

        /// <summary>
        /// Konstruktorius be parametrų
        /// </summary>
        public Preke()
        {
            prekesPavadinimas = "";
            bendraSuma = 0.0;
            vidutineKaina = 0.0;
            bendrasKiekis = 0;
        }
        /// <summary>
        /// Konstruktorius su parametrais
        /// </summary>
        /// <param name="pav">prekes pavadinimas</param>
        /// <param name="kiekis">prekės kiekis</param>
        /// <param name="suma">prekės suma(kaina</param>
        public Preke(string pav,
            int kiekis,
            double suma)
        {
            prekesPavadinimas = pav;
            bendrasKiekis = kiekis;
            bendraSuma = suma;
            AtnaujintiVidutineKaina();
        }
        /// <summary>
        /// Metodas pridėti prekę
        /// </summary>
        /// <param name="kiekis">prekės kiekis</param>
        /// <param name="suma">prekės suma(kaina)</param>
        public void PridetiPreke(int kiekis, double suma)
        {
            bendrasKiekis += kiekis;
            bendraSuma += suma;
            AtnaujintiVidutineKaina();
        }

        /// <summary>
        /// Metodas skirtas atnaujinta vidutinę kainą
        /// </summary>
        private void AtnaujintiVidutineKaina()
        {
            vidutineKaina = bendraSuma / bendrasKiekis;
        }

        /// <summary>
        /// Grąžina prekės pavadinimą
        /// </summary>
        /// <returns>pavadinimas</returns>
        public string ImtiPavadinima()
        {
            return prekesPavadinimas;
        }

        /// <summary>
        /// Grąžina prekės vidutinę kainą
        /// </summary>
        /// <returns>vidutinė kaina</returns>
        public double ImtiVidutineKaina()
        {
            return vidutineKaina;
        }
        /// <summary>
        /// grąžina prekės bendra kiekį
        /// </summary>
        /// <returns>kiekis</returns>
        public int ImtiKieki()
        {
            return bendrasKiekis;
        }

        /// <summary>
        /// grąžina prekės suma
        /// </summary>
        /// <returns>bendra suma</returns>
        public double ImtiSuma()
        {
            return bendraSuma;
        }
        /// <summary>
        /// Spausdina duomenis
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0,-10} {1, 11} {2,18:F2}", 
                prekesPavadinimas, bendrasKiekis, vidutineKaina);
        }

        /// <summary>
        /// užklotas metodas patikrinimui
        /// </summary>
        /// <param name="obj">objektas</param>
        /// <returns>true/false</returns>
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        /// <summary>
        /// užklotas metodas
        /// </summary>
        /// <returns>hash code</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
    /// <summary>
    /// Prekių masyvo konteinerinė klasė
    /// </summary>
    class PrekiuMasyvas
    {
        const int Cn = 50;     //konstanta maksimaliam kiekiui
        private Preke[] prekes; //prekių masyvo objektas
        private int kiekis; //prekių bendras kiekis

        /// <summary>
        /// Konstruktorius be parametrų
        /// </summary>
        public PrekiuMasyvas()
        {
            kiekis = 0;
            prekes = new Preke[Cn];
        }
        /// <summary>
        /// Grąžina pasirinkta prekę iš masyvo
        /// </summary>
        /// <param name="i"></param>
        /// <returns>grąžina prekę</returns>
        public Preke ImtiPreke(int i)
        {
            return prekes[i];
        }

        /// <summary>
        /// Grąžina masyvo kiekį
        /// </summary>
        /// <returns>masyvo kiekį</returns>
        public int ImtiKiek()
        {
            return kiekis;
        }

        /// <summary>
        /// Užklotas metodas patikrinimui
        /// </summary>
        /// <param name="obj">objektas</param>
        /// <returns>true/false</returns>
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        /// <summary>
        /// Užklotas metodas patikrinimui
        /// </summary>
        /// <returns>hash code</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        /// <summary>
        /// Metodas skirtas pridėti/atnaujinti prekę
        /// </summary>
        /// <param name="prekesPavadinimas">prekės pavadinimas</param>
        /// <param name="prekiuKiekis">prekių kiekis</param>
        /// <param name="suma">prekės suma</param>
        public void PridetiArbaAtnaujinti(string prekesPavadinimas,
            int prekiuKiekis,
            double suma)
        {
            int indeksas = RastiPreke(prekesPavadinimas);
            if (indeksas < 0)
            {
                prekes[kiekis++] = new Preke(prekesPavadinimas,
                    prekiuKiekis, suma);
            }
            else
            {
                prekes[indeksas].PridetiPreke(prekiuKiekis, suma);
            }
        }

        /// <summary>
        /// Metodas skirtas patikrinti ar prekė jau egzistuoja
        /// </summary>
        /// <param name="pavadinimas">prekės pavadinimas</param>
        /// <returns>grąžina teigiama skaičių jeigu atitinka sąlygą</returns>
        public int RastiPreke(string pavadinimas)
        {
            for (int i = 0; i < kiekis; i++)
                if (string.Equals(prekes[i].ImtiPavadinima(), pavadinimas,
                        StringComparison.CurrentCulture))
                    return i;
            return -1;
        }

        /// <summary>
        /// Metodas skirtas rasti vidutinę prekės kainą
        /// </summary>
        /// <param name="pavadinimas">prekės pavadinimas</param>
        /// <returns>prekės vidutinę kainą</returns>
        public double VidutinePrekesKaina(string pavadinimas)
        {
            int indeksas = RastiPreke(pavadinimas);
            return prekes[indeksas].ImtiVidutineKaina();
        }

        /// <summary>
        /// Metodas skirtas rasti didžiausiai išleista sumą
        /// </summary>
        /// <returns>didžiausiai išleista suma</returns>
        public double DidziausiaIsleistaSuma()
        {
            double maksimaliSuma = 0.0;
            for (int i = 0; i < kiekis; i++)
            {
                if (prekes[i].ImtiSuma() > maksimaliSuma)
                {
                    maksimaliSuma = prekes[i].ImtiSuma();
                }
            }

            return maksimaliSuma;
        }



    }
    
    /// <summary>
    /// Klientų masyvo konteinerinė klasė
    /// </summary>
    class KlientuMasyvas
    {
        const int Cn = 100;    //konstanta maksimaliam masyvo skaičiui
        private Klientas[] Klientai; //klientų objekto masyvas
        private int klientuKiekis; //klientų kiekis

        /// <summary>
        /// Konstruktorius be parametrų
        /// </summary>
        public KlientuMasyvas()
        {
            Klientai = new Klientas[Cn];
            klientuKiekis = 0;
        }

        /// <summary>
        /// Grąžina pasirinktą klienta pagal indeksą
        /// </summary>
        /// <param name="indeksas">indeksas</param>
        /// <returns>pasirinktą klientą</returns>
        public Klientas ImtiKlienta(int indeksas)
        {
            return Klientai[indeksas];
        }

        /// <summary>
        /// grąžina klientų kiekį masyve 
        /// </summary>
        /// <returns>klientų kiekį</returns>
        public int ImtiKiek()
        {
            return klientuKiekis;
        }

        /// <summary>
        /// Metodas pridedantis klientą į masyvą
        /// </summary>
        /// <param name="klientas">kliento objektas</param>
        public void PridetiKlientaMasyve(Klientas klientas)
        {
            Klientai[klientuKiekis++] = klientas;
        }

        /// <summary>
        /// Metodas skirtas suskaičiuoti vidutinę sukauptų pinigų sumą
        /// </summary>
        /// <returns>vidutinę sukauptų pinigų suma</returns>
        public double VidutineVirtualiuPiniguSuma()
        {
            double bendraSuma = 0.0;

            for (int i = 0; i < klientuKiekis; i++)
            {
                bendraSuma += Klientai[i].ImtiVirtualiusPinigus() * 1.0;
            }
            double vidutineSuma = bendraSuma / klientuKiekis;
            return vidutineSuma;
        }

        /// <summary>
        /// Metodas patikrinantis ar klientas atitinka
        /// nuolaidos kriterijus
        /// </summary>
        /// <param name="klientas">kliento objektas</param>
        /// <param name="isleistaSuma">isleistos sumos
        /// kriterijus</param>
        /// <param name="nupirktasKiekis">nupirkto
        /// kiekio kriterijus</param>
        /// <returns>true jeigu atitinka kriterijus</returns>
        public bool KlientasAtitinkaKriterijus(Klientas klientas,
            double isleistaSuma, int nupirktasKiekis)
        {
            if ((klientas.ImtiNupirktaKieki() >= nupirktasKiekis) &&
                (klientas.ImtiIsleistusPinigus() >= isleistaSuma))
                return true;
            return false;
        }

        /// <summary>
        /// Metodas surikiuoja didėjimo tvarka
        /// </summary>
        public void SurikiuotiNuolaiduKlientuSarasa()
        {

            for (int i = 0; i < klientuKiekis - 1; i++)
            {
                Klientas maziausias = Klientai[i];
                int im = i;
                for (int j = i + 1; j < klientuKiekis; j++)

                    if (Klientai[j] >= maziausias)
                    {
                        maziausias = Klientai[j];
                        im = j;
                    }

                Klientai[im] = Klientai[i];
                Klientai[i] = maziausias;

            }
        }
    }


    /// <summary>
    /// Klasė užduotyje nurodytiems veiksmams atlikti
    /// </summary>
    internal class Program
    {
        const string CFduomenys = "..\\..\\Duom.txt";
        //duomenų failo pavadinimas
        const string CFrezultatai = "..\\..\\Rezultatai.txt";
        //rezultatų failo pavadinimas
        static void Main(string[] args)
        {
            KlientuMasyvas klientai = new KlientuMasyvas();
            //klientų duomenų masyvas
            KlientuMasyvas nuolaiduKlientai = new KlientuMasyvas();
            //atrinktų klientų duomenų masyvas
            
            //rezultatų failo išvalymas
            if (File.Exists(CFrezultatai))
                File.Delete(CFrezultatai);

            //veiksmai išsaugot duomenis / patikrinti logiką
            Skaityti(ref klientai, CFduomenys);

            if (klientai.ImtiKiek() <= 0)
            {
                using (var fr = File.AppendText(CFrezultatai))
                {
                    fr.WriteLine("Klientu duomenu faile nebuvo!");
                    Console.WriteLine("Klientu sarase nebuvo!");
                    Console.WriteLine("Programa baige darba!");
                    return;
                }
            }

            //veiksmai su įvesties kriterijais
            double isleistosSumosKriterijus, nuolaidosDydis;
            int kiekioKriterijus;

            
            Console.WriteLine("Iveskite maziausia isleista suma: ");
            isleistosSumosKriterijus = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Iveskite maziausia prekiu kieki: ");
            kiekioKriterijus = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Iveskite nuolaidos dydi: ");
            nuolaidosDydis = Convert.ToDouble(Console.ReadLine());
           
            
            //sukuriamas egzistuojančių prekių masyvas iš klientų duomenų
            PrekiuMasyvas prekes = SukurtiPrekiuMasyvas(klientai);

            //Spausdinami duomenis
            Spausdinti(klientai, CFrezultatai, 
                "Lojaliu klientu sarasas");
            SpausdintiPrekes(CFrezultatai, prekes,
                "\n\nPrekiu sarasas");


            //Spausdinami duomenis
            using (var fr = File.AppendText(CFrezultatai))
            {
                fr.WriteLine("\n\nVidutine virtualiu pinigu suma: {0} eur",
                    klientai.VidutineVirtualiuPiniguSuma());
                fr.WriteLine("Didziausia isleista suma: {0} eur",
                    prekes.DidziausiaIsleistaSuma());

                fr.WriteLine("\n\nNuolaida {0}% prieinama klientams kuriu" +
                             "\nMinimalios islaidos: {1} eur" +
                             "\nMinimalus kiekis: {2} vnt",
                    nuolaidosDydis, isleistosSumosKriterijus, kiekioKriterijus);
            }

            //Formuojamas ir rikiuojamas atrinktų klientų masyvas
            Formuoti(klientai, ref nuolaiduKlientai, prekes, isleistosSumosKriterijus,
                kiekioKriterijus, nuolaidosDydis);
            if (nuolaiduKlientai.ImtiKiek() > 0)
            {
                Spausdinti(nuolaiduKlientai, CFrezultatai,
                    "\n\nVidutine vieneto kaina RINKOS VIDURKIO su nuolaida",
                    true);

            }
            else
            {
                using (var fr = File.AppendText(CFrezultatai))
                {
                    fr.WriteLine("Klientu atitinkanciu kriterijus nera");
                }
            }

            nuolaiduKlientai.SurikiuotiNuolaiduKlientuSarasa();

            Spausdinti(nuolaiduKlientai, CFrezultatai,
                    "\n\nPerformuotas didejimo tvarka", true);


            Console.WriteLine("Programa baige darba!");

        }

        /// <summary>
        /// Skaito duomenis iš failo
        /// </summary>
        /// <param name="klientai">klientų objektų rinkinys</param>
        /// <param name="failoPavadinimas">failo pavadinimas</param>
        static void Skaityti(ref KlientuMasyvas klientai,
            string failoPavadinimas)
        {
            using (StreamReader srautas = new StreamReader(failoPavadinimas))
            {
                string kortelesNumeris, prekesPavadinimas;
                int nupirktasKiekis;
                double virtualusPinigai, isleistiPinigai;
                string[] eilutes = File.ReadAllLines(failoPavadinimas);
                foreach (string eilute in eilutes)
                {
                    string[] dalys = eilute.Split(';');
                    kortelesNumeris = dalys[0].Trim();
                    virtualusPinigai = double.Parse(dalys[1].Trim());
                    prekesPavadinimas = dalys[2].Trim();
                    nupirktasKiekis = int.Parse(dalys[3].Trim());
                    isleistiPinigai = double.Parse(dalys[4].Trim());

                    Klientas klientas = new Klientas(kortelesNumeris, virtualusPinigai,
                        prekesPavadinimas, nupirktasKiekis, isleistiPinigai);
                    klientai.PridetiKlientaMasyve(klientas);

                }
            }

        }
        
        /// <summary>
        /// Spausdina prekių lentelę faile
        /// </summary>
        /// <param name="failas">failo pavadinimas</param>
        /// <param name="prekes">prekių objektų rinkinys</param>
        /// <param name="antraste">antraštė</param>
        static void SpausdintiPrekes(string failas,
            PrekiuMasyvas prekes, string antraste)
        {

            string virsus = "-----------------------------------------\r\n" +
                            "Pavadinimas     Kiekis     Vnt Vid. Kaina\r\n" +
                            "-----------------------------------------";
            using (var fr = File.AppendText(failas))
            {
                fr.WriteLine(antraste);
                fr.WriteLine(virsus);
                for (int i = 0; i < prekes.ImtiKiek(); i++)
                    fr.WriteLine("{0}", prekes.ImtiPreke(i).ToString());
                fr.WriteLine("-----------------------------------------");
            }
        }
        /// <summary>
        /// Spausdina lojalių klientų sąrašą
        /// </summary>
        /// <param name="klientai">klientų objektų rinkinys</param>
        /// <param name="failoPavadinimas">failo pavadinimas</param>
        /// <param name="antraste">antraštė</param>
        /// <param name="spausdintiKaina">spausdina kainą/sumą</param>
        static void Spausdinti(KlientuMasyvas klientai,
            string failoPavadinimas,
            string antraste,
            bool spausdintiKaina = false)
        {
            string virsus = spausdintiKaina
                ? "------------------------------------------------------\r\n" +
                  "Korteles Nr.  Sukaupta   Preke     Kiekis   Kaina(eur)\r\n" +
                  "------------------------------------------------------"
                : "-----------------------------------------------------\r\n" +
                  "Korteles Nr.  Sukaupta   Preke     Kiekis   Suma(eur)\r\n" +
                  "-----------------------------------------------------";
            using (var fr = File.AppendText(failoPavadinimas))
            {
                fr.WriteLine(antraste);
                fr.WriteLine(virsus);
                for (int i = 0; i < klientai.ImtiKiek(); i++)
                    fr.WriteLine(spausdintiKaina 
                        ? klientai.ImtiKlienta(i).ToStringSuKaina()
                        : klientai.ImtiKlienta(i).ToString());
                fr.WriteLine("-----------------------------------------------------");
            }
        }

        /// <summary>
        /// Metodas sukuriantis prekių masyvo iš klientų
        /// objektų rinkinio duomenų
        /// </summary>
        /// <param name="klientai">klientų objektų rinkinys</param>
        /// <returns>sukuriamas prekių objektų rinkinys</returns>
        static PrekiuMasyvas SukurtiPrekiuMasyvas(KlientuMasyvas klientai)
        {
            PrekiuMasyvas prekes = new PrekiuMasyvas();

            for (int i = 0; i < klientai.ImtiKiek(); i++)
            {
                Klientas klientas1 = klientai.ImtiKlienta(i);


                prekes.PridetiArbaAtnaujinti(
                    klientas1.ImtiPerkamiausiaPreke(),
                        klientas1.ImtiNupirktaKieki(),
                        klientas1.ImtiIsleistusPinigus());

            }

            return prekes;
        }


        /// <summary>
        /// Suformuojamas naujas atrinktų klientų objektų rinkinys
        /// </summary>
        /// <param name="klientai">klientų objektų rinkinys</param>
        /// <param name="nuolaiduKlientai">atrinktų klientų
        /// objektų rinkinys</param>
        /// <param name="prekes">prekių objektų rinkinys</param>
        /// <param name="sumosKriterijus">sumos kriterijus</param>
        /// <param name="kiekioKriterijus">kiekio kriterijus</param>
        /// <param name="nuolaidosDydis">nuolaidos dydis</param>
        static void Formuoti(KlientuMasyvas klientai,
            ref KlientuMasyvas nuolaiduKlientai, PrekiuMasyvas prekes,
            double sumosKriterijus,
            int kiekioKriterijus, double nuolaidosDydis)
        {



            for (int i = 0; i < klientai.ImtiKiek(); i++)
            {
                Klientas klientas = klientai.ImtiKlienta(i);


                if (klientai.KlientasAtitinkaKriterijus(klientas,
                        sumosKriterijus, kiekioKriterijus))
                {
                    string perkamiausia = klientas.ImtiPerkamiausiaPreke();
                    double vidutineKaina =
                        prekes.VidutinePrekesKaina(perkamiausia);
                    double nuolaidineKaina =
                        Math.Round(vidutineKaina * ((100 - nuolaidosDydis) / 100), 2);
                    double naujaSuma =
                        nuolaidineKaina * klientas.ImtiNupirktaKieki();


                    Klientas naujasKlientas = new Klientas();
                    naujasKlientas.PridetiKlienta(
                        klientas.ImtiKortelesNumeri(),
                        klientas.ImtiPerkamiausiaPreke(),
                        klientas.ImtiVirtualiusPinigus(),
                        naujaSuma,
                        klientas.ImtiNupirktaKieki());
                    nuolaiduKlientai.PridetiKlientaMasyve(naujasKlientas);

                }
                else
                    ;
            }
        }

    }
}
