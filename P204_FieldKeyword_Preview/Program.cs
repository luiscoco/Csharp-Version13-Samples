using System;
public class Counter
{
    private int _mult = 1;
    public int Value
    {
        get => field;
        set => field = value * _mult;
    }
    public int Multiplier { get => _mult; set => _mult = value; }
}
class Program
{
    static void Main()
    {
        var c=new Counter(); c.Multiplier=3; c.Value=10; Console.WriteLine(c.Value);
    }
}
