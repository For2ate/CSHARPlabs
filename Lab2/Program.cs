using System;
using System.Linq;


namespace Lab2 {

    class Program {

        static void ex1() {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            for (int i = 0; i < n; i++) {
                arr[i] = int.Parse(Console.ReadLine());
            }
            for (int i = 0; i < arr.Length; i++) {
                if (i % 2 == 0) {
                    Console.Write(arr[i] + " ");
                }
            }
        }

        static void ex2() {
            double[] a = Console.ReadLine().Split(' ').Select(x => double.Parse(x)).ToArray();
            int min = 0, max = 0;
            for (int i = 0; i < a.Length; i++) {
                if (a[i] < a[min]) {
                    min = i;
                }
                if (a[i] >= a[max]) {
                    max = i;
                }
            }
            (a[min], a[max]) = (a[max], a[min]);
            for (int i = 0; i < a.Length; i++) {
                Console.Write(a[i] + " ");
            }
        }

        static void ex3() {
            Random random = new Random();
            int n = int.Parse(Console.ReadLine()), m = int.Parse(Console.ReadLine());
            int[,] a = new int[n, m];
            for (int i = 0; i < n; i++) {
                for (int j = 0; j < m; j++) {
                    a[i, j] = random.Next(-20, 20);
                }
            }
            Console.WriteLine("MATRIX:");
            for (int i = 0; i < n; i++) {
                for (int j = 0; j < m; j++) {
                    Console.Write(a[i, j] + " ");
                }
                Console.WriteLine();
            }
            int r = 0;
            for (int j = 0; j < m; j++) {
                int mx = int.MinValue;
                for (int i = 0; i < n; i++) {
                    mx = Math.Max(mx, a[i, j]);
                }
                r += mx;
            }
            Console.Write("NORMA " + r);
        }

        static void Main(string[] args) {
            ex3();
        }
    }
}
