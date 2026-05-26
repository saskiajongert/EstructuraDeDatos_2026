
class AreaPoligonoRegular
{
    static Dictionary<string, int> poligonos = new Dictionary<string, int>()
    {
        {"Pentágono", 5},
        {"Hexágono", 6},
        {"Heptágono", 7},
        {"Octágono", 8},
        {"Eneágono", 9},
        {"Decágono", 10}
    };

    static List<string> poligonosNombres = new List<string>(poligonos.Keys); // lista con solo los nombres para poder hacer la selección

    static (int, int) SeleccionarPoligono()
    {
        Console.WriteLine("Para calcular el área, seleccione el polígono regular:");
        for (int i = 0; i < poligonosNombres.Count; i++) // hace la lista bonita
        {
            Console.WriteLine($"{i + 1}.- {poligonosNombres[i]}");
        }
        int seleccion;
        while (true) // inicia bucle de validación
        {
            Console.Write("El polígono es el de la opción... ");
            try
            {
                seleccion = int.Parse(Console.ReadLine()); // verifica si el usuario puso un número entero
                if (seleccion >= 1 && seleccion <= poligonosNombres.Count) // verifica si es un número del 1 al 6, si sí es, sale del bucle
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Elija un número del 1 al {poligonosNombres.Count}\n"); // si no está en el rango pide otro número
                }
            }
            catch
            {
                Console.WriteLine("Ingrese un número válido.\n"); // si lo que puso el usuario no es número entero, le pide otro
            }
        }
        Console.WriteLine($"\n¡Muy bien! Calculemos el área del {poligonosNombres[seleccion - 1]}.\n");
        int numLados = poligonos[poligonosNombres[seleccion - 1]]; // ve qué key del diccionario coindice con la selección y de ahí ve el número de lados
        return (seleccion, numLados);
    }

    static (double lado, double apotema) PedirDatos()
    {
        Console.WriteLine("A continuación, ingrese las medidas. No incluya unidades de longitud.");
        double lado;
        double apotema;

        while (true)
        {
            Console.Write("Medida del lado: ");
            string stringLado = Console.ReadLine();
            Console.Write("Medida de la apotema: ");
            string stringApotema = Console.ReadLine();
            bool ladoValido = double.TryParse(stringLado, out lado);
            bool apotemaValido = double.TryParse(stringApotema, out apotema);
            if (ladoValido && apotemaValido && lado > 0 && apotema > 0)
            {
                break;
            }
            else
            {
                Console.WriteLine("Uno de los valores no es válido. Por favor intente de nuevo.\n");
            }
        }
        return (lado, apotema);
    }

    static double CalcularArea(int numLados, double lado, double apotema)
    {
        double perimetro = lado * numLados;
        double area = (perimetro * apotema) / 2; //fórmula para calcular el área de un polígono regular
        return area;
    }

    static void Main()
    {
        var (seleccion, numLados) = SeleccionarPoligono();
        var (lado, apotema) = PedirDatos();
        double area = CalcularArea(numLados, lado, apotema);
        Console.WriteLine($"\nEl área del {poligonosNombres[seleccion - 1]} es de {area} unidades cuadradas.");
    }
}