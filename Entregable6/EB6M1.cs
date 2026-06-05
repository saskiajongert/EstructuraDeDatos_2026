class Program
{
    static void Intercambiar(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }
    static void Main()
    {
        int x = 10, y = 25;
        Console.WriteLine($"Antes: x={x}, y={y}");
        Intercambiar(ref x, ref y);
        Console.WriteLine($"Después: x={x}, y={y}");
        // Antes: x=10, y=25
        // Después: x=25, y=10
    }
}