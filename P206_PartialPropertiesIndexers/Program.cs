using System;
public partial class Demo
{
    public partial string Name { get; set; }
    public partial int this[int i] { get; set; }
}
public partial class Demo
{
    private string _name = "";
    private int[] _arr = new int[3];
    public partial string Name { get => _name; set => _name = value.ToUpperInvariant(); }
    public partial int this[int i] { get => _arr[i]; set => _arr[i] = value * 2; }
}
class Program
{
    static void Main()
    {
        var d = new Demo { Name = "mads" };
        d[0] = 5;
        Console.WriteLine($"{d.Name} {d[0]}");
    }
}
