namespace PartThree;

class LinkedList(Node? head)
{
    public void Append(int value)
    {
        if (head == null) head = new Node(value);
        else
        {
            Node? temp = head;
            while (temp.Next != null)
            {
                temp = temp.Next;
            }

            temp.Next = new Node(value);
        }
    }

    public void Prepend(int value)
    {
        head = new Node(value, head);
    }

    public int Pop()
    {
        Node? temp = head;
        while (temp.Next != null)
        {
            temp = temp.Next;
        }

        int value = temp.Next.Value;
        temp.Next = null;
        return value;
    }

    public int Unqueue()
    {
        if (head == null)
            throw new NullReferenceException("Head is null");

        int value = head.Value;
        head = head.Next;
        return value;
    }

    public IEnumerable<int> ToList()
    {
        Node? temp = head;
        while (temp != null)
        {
            yield return temp.Value;
            temp = temp.Next;
        }
    }

    public bool IsCircular()
    {
        if (head?.Next == null)
        {
            return false;
        }

        Node temp = head.Next;
        while (temp != null)
        {
            if (temp == head) return true;
            temp = temp.Next;
        }

        return false;
    }

    public void Sort()
    {
        if (head == null) return;

        Node temp = head;

        while (temp.Next != null)
        {
            Node temp2 = temp.Next;

            while (temp2 != null)
            {
                if (temp.Value > temp2.Value)
                {
                    (temp.Value, temp2.Value) = (temp2.Value, temp.Value);
                }

                temp2 = temp2.Next;
            }

            temp = temp.Next;
        }
    }

    public Node GetMaxNode()
    {
        Node temp = head;
        Node maxNode = temp;

        while (temp != null)
        {
            if (temp.Value > maxNode.Value)
            {
                maxNode = temp;
            }

            temp = temp.Next;
        }

        return maxNode;
    }

    public Node GetMinNode()
    {
        Node temp = head;
        Node minNode = temp;

        while (temp != null)
        {
            if (temp.Value < minNode.Value)
            {
                minNode = temp;
            }

            temp = temp.Next;
        }

        return minNode;
    }
}