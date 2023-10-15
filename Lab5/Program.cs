using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Lab5 {
    internal class Program {

        static int gameOver = -1;
        static void init(ref List <(int, string)> steps) {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load("E:\\Projects\\C#\\LabsC_SHARP\\Lab5\\Input.xml");
            int n = int.Parse(xmlDocument.DocumentElement.SelectNodes("n")[0].InnerText);
            Player.size = n;
            foreach (XmlNode i in xmlDocument.DocumentElement.ChildNodes) {
                steps.Add((int.Parse(i.InnerText), i.Name));
            }
        }

        static void ReopenFile() {
            try {
                StreamWriter sw = new StreamWriter("E:\\Projects\\C#\\LabsC_SHARP\\Lab5\\Output.txt", false);
                sw.WriteLine("Cat and Mouse\r\n\r\nCat\t\tMouse    Distance\r\n--------------------------");
                sw.Close();
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }

        static void FillOutput(Player cat, Player mouse) {
            try {
                StreamWriter sw = new StreamWriter("E:\\Projects\\C#\\LabsC_SHARP\\Lab5\\Output.txt", true);
                string Out = "";
                if (cat.XPoses == -1) {
                    Out += "       ";
                } else {
                    Out += string.Format("{0:   ####}", cat.XPoses);
                }
                if (mouse.XPoses == -1) {
                    Out += "       ";
                } else {
                    Out += string.Format("{0:   ####}", mouse.XPoses);
                }
                if (mouse.XPoses == -1 || cat.XPoses == -1) {
                    Out += "       ";
                } else {
                    Out += string.Format("{0:   ####}", Player.getDistance(cat, mouse));
                }
                sw.WriteLine(Out);
                sw.Close();
            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }
        
        static void printLastFileString(Player cat, Player mouse) {
            try {
                StreamReader sw = new StreamReader("E:\\Projects\\C#\\LabsC_SHARP\\Lab5\\Output.txt");
                string Out, last = "";
                do {
                    Out = sw.ReadLine();
                    if (Out != null) last = Out;
                } while (Out != null);
                Console.WriteLine(last);
                Console.WriteLine(string.Format("--------------------------\nDistanse traveled: Cat       Mouse\r\n\t\t     {0}\t\t{1}", cat.AllDistance, mouse.AllDistance));
                if (gameOver == -1) {
                    Console.WriteLine("\nMouse evaded Cat");
                } else {
                    Console.WriteLine(String.Format("Mouse caught at:{0}\n\n", gameOver));
                }
                sw.Close();
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }

        static void PrintFile(Player cat, Player mouse) {
            try {
                StreamReader sw = new StreamReader("E:\\Projects\\C#\\LabsC_SHARP\\Lab5\\Output.txt");
                string Out;
                do {
                    Out = sw.ReadLine();
                    Console.WriteLine(Out);
                } while (Out != null);
                Console.WriteLine(string.Format("--------------------------\nDistanse traveled: Cat       Mouse\r\n\t\t     {0}\t\t{1}", cat.AllDistance, mouse.AllDistance));
                if (gameOver == -1) {
                    Console.WriteLine("\nMouse evaded Cat");
                } else {
                    Console.WriteLine(String.Format("Mouse caught at:{0}\n\n", gameOver));
                }
                sw.Close();
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }

        static void Main(string[] args) {
            ReopenFile();
            Player Cat = new Player(-1), Mouse = new Player(-1);
            List<(int,string)> steps = new List<(int, string)>(); 
            init(ref steps);
            foreach(var i in steps) {
                if (i.Item2 == "c") {
                    Cat.changePosition(i.Item1 + (Cat.XPoses == -1 ? 1 : 0));
                }
                if (i.Item2 == "m") { 
                    Mouse.changePosition(i.Item1 + (Mouse.XPoses == -1 ? 1 : 0));
                }
                if (i.Item2 == "p") {
                    printLastFileString(Cat, Mouse);
                    FillOutput(Cat, Mouse);
                }
                if (Player.getDistance(Cat, Mouse) == 0) {
                    gameOver = Cat.XPoses;
                }
            }
            try {
                StreamWriter sw = new StreamWriter("E:\\Projects\\C#\\LabsC_SHARP\\Lab5\\Output.txt", true);
                string Out = string.Format("--------------------------\nDistanse traveled: Cat       Mouse\r\n\t\t\t\t     {0}\t\t{1}", Cat.AllDistance, Mouse.AllDistance);
                if (gameOver == -1) {
                    Out += ("\nMouse evaded Cat");
                } else {
                    Out += (String.Format("Mouse caught at:{0}\n\n", gameOver));
                }
                sw.WriteLine(Out); 
                sw.Close(); 
            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}
