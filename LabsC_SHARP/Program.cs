using System;

namespace LabsC_SHARP {
    class Program {

        static void ex1() {
            int a = int.Parse(Console.ReadLine()), b = int.Parse(Console.ReadLine()), c = int.Parse(Console.ReadLine());
            Console.WriteLine(a + "+" + b + "+" + c + "=" + (a + b + c));
        }
        static void ex2() {
            int r = int.Parse(Console.ReadLine());
            Console.WriteLine((2.0f * r * Math.PI) + " " + (r * r * Math.PI));
        }

        public class Company {
            string name, ip, num, web;
            Menedjer mm;
            public Company (string name, string ip, string num, string web, Menedjer mm) {
                this.name = name;
                this.ip = ip;
                this.num = num;
                this.web = web;
                this.mm = mm;
            }

            public string toString () {
                return name + " " + ip + " " + num + " " + web + " " + mm.ToString(); 
            }

        }
        public class Menedjer {
            string name, surname, age;
            public Menedjer (string name, string surname, string age) {
                this.name = name;
                this.surname = surname;
                this.age = age;
            }
        }

        static void ex3() {
            Company comp = new Company(Console.ReadLine(), Console.ReadLine(), Console.ReadLine(), Console.ReadLine(), new Menedjer(Console.ReadLine(), Console.ReadLine(), Console.ReadLine()));
            Console.Write(comp.toString());
        }

        static void ex4() {
            int cnt = 0, a = int.Parse(Console.ReadLine()), b = int.Parse(Console.ReadLine());
            for (int i = a; i <= b; i++) {
                if (i % 5 == 0) {
                    cnt++;
                }
            }
            Console.WriteLine(cnt);
        }

        static void ex5() {
            int a = int.Parse(Console.ReadLine()), b = int.Parse(Console.ReadLine());
            Console.WriteLine(a > b ? a : b);
        }

        static void ex6() {
            int a = int.Parse(Console.ReadLine()), b = int.Parse(Console.ReadLine()), c = int.Parse(Console.ReadLine());
            double d = b * b - 4 * a * c;
            if (d < 0) {
                Console.WriteLine("No colution");
            } else {
                Console.WriteLine(((-b + Math.Sqrt(d)) / (2 * a)) + " " + (-b - Math.Sqrt(d)) / (2 * a));
            }
        }

        static void ex7() {
            int n = int.Parse(Console.ReadLine()), sum = 0;
            for (int i = 0; i < n; i++) {
                int a = int.Parse(Console.ReadLine());
                sum += a;
            }
            Console.WriteLine(sum);
        }

        static void ex8() {
            int n = int.Parse(Console.ReadLine());
            for (int i = 1;  i <= n; i++) {
                Console.Write(i + " ");
            }
        }

        static void ex9() {
            Decimal a = 0, b = 1;
            Console.Write(a + " " + b + " ");
            for (int i = 0; i < 100; i++) {
                Decimal sum = a + b;
                Console.Write(sum + " ");
                a = b;
                b = sum;
            }
        }

        static void ex10() {
            double sum = 0;
            for (int i = 1; i <= 1000; i++) {
                sum = sum + (i % 2 == 1 ? 1 : -1) * 1.0f / i;
            }
            Console.WriteLine(sum);
        }


        static void Main(string[] args) {
            ex10();
        }
    }
}
