using Hashing;

public class HashSetLinearProbing : HashSet {
    private Object[] buckets;
    private int currentSize;
    private enum State { DELETED }

    public HashSetLinearProbing(int bucketsLength) {
        buckets = new Object[bucketsLength];
        currentSize = 0;
    }

    public bool Contains(Object x)
    {
        int h = HashValue(x);
        int initialIndex = h;

        do
        {
            Object current = buckets[h];
            if (current == null)
                return false; // Elementet er ikke i sættet

            if (current.Equals(x))
                return true; // Elementet blev fundet

            h = (h + 1) % buckets.Length; // Forsøg det næste indeks
        } while (h != initialIndex); // Fortsæt, indtil vi vender tilbage til startpunktet

        return false; // Elementet blev ikke fundet
    }

    public bool Add(Object x)
    {
        int h = HashValue(x);
        int initialIndex = h;

        do
        {
            Object current = buckets[h];
            if (current == null || current.Equals(State.DELETED))
            {
                buckets[h] = x;
                currentSize++;
                return true; // Elementet blev tilføjet
            }

            if (current.Equals(x))
                return false; // Elementet er allerede i sættet

            h = (h + 1) % buckets.Length; // Forsøg det næste indeks
        } while (h != initialIndex); // Fortsæt, indtil vi vender tilbage til startpunktet

        // Ingen plads til tilføjelse
        return false;
    }

    public bool Remove(Object x)
    {
        int h = HashValue(x);
        int initialIndex = h;

        do
        {
            Object current = buckets[h];
            if (current == null)
                return false; // Elementet er ikke i sættet

            if (current.Equals(x))
            {
                buckets[h] = State.DELETED;
                currentSize--;
                return true; // Elementet blev fjernet
            }

            h = (h + 1) % buckets.Length; // Forsøg det næste indeks
        } while (h != initialIndex); // Fortsæt, indtil vi vender tilbage til startpunktet

        return false; // Elementet blev ikke fundet
    }

    public int Size() {
        return currentSize;
    }

    private int HashValue(Object x) {
        int h = x.GetHashCode();
        if (h < 0) {
            h = -h;
        }
        h = h % buckets.Length;
        return h;
    }

    public override String ToString() {
        String result = "";
        for (int i = 0; i < buckets.Length; i++) {
            int value = buckets[i] != null && !buckets[i].Equals(State.DELETED) ? 
                    HashValue(buckets[i]) : -1;
            result += i + "\t" + buckets[i] + "(h:" + value + ")\n";
        }
        return result;
    }

}
