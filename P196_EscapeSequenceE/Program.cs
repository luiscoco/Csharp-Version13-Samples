using System;
class Program
{
    static void Main()
    {
        char esc = '\e'; // ESC (U+001B)
        Console.WriteLine($"Hello{esc}[31m Red {esc}[0m");
    }
}
