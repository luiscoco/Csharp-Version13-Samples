using System;
class Holder { public int[] Buffer { get; set; } = new int[5]; }
class Program
{
    static void Main()
    {
        var h = new Holder
        {
            Buffer =
            {
                [^1] = 9,
                [^2] = 8,
                [^3] = 7
            }
        };
        Console.WriteLine(string.Join(",", h.Buffer));
    }
}
