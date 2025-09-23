using System;
using System.Threading.Tasks;
class Program
{
    static async Task<int> SumAsync()
    {
        ReadOnlySpan<int> span = stackalloc[] { 1, 2, 3 };
        int s = 0; for (int i=0;i<span.Length;i++) s += span[i];
        await Task.Yield();
        return s;
    }
    static void Main() => Console.WriteLine(SumAsync().GetAwaiter().GetResult());
}
