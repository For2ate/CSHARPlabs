using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;

internal class String {
    private StringBuilder line;
    private int n;

    public StringBuilder Line { get;  set; }
    public int N { get; }
    public char this[int ind] {
        get { return line[ind]; } 
        set { line[ind] = value; }
    }
    public String() : this("") { }
    public String(string s) { this.line = new StringBuilder(s); this.n = this.line.Length; }
    public String(int n) {
        string temp = "";
        for (int i = 0; i < n; i++) {
            char v = (char)((new Random()).Next(0, 26) + 'a');
            temp += v;
        }
        this.line = new StringBuilder(temp);
        this.n = n;
    }
    public int CounterSpaces() {
        int result = 0;
        for (int i = 0; i < n; i++) {
            if (line[i] == ' ') {
                result++;
            }
        }
        return result;
    }
    public static String Change(String a) {
        string temp = a.Line.ToString().ToLower();
        return new String(temp);
    }

    public String Delete(String cur) {
        string temp = "";
        for (int i = 0; i < cur.N; i++) {
            if (cur.Line[i] != '!' && cur.Line[i] != '.' && cur.Line[i] != ',' && cur.Line[i] != '?')
            temp += cur.Line[i];
        }
        return new String(temp); 
    }

    public static bool operator true(String a) {
        if (a.N > 0) {
            return true;
        } else {
            return false;
        }
    }
    public static bool operator false(String a) {
        if (a.N != 0) {
            return false;
        } else {
            return true;
        }
    }

    public static bool operator &(String a, String b) {
        if (String.Change(a) == String.Change(b)) {
            return true;
        }  else {
            return false;
        }
    }
    public string ToString() {
        return Line.ToString();
    }

}

internal class Program {
    private static void Main(string[] args) {
    }
}