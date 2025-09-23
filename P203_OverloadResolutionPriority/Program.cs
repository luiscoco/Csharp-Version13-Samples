using System;
using System.Runtime.CompilerServices;
namespace System.Runtime.CompilerServices
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple=false)]
    internal sealed class OverloadResolutionPriorityAttribute : Attribute
    {
        public int Priority { get; }
        public OverloadResolutionPriorityAttribute(int priority)=>Priority=priority;
    }
}
class Demo
{
    public static void Print(object o)=>Console.WriteLine($"object: {o}");
    [OverloadResolutionPriority(1)]
    public static void Print(string s)=>Console.WriteLine($"string: {s}");
}
class Program{ static void Main()=>Demo.Print("hello"); }
