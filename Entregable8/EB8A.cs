class Program
{
    static int FactorialInt(int n)
    {
        if (n == 0 || n == 1)
        return 1;
        return n * FactorialInt(n - 1);
    }

    static int FactorialIterativo(int n)
    {
        int resultado = 1;
        for (int i = 2; i <= n; i++)
        resultado *= i;
        return resultado;
    }

    static void Main(string[] args)
    {
        for (int i = 1; i <= 20; i++)
        {
            Console.WriteLine($"n={i:D2} | Recursivo: {FactorialInt(i),25} | Iterativo: {FactorialIterativo(i),25}");
        }
    }
}

// Documentación Del Error: Los valores comienzan a ser incorrectos a partir del número 13. 
// La respuesta correcta de 13! es 6,227,020,800. El programa arroja 1,932,053,504.