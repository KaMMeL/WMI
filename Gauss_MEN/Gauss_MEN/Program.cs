using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gauss_MEN
{
    class Program
    {
        private static double[,] macierz;
        private static int ileRownan;
        

        static void PodajIloscRownan()
        {
            Console.WriteLine("Podaj ilość równań:");
            ileRownan = Convert.ToInt32(Console.ReadLine());
            macierz = new double[ileRownan,ileRownan+1];
        }

        static void PodajRownania()
        {
            Console.WriteLine("Podaj wspolczynniki równań:");
            string wiersz;
            int indeks = ileRownan-1;
          
            for(int j=0; j<ileRownan; j++)
            {
                wiersz = Console.ReadLine();
                String[] tablica = wiersz.Split(' ');

                for (int i = 0; i < ileRownan + 1; i++)
                {
                    macierz[j, i] = Convert.ToDouble(tablica[i]);
                }
            }
        }

        static void PokazMacierz()
        {
            for (int j = 0; j < ileRownan; j++)
            {
                for (int i = 0; i < ileRownan + 1; i++)
                {
                   Console.Write( macierz[j, i] );
                }
                Console.WriteLine();
            }
        }

        static void GaussMacierz(int _wierszStartowy, int _kolumnaStartowa )

        {
            for (int j = _wierszStartowy+1; j < ileRownan; j++) // czy ile rónań ?
            {
                double wspolczynnik = 0;
                wspolczynnik = macierz[j, _kolumnaStartowa]/macierz[_wierszStartowy, _kolumnaStartowa];
            
                for (int i = _kolumnaStartowa; i < ileRownan + 1; i++)
                {
                    if (i == _kolumnaStartowa) { macierz[j, i] = 0; }
                
                    else {macierz[j, i] = macierz[j, i] - (macierz[_wierszStartowy, i]*wspolczynnik);}
                }
            }
        }

        static void EliminacjaGaussa()
        {
            for (int z = 0; z < ileRownan - 1; z++) // czy -2 czy -1 ? :D
            {
                GaussMacierz(z,z);
            }
         }

        static void Testuj()
        {
            Console.WriteLine("Podaj ilość równań:");
            ileRownan = 3;
            macierz = new double[ileRownan, ileRownan + 1];

            Console.WriteLine("Podaj wspolczynniki równań:");
            string wiersz;
            int indeks = ileRownan - 1;

            String[] tab = new string[3];

            tab[0] = "3 6 9 3";
            tab[1] = "-1 4 3 5";
            tab[2] = "1 4 8 3";
            

            for (int j = 0; j < ileRownan; j++)
            {
                wiersz = tab[j];
                String[] tablica = wiersz.Split(' ');

                for (int i = 0; i < ileRownan + 1; i++)
                {
                    macierz[j, i] = Convert.ToDouble(tablica[i]);
                }
            }

        }

        static void WyliczPierwiastki()
        {
            double[] rozwiazania = new double[ileRownan];
            int wiersz = ileRownan-1;
            List<double> lista = new List<double>();

            for (int i = 0; i < ileRownan; i++)
                rozwiazania[i] = 1;

            while (wiersz > -1) // przez wszystkie wiersze
            {
                double danaNiewiadoma = macierz[wiersz, wiersz];

                for (int i = wiersz+1; i < ileRownan; i++)
                    lista.Add(macierz[wiersz,i]*rozwiazania[i]);
        
                double suma = lista.Sum();
                rozwiazania[wiersz] = (macierz[wiersz, ileRownan] - suma) / danaNiewiadoma;
                lista.Clear();
                wiersz--;
            }

            for(int i=0; i<ileRownan; i++)
                Console.WriteLine("X"+(i+1)+" = "+rozwiazania[i]);

            
        }

        static void Main(string[] args)
        {
          // PodajIloscRownan();
          // PodajRownania();
           Testuj();
            EliminacjaGaussa();
          Console.WriteLine();
           // PokazMacierz();
            WyliczPierwiastki();
          Console.ReadKey();
        }
    }
}
