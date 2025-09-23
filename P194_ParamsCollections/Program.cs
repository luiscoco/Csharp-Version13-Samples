using System;
using System.Collections.Generic;

class Program
{
    static int Sum(params ReadOnlySpan<int> values)
    {
        int s = 0;
        for (int i = 0; i < values.Length; i++) s += values[i];
        return s;
    }

    static void Print(params IEnumerable<string> words)
    {
        foreach (var w in words) Console.Write($"{w} ");
        Console.WriteLine();
    }

    static void Main()
    {
        Console.WriteLine(Sum([1,2,3]));
        int[] a = [4,5];
        Console.WriteLine(Sum([..a, 6]));

        Print(["hello", "world"]);
        List<string> list = ["C#", "13"];
        Print([..list, "params", "collections"]);
    }
}
