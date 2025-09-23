using System;
class Demo
{
    public static void Log(string s) => Console.WriteLine(s);
    public static void Log<T>(T value) where T : unmanaged { }
    static void Main()
    {
        var del = Log; // Action<string>
        del("Hello from C# 13");
        Console.WriteLine(del.GetType().Name);
    }
}
