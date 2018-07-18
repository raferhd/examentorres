using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenTorres2
{
    class Program
    {
        static void Main(string[] args)
        {
            City c = new City("SD");

            foreach (Flight f in c.GetArrivals())
            {
                Console.Write(f.Status);
                Console.WriteLine("date: " + f.Date + " arrivalTime:" + f.ArrivalTime + " arrivalCity:" + f.ArrivalCity, " airline:", f.Airline + " status:" + f.Status.ToString());
            }
            Console.WriteLine();
            foreach (Flight f in c.GetDepartures())
            {
                Console.Write(f.Id + " ");
                Console.WriteLine(f.Date + " -" + f.ArrivalTime + " -" + f.DepartureCity.Name, " -", f.Airline + " -" + f.Status);
            }



            Console.Read();
        }
    }
}
