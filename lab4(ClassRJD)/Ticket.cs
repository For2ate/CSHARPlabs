using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace lab4_ClassRJD_ {
    internal class Ticket {

        private string name;
        private rainFlight route;
        private int setSpace;
        public string Name { get { return name; } }
        public int Numer { get { return this.route.Numer; } }
        public int Space { get { return setSpace; } }
        public Ticket() : this(null) { }
        public  Ticket(rainFlight route) : this("", route) {}
        public Ticket(string name, rainFlight route) {
            this.name = name; 
            this.route = route;
            this.setSpace = this.route.bookTicket();
        }
        
        public string getInfo() {
            return this.route.getInfo() + string.Format("\nyour space is {0}", this.setSpace);
        }

    }
}
