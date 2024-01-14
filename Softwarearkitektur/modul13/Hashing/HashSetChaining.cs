using System;

public class HashSetChaining : HashSet
{
    private Node[] buckets;
    private int currentSize;
    private const double LoadFactorThreshold = 0.75;

    private class Node
    {
        public Node(Object data, Node next)
        {
            this.Data = data;
            this.Next = next;
        }
        public Object Data { get; set; }
        public Node Next { get; set; }
    }

    public HashSetChaining(int size)
    {
        buckets = new Node[size];
        currentSize = 0;
    }

    public bool Contains(Object x)
    {
        int h = HashValue(x);
        Node bucket = buckets[h];
        bool found = false;
        while (!found && bucket != null)
        {
            if (bucket.Data.Equals(x))
            {
                found = true;
            }
            else
            {
                bucket = bucket.Next;
            }
        }
        return found;
    }

    public bool Add(Object x)
    {
        int h = HashValue(x);

        Node bucket = buckets[h];
        bool found = false;
        while (!found && bucket != null)
        {
            if (bucket.Data.Equals(x))
            {
                found = true;
            }
            else
            {
                bucket = bucket.Next;
            }
        }

        if (!found)
        {
            Node newNode = new Node(x, buckets[h]);
            buckets[h] = newNode;
            currentSize++;

            // Check for rehashing
            if ((double)currentSize / buckets.Length > LoadFactorThreshold)
            {
                Rehash();
            }
        }

        return !found;
    }

    public bool Remove(Object x)
    {
        int h = HashValue(x);

        Node current = buckets[h];
        Node previous = null;

        while (current != null)
        {
            if (current.Data.Equals(x))
            {
                // Elementet blev fundet, fjern det fra listen
                if (previous == null)
                {
                    // Elementet er i starten af listen
                    buckets[h] = current.Next;
                }
                else
                {
                    // Elementet er et sted i midten eller slutningen af listen
                    previous.Next = current.Next;
                }

                currentSize--;
                return true;
            }

            previous = current;
            current = current.Next;
        }

        // Elementet blev ikke fundet
        return false;
    }

    private int HashValue(Object x)
    {
        int h = x.GetHashCode();
        if (h < 0)
        {
            h = -h;
        }
        h = h % buckets.Length;
        return h;
    }

    private void Rehash()
    {
        int newSize = buckets.Length * 2;
        Node[] newBuckets = new Node[newSize];

        foreach (Node bucket in buckets)
        {
            Node current = bucket;
            while (current != null)
            {
                int newHash = HashValue(current.Data) % newSize;
                Node newNode = new Node(current.Data, newBuckets[newHash]);
                newBuckets[newHash] = newNode;
                current = current.Next;
            }
        }

        buckets = newBuckets;
    }

    public int Size()
    {
        return currentSize;
    }

    public override String ToString()
    {
        Node node = buckets[0];
        String result = "";
        while (node != null)
        {
            result += node.Data + ", ";
            node = node.Next;
        }
        return result.Trim();
    }
}
