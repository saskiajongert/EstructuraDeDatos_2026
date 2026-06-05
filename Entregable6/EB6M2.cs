class Program
{
    static int CalcularYValidar(int dividendo, int divisor, out int residuo)
    {
        residuo = dividendo % divisor;
        return dividendo / divisor;
    }

    static void Main()
    {
        int cociente = CalcularYValidar(
        17, 5, out int resto);
        Console.WriteLine($"Cociente: {cociente}");
        Console.WriteLine($"Residuo: {resto}");
        // Cociente: 3
        // Residuo: 2
    }
}