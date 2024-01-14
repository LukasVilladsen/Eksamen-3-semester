namespace LinkedList
{
    class Node
    {
        public Node(User data, Node next)
        {
            this.Data = data;
            this.Next = next;
        }
        public User Data;
        public Node Next;
    }

    class UserLinkedList
    {
        private Node first = null!;

        public void AddFirst(User user)
        {
            Node node = new Node(user, first);
            first = node;
        }
        public bool Contains(User user)
        {
            Node node = first;

            while (node != null)
            {
                if (node.Data.Equals(user))
                {
                    return true; // Brugeren er fundet i listen
                }

                node = node.Next;
            }

            return false; // Brugeren blev ikke fundet i listen
        }

        public User RemoveFirst()
        {
            if (first == null)
            {
                // Listen er tom, returner null eller kast en exception, afhængigt af kravene.
                return null!;
            }

            User removedUser = first.Data;
            first = first.Next;

            return removedUser;
        }

        public void RemoveUser(User user)
        {
            Node node = first;
            Node previous = null!;
            bool found = false;

            while (!found && node != null)
            {
                if (node.Data.Name == user.Name)
                {
                    found = true;
                    if (node == first)
                    {
                        RemoveFirst();
                    }
                    else
                    {
                        previous.Next = node.Next;
                    }
                }
                else
                {
                    previous = node;
                    node = node.Next;
                }
            }
        }

        public User GetFirst()
        {
            return first.Data;
        }

        public User GetLast()
        {
            if (first == null)
            {
                return null!;
            }

            Node lastNode = first;
            while (lastNode.Next != null)
            {
                lastNode = lastNode.Next;
            }

            return lastNode.Data;
        }

        public int CountUsers()
        {
            int count = 0;
            Node node = first;

            while (node != null)
            {
                count++;
                node = node.Next;
            }

            return count;
        }

        public override String ToString()
        {
            Node node = first;
            String result = "";
            while (node != null)
            {
                result += node.Data.Name + ", ";
                node = node.Next;
            }
            return result.Trim();
        }
    }
}