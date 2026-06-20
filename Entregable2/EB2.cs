class ValorRef
{
   static void CambiarValor(int x)
   {
    x = 100;
   }

   static void CambiarReferencia(int[] arr)
   {
    arr[0] = 100;
   }

   static void Main(string[] args)
    {
        int num = 90;
        int[] listita = {120, 90, 80, 70, 60};
        Console.WriteLine($"VALORES INICIALES\nNúmero = {num}\nLista = [" + string.Join(", ", listita) + "]\n");
        CambiarValor(num);
        CambiarReferencia(listita);
        Console.WriteLine($"VALORES DESPUÉS DEL CAMBIO\nNúmero = {num}\nLista = [" + string.Join(", ", listita) + "]\n");
        Console.WriteLine("¿El número no cambió? Lo sé.\nEl número pasa por valor. La lista pasa por referencia.");
    }
}