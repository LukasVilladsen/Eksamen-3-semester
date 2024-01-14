// See https://aka.ms/new-console-template for more information
Console.WriteLine(Opgave3.Faculty(5)); //ouutput skal være 120
Console.WriteLine(Opgave41.Euclid(6, 5));
Console.WriteLine(Opgave42.Potens(5, 2));
Console.WriteLine(Opgave43.Multiplikation(2, 2));
Console.WriteLine(Opgave44.Reverse("EGAKNANAB"));
class Opgave3
{
    public static int Faculty(int n)
    {
        int resultat;
        if (n == 1)
        {
            resultat = 1;
        } else
        {
            resultat = n * Faculty(n - 1);
        }
        return resultat;
    }
}

class Opgave41
{
    public static int Euclid(int a, int b)
    {
        int resultat;
        if (b == 0)
        {
            resultat = a;
        }
        else
        {
            resultat = Euclid(b, a % b);
        }

        return resultat;
    }
}

class Opgave42
{
    public static int Potens(int n, int p)
    {
        int resultat;
        if (p == 0)
        {
            resultat = 1;
        } else
        {
            resultat = n * Potens(n, p - 1);
        }
        return resultat;
    }
}

class Opgave43
{
    public static int Multiplikation(int a, int b)
    {
        int resultat;
        if (a == 1)
        {
            resultat = b;
        } else if (a == 0)
        {
            resultat = 0;
        } else 
        {
            resultat = Multiplikation(a - 1, b) + b;
        }
        return resultat;
    }

}

class Opgave44
{
    public static String Reverse(string s)
    {
        string resultat;
        if (string.IsNullOrEmpty(s))
        {
            resultat = "";
        }
        else
        {
            char firstChar = s[0];
            String rest = s.Substring(1);
            resultat = Reverse(rest) + firstChar;
        }
        return resultat;
    }
}


