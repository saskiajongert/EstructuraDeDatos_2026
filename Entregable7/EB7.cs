// Sumatoria Recursiva Dinámica

class Program
{
    static int SumarHasta(int n)
    {
        // CASO BASE: La suma de 1 número es 1
        if (n == 1)
        return 1;
        // CASO RECURSIVO: n más la suma de todo lo anterior
        return n + SumarHasta(n - 1);
    }

    static void Main(string[] args)
    {
        Console.Write("Introduce un número positivo: ");
        string entrada = Console.ReadLine();
        
        if (int.TryParse(entrada, out int numero) && numero > 0)
        {
            int resultado = SumarHasta(numero);
            Console.WriteLine(
            $"La suma de 1 hasta {numero} es: {resultado}");
        }

        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(
            "Error: Solo se aceptan enteros positivos.");
            Console.ResetColor();
        }
    }
}