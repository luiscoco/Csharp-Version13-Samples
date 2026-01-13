using System;
using System.Threading;

class Program
{
    static readonly Lock gate = new();
    static int counter;

    static void Main()
    {
        lock (gate) { counter++; Console.WriteLine($"counter={counter}"); }
        using (gate.EnterScope()) { counter++; Console.WriteLine($"counter={counter} (via EnterScope)"); }
    }
}
