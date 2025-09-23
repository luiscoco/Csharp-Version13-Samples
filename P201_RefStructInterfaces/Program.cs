using System;
public interface IAddable { void Add(int x); int Sum { get; } }
public ref struct Accumulator : IAddable
{
    int _sum;
    public void Add(int x)=>_sum+=x;
    public int Sum=>_sum;
}
class Program
{
    static void Main()
    {
        var acc = new Accumulator(); acc.Add(10); acc.Add(5);
        Console.WriteLine(acc.Sum);
        // IAddable i = acc; // still illegal to convert
    }
}
