using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;


namespace lab4_ClassRJD_ {

    internal class Program {


        /*
         * добавить работы с json или xml файлы
         * 
         */
        static void addInXml(Ticket ticket) {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("E:\\Projects\\C#\\LabsC_SHARP\\lab4(ClassRJD)\\tickets.xml");
            XmlElement root = xmlDoc.DocumentElement; 
            XmlElement tick = xmlDoc.CreateElement("ticket");
            XmlElement name = xmlDoc.CreateElement("name");
            XmlElement numer = xmlDoc.CreateElement("numerOfFlight");
            XmlElement space = xmlDoc.CreateElement("space");
            XmlText nameText = xmlDoc.CreateTextNode(ticket.Name);
            XmlText numerText = xmlDoc.CreateTextNode(ticket.Numer.ToString());
            XmlText spaceText = xmlDoc.CreateTextNode(ticket.Space.ToString());
            name.AppendChild(nameText);
            numer.AppendChild(numerText);
            space.AppendChild(spaceText);
            tick.AppendChild(name);
            tick.AppendChild(numer);
            tick.AppendChild(space);
            root.AppendChild(tick);
            xmlDoc.Save("E:\\Projects\\C#\\LabsC_SHARP\\lab4(ClassRJD)\\tickets.xml");
        }

        public static List<rainFlight> initFlights() {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("E:\\Projects\\C#\\LabsC_SHARP\\lab4(ClassRJD)\\rainFlights.xml");
            List<rainFlight> flights = new List<rainFlight>();
            foreach (XmlNode i in xmlDoc.DocumentElement.SelectNodes("flight")) {
                List<string> curArr = new List<string>();
                foreach (XmlNode j in i.ChildNodes) {
                    curArr.Add(j.InnerText);
                }
                string time = curArr[0];
                string start = curArr[1];
                string final = curArr[2];
                flights.Add(new rainFlight(start, final, (int.Parse(time.Substring(0, 2)), int.Parse(time.Substring(3, 2)))));
            }
            return flights;
        }

        static void Main(string[] args) {
            List <rainFlight> flights = initFlights(); 
            List <Ticket> tickets = new List<Ticket>();
            bool flag = true;
            while(flag) { 
                Console.WriteLine(
                    "0) output information about flight\n" +
                    "1)book name ticket\n" +
                    "2)book standart ticket\n" +
                    "3)exit"
                    );
                int x = int.Parse(Console.ReadLine());
                switch (x){
                    case 0:
                        foreach (var now in flights) {
                            Console.WriteLine(now.getInfo());
                        }
                        break;
                    case 1: {
                            Console.WriteLine("Choose the flight number");
                            int n = int.Parse(Console.ReadLine()) - 1;
                            Console.WriteLine("Input your name:");
                            string name = Console.ReadLine();
                            tickets.Add(new Ticket(name, flights[n]));
                            addInXml(tickets.Last());
                            break;
                        }
                    case 2: {
                            Console.WriteLine("Choose the flight number");
                            int n = int.Parse(Console.ReadLine()) - 1;
                            tickets.Add(new Ticket(flights[n]));
                            addInXml(tickets.Last());
                            break;
                        }
                    case 3:
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Incorrect input");
                        break;
                }
            }
        }
    }
}
