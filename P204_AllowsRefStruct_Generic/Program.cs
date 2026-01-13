using System;
using System.Runtime.CompilerServices;

public class Processor<T> where T : allows ref struct
{
    public static int Length(scoped T x)
    {
        // get a by-ref view of the scoped parameter (without copying/boxing)
        ref T rx = ref Unsafe.AsRef(in x);

        if (typeof(T) == typeof(ReadOnlySpan<int>))
        {
            ReadOnlySpan<int> ro = Unsafe.As<T, ReadOnlySpan<int>>(ref rx);
            return ro.Length;
        }

        if (typeof(T) == typeof(Span<int>))
        {
            Span<int> s = Unsafe.As<T, Span<int>>(ref rx);
            return s.Length;
        }

        return 0;
    }
}

class Program
{
    static void Main()
    {
        ReadOnlySpan<int> ro = stackalloc[] { 1, 2, 3 };
        Console.WriteLine(Processor<ReadOnlySpan<int>>.Length(ro));

        Span<int> s = stackalloc int[4];
        Console.WriteLine(Processor<Span<int>>.Length(s));
    }
}
