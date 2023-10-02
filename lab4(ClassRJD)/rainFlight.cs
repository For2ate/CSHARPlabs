using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace lab4_ClassRJD_ {
    internal class rainFlight {
        private static int cnt = 0;
        private int numer;
        private TrainCar train;
        private string finalSity;
        private string startSity;
        private (int, int) time;
        public int Numer { get { return this.numer; } }
        public rainFlight() : this("", "", (0,0)) {
        }
        public rainFlight(string finalSity, string startSity, (int,int) time) {
            this.numer = ++cnt;
            this.finalSity = finalSity; 
            this.startSity = startSity;
            this.time = time;
            this.train = new TrainCar();
        }

        public int bookTicket() {
            int[] arr = train.getFreeSpace();
            Console.WriteLine("The free space in train are: ");
            foreach (var i in arr) {
                Console.Write(i + " ");
            }
            Console.WriteLine("Choise the space in train.");
            int x;
            do {
                x = int.Parse(Console.ReadLine());
                if (arr.Count(i => i == x) == 0) {
                    Console.WriteLine("Incorect input u should choise the free space in train");
                } else {
                    train.setSpace(x - 1);
                    break;
                }
            } while (true);
            return x;
        }

        public string getInfo() {
            return string.Format("{2})route from city {0} to city {1}\n", startSity, finalSity,numer) + string.Format("time of the flight: {0}{1}:{2}{3}", time.Item1 / 10, time.Item1 % 10, time.Item2 / 10, time.Item2 % 2);
        }

    }
}
