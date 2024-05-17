namespace PartThree;

public class Node(int value, Node? next)
{
    public int Value { get; set; } = value;
    public Node? Next { get; set; } = next;

    public Node(int value) : this(value, null)
    {
    }
}