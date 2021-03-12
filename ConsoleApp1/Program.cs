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

			Console.WriteLine(lista.Count);
		}
	}
}
