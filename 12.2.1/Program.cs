namespace Assignment12_2_1;

internal class Program
{
    static int Main(string[] args)
    {
        Console.WriteLine("Assignment 12.2.1 - Remove Linked List Elements (#203)");

        if (args.Length == 2)
            return RunInput(args[0], args[1]);

        if (args.Length > 0 && !(args.Length == 1 && args[0] == "--examples"))
        {
            Console.Error.WriteLine("Usage: 12.2.1 [\"1,2,6,3,4,5,6\" 6] or --examples");
            return 1;
        }

        ShowResult([1, 2, 6, 3, 4, 5, 6], 6);
        ShowResult([], 1);
        ShowResult([7, 7, 7, 7], 7);

        if (args.Length == 1) return 0;

        Console.Write("\nEnter list values separated by commas (blank for an empty list): ");
        string? input = Console.ReadLine();
        if (input is null) return 0;

        Console.Write("Enter the value to remove: ");
        string? value = Console.ReadLine();
        return value is null ? 0 : RunInput(input, value);
    }

    static int RunInput(string input, string value)
    {
        if (!TryParseValues(input, out int[] values) || !int.TryParse(value, out int val))
        {
            Console.Error.WriteLine("Please enter a comma-separated list of integers and an integer to remove.");
            return 1;
        }

        ShowResult(values, val);
        return 0;
    }

    static bool TryParseValues(string input, out int[] values)
    {
        values = [];
        input = input.Trim();
        if (input.StartsWith('[') && input.EndsWith(']'))
            input = input[1..^1].Trim();

        if (input.Length == 0) return true;

        string[] parts = input.Split(',');
        int[] parsed = new int[parts.Length];
        for (int i = 0; i < parts.Length; i++)
        {
            if (!int.TryParse(parts[i], out parsed[i])) return false;
        }

        values = parsed;
        return true;
    }

    // The dummy node makes removing the first node work like removing any other node.
    public static ListNode? RemoveElements(ListNode? head, int val)
    {
        ListNode dummy = new(0, head);
        ListNode current = dummy;

        while (current.Next is not null)
        {
            if (current.Next.Val == val)
            {
                current.Next = current.Next.Next;
                // Stay here: the next node might also need to be removed.
            }
            else
            {
                current = current.Next;
            }
        }

        return dummy.Next;
    }

    public static ListNode? BuildList(IEnumerable<int> values)
    {
        ListNode dummy = new();
        ListNode tail = dummy;
        foreach (int value in values)
        {
            tail.Next = new ListNode(value);
            tail = tail.Next;
        }
        return dummy.Next;
    }

    static string FormatList(ListNode? head)
    {
        List<int> values = [];
        for (ListNode? node = head; node is not null; node = node.Next)
            values.Add(node.Val);
        return $"[{string.Join(",", values)}]";
    }

    static void ShowResult(int[] values, int val)
    {
        ListNode? head = BuildList(values);
        Console.WriteLine($"\nInput: head = {FormatList(head)}, val = {val}");
        head = RemoveElements(head, val);
        Console.WriteLine($"Output: {FormatList(head)}");
    }
}

public class ListNode
{
    public int Val { get; set; }
    public ListNode? Next { get; set; }

    public ListNode(int val = 0, ListNode? next = null)
    {
        Val = val;
        Next = next;
    }
}
