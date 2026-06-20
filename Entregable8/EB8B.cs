using System.Numerics;
class Program
{
    static BigInteger FactorialProfesional(BigInteger n)
    {
        // Caso Base
        if (n == 0 || n == 1)
        return BigInteger.One;
        // Caso Recursivo
        return n * FactorialProfesional(n - 1);
    }

    static void Main(string[] args)
    {
        // En Main — prueba con n = 100
        BigInteger resultado = FactorialProfesional(100);
        Console.WriteLine($"100! = {resultado}");    
    }
    
}