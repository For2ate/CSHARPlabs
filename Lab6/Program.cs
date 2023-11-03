using System;
using System.Collections.Generic;
using System.IO;

namespace GeneticsProject {
    public struct GeneticData {
        public string name; //protein name
        public string organism;
        public string formula; //formula
    }

    class Program {
        static List<GeneticData> data = new List<GeneticData>();
        static int count = 1;
        static string GetFormula(string proteinName) {
            foreach (GeneticData item in data) {
                if (item.name.Equals(proteinName)) {
                    return item.formula;
                }
            }
            return null;
        }
        static void ReadGeneticData(string filename) {
            try {
                StreamReader reader = new StreamReader(filename);
                while (!reader.EndOfStream) {
                    string line = reader.ReadLine();
                    string[] fragments = line.Split('\t');
                    GeneticData protein;
                    protein.name = fragments[0];
                    protein.organism = fragments[1];
                    protein.formula = fragments[2];
                    data.Add(protein);
                    count++;
                }
                reader.Close();
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
        static bool IsValid(string formula) {
            List<char> letters = new List<char>() { 'A', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'K', 'L', 'M', 'N', 'P', 'Q', 'R', 'S', 'T', 'V', 'W', 'Y' };
            foreach (char ch in formula) {
                if (!letters.Contains(ch)) return false;
            }
            return true;
        }
        static string Encoding(string formula) {
            string encoded = String.Empty;
            for (int i = 0; i < formula.Length; i++) {
                char ch = formula[i];
                int count = 1;
                while (i < formula.Length - 1 && formula[i + 1] == ch) {
                    count++;
                    i++;
                }
                if (count > 2) {
                    encoded = encoded + count + ch;
                }
                if (count == 1) {
                    encoded = encoded + ch;
                }
                if (count == 2) {
                    encoded = encoded + ch + ch;
                }
            }
            return encoded;
        }
        static string Decoding(string formula) {
            string decoded = String.Empty;
            for (int i = 0; i < formula.Length; i++) {
                if (char.IsDigit(formula[i])) {
                    char letter = formula[i + 1];
                    int conversion = formula[i] - '0';
                    for (int j = 0; j < conversion - 1; j++) decoded = decoded + letter;
                } else decoded = decoded + formula[i];
            }
            return decoded;
        }
        static int Search(string amino_acid) {
            string decoded = Decoding(amino_acid);
            for (int i = 0; i < data.Count; i++) {
                if (Decoding(data[i].formula).Contains(decoded)) {
                    return i;
                }
            }
            return -1;
        }
        static int Diff(string protein1, string protein2) {
            int counter = 0;
            string formula1 = Decoding(GetFormula(protein1)), formula2 = Decoding(GetFormula(protein2));
            if (formula1 == null || formula2 == null) {
                return 0;
            }
            int i = 0;
            while (i < formula1.Length && i < formula2.Length) {
                if (formula1[i] != formula2[i]) {
                    counter++;
                }
                i++;
            }
            return counter + Math.Abs(formula1.Length - formula2.Length);
        }
        static (char, int) Mode(string protein) {
            (char, int) result = ('a', 0);
            string formula = Decoding(GetFormula(protein));
            int[] cnt = new int[35];
            int posesMax = 0;
            foreach (char c in formula) {
                cnt[c - 'A']++;
                if (cnt[c - 'A'] >= cnt[posesMax]) {
                    if (cnt[c - 'A'] == cnt[posesMax] && posesMax < c - 'A') ;
                    else {
                        posesMax = c - 'A';
                    }
                }
            }
            result = ((char)(posesMax + 'A'), cnt[posesMax]);
            return result;
        }
        static void ReadHandleCommands(string filename) {
            try {
                StreamReader reader = new StreamReader(filename);
                StreamWriter writer = new StreamWriter("E:\\Projects\\C#\\LabsC_SHARP\\Lab6\\output.txt");
                int counter = 0;
                while (!reader.EndOfStream) {
                    string line = reader.ReadLine(); counter++;
                    string[] command = line.Split('\t');
                    if (command[0].Equals("search")) {
                        writer.WriteLine($"{counter.ToString("D3")}   {"search"}   {Decoding(command[1])}");
                        int index = Search(command[1]);
                        if (index != -1) {
                            writer.WriteLine($"{data[index].organism}    {data[index].name}");
                        } else {
                            writer.WriteLine("NOT FOUND");
                        }
                    }
                    if (command[0].Equals("diff")) {
                        writer.WriteLine($"{counter.ToString("D3")}   {"diff"}   {command[1]}   {command[2]}\namino-acids difference: {Diff(command[1], command[2])}");
                    }
                    if (command[0].Equals("mode")) {
                        (char, int) res = Mode(command[1]);
                        writer.WriteLine($"{counter.ToString("D3")}   {"mode"}   {Decoding(command[1])}\n{res.Item1}\t\t{res.Item2}");
                    }
                    writer.WriteLine("================================================");
                }
                reader.Close();
                writer.Close();
            } catch (IOException ex) {
                Console.WriteLine(ex.Message);
            }
        }

        static void Main(string[] args) {
            ReadGeneticData("E:\\Projects\\C#\\LabsC_SHARP\\Lab6\\data.txt");
            ReadHandleCommands("E:\\Projects\\C#\\LabsC_SHARP\\Lab6\\comands.txt");
        }
    }
}
