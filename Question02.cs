using System;

class LL1Parser
{
    private string[] input;
    private int index;

    public LL1Parser(string[] input)
    {
        this.input = input;
        this.index = 0;
    }

    public void ParseList()
    {
        ParseItem();
        ParseRest();
        if (index == input.Length) // Check if we have reached the end of the input.
            Console.WriteLine("Parsing completed successfully.");
        else
            Console.WriteLine("Parsing failed.");
    }

    private void ParseRest()
    {
        if (index < input.Length && input[index] == ",")
        {
            Match(",");
            ParseItem();
            ParseRest();
        }
        // For Rest -> ε (empty)
    }

    private void ParseItem()
    {
        if (index < input.Length && (input[index] == "id" || input[index] == "num" || input[index] == "string"))
        {
            index++;
        }
        else
        {
            Console.WriteLine("Parsing failed.");
        }
    }

    private void Match(string expectedToken)
    {
        if (index < input.Length && input[index] == expectedToken)
        {
            index++;
        }
        else
        {
            Console.WriteLine("Parsing failed.");
        }
    }

    public static void Main(string[] args)
    {
        string[] input = { "id", ",", "num", ",", "string" };
        LL1Parser parser = new LL1Parser(input);
        parser.ParseList();
    }
}
