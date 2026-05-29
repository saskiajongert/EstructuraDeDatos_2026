class RecursividadFunciones
{
    static long CalcularFactorial(int n)
    {
        if (n < 0)
            throw new ArgumentException("No existe factorial de negativos.");
        
        if (n == 0 || n == 1)
            return 1;
        
        return n * CalcularFactorial(n - 1);
    }

    static long GenerarFibonacci(int n)
    {
        if (n < 0)
            throw new ArgumentException("n debe ser un entero positivo.");

        if (n == 0) 
            return 0;
        
        if (n == 1) 
            return 1;
        
        return GenerarFibonacci(n - 1) + GenerarFibonacci(n - 2);
    }

    static void Main(string[] args)
    {
        Console.WriteLine("=== Algoritmos Recursivos ===\n");

        // --- Factorial ---
        Console.Write("Ingrese un número para calcular su factorial: ");
            if (int.TryParse(Console.ReadLine(), out int numFactorial))
            {
                try
                {
                    long resultado = CalcularFactorial(numFactorial);
                    Console.WriteLine($"{numFactorial}! = {resultado}");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

        // --- Fibonacci ---
        Console.Write("\nIngrese la posición de Fibonacci (n): ");
        if (int.TryParse(Console.ReadLine(), out int numFib))
        {
            try
            {
                long fib = GenerarFibonacci(numFib);
                Console.WriteLine($"Fibonacci({numFib}) = {fib}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
