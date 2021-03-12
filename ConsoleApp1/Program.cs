using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1
{
	class Program
	{
		class Adat
		{
			public DateTime idő;
			public int id; // string -- megfontolandó, mivel nem fogjuk kihasználni soha azt a tulajdonságát, hogy szám. Akkor kell figyelni erre, amikor olyan azonosítók vannak, hogy "001".
			public string irany; // lehetett volna bool.
		}

		static void Main(string[] args)
		{
			List<Adat> lista = new List<Adat>();

			using (StreamReader f = new StreamReader("ajto.txt", Encoding.Default))
			{
				while (!f.EndOfStream)
				{
					Adat r = new Adat();
					string[] sortömb = f.ReadLine().Split(' ');
					r.idő = new DateTime(1,1,1,int.Parse(sortömb[0]),int.Parse(sortömb[1]),1);
					r.id = int.Parse(sortömb[2]);
					r.irany = sortömb[3];
					lista.Add(r);
				}
			}

			// Console.WriteLine(lista.Count);

			// 1. feladat: "Időrendben rögzítették", tehát biztosra vehető, hogy növekvő sorrendben vannak az adatok.

			// lista.First() = lista[0]; "9 órakor a társalgó üres volt ", tehát az első adat belépő kellett legyen! 
			// lista.Last() = lista[lista.Count-1]; // ez nem működött volna

			Console.WriteLine($"2.feladat\nAz első belépő {lista.First().id} \nAz utolsó belépő {lista.Where(x => x.irany=="ki").Last().id}");


			// 3. feladat
			// ezt a múltkor szótárral csináltuk, de most az id egy szám, így nincs rá nagy szükség
			int[] kimutatás = new int[100]; // ez egy 100 elemű számtömb, egyelőre minden tagja 0.


			int i;
			foreach (Adat adat in lista)
			{
				i = adat.id;
				kimutatás[i-1]++;    // egy sorban is lehetett volna: kimutatás[adat.id]++;
			}

			using (StreamWriter w = new StreamWriter("athaladas.txt"))
			{
				for (int j = 0; j < 100; j++)
				{
					if (kimutatás[j]!=0)
					{
						w.WriteLine($"{j + 1} {kimutatás[j]}");
					}
				}
			}

			// 4.feladat
		}
	}
}
