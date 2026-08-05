using System;
using System.Diagnostics;

class Program
{
    static long contadorLlamadas = 0;
    static long contadorComparaciones = 0;
    static long contadorIntercambios = 0;

    static void OrdenarPorSeleccion(RegistroDatos[] arr)
    {
        int comparaciones = 0;
        int intercambios = 0;
        for (int i = 0; i < arr.Length - 1; i++)
        {
            int indiceMinimo = i;
            for (int j = i + 1; j < arr.Length; j++)
            {
                contadorComparaciones++;
                if (arr[j].Id < arr[indiceMinimo].Id)
                indiceMinimo = j;
            }
            if (indiceMinimo != i)
            {
                (arr[i], arr[indiceMinimo]) = (arr[indiceMinimo], arr[i]); // Tupla moderna C#
                contadorIntercambios++;
            }
        }
    }

    public static void QuickSort(RegistroDatos[] arr, int bajo, int alto)
    {
        contadorLlamadas++; // Instrumentación del Call Stack
        if (bajo < alto) // Caso base: solo procede si hay más de un elemento
        {
            int indicePivote = Particionar(arr, bajo, alto);
            // Llamada recursiva para la sublista IZQUIERDA (menores al pivote)
            QuickSort(arr, bajo, indicePivote - 1);
            // Llamada recursiva para la sublista DERECHA (mayores al pivote)
            QuickSort(arr, indicePivote + 1, alto);
        }
    }

    private static int Particionar(RegistroDatos[] arr, int bajo, int alto)
    {
        RegistroDatos pivote = arr[alto]; // Pivote = último elemento
        int i = bajo - 1; // Puntero del elemento menor
        for (int j = bajo; j < alto; j++)
        {
            // Si el elemento actual es menor o igual al pivote (comparando por Id)
            if (arr[j].Id <= pivote.Id)
            {
                i++;
                // Intercambio: arr[i] <-> arr[j]
                RegistroDatos temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }
        // Coloca el pivote en su posición correcta de equilibrio
        RegistroDatos temp2 = arr[i + 1];
        arr[i + 1] = arr[alto];
        arr[alto] = temp2;
        return i + 1; // Devuelve el índice final del pivote
    }

    static void Main(string[] args)
    {
        int tamaño = 10_000;
        RegistroDatos[] arregloOriginal = GenerarArregloAleatorio(tamaño);

        // Clonar para condiciones idénticas
        RegistroDatos[] copiaSeleccion = (RegistroDatos[])arregloOriginal.Clone();
        RegistroDatos[] copiaQuickSort = (RegistroDatos[])arregloOriginal.Clone();

        // --- BENCHMARK 1: Selección (Fase 1) ---
        contadorComparaciones = 0; 
        contadorIntercambios = 0;
        Stopwatch swSeleccion = Stopwatch.StartNew();
        OrdenarPorSeleccion(copiaSeleccion);
        swSeleccion.Stop();
        long msSeleccion = swSeleccion.ElapsedMilliseconds;
        long opSeleccion = contadorComparaciones + contadorIntercambios;

        // --- BENCHMARK 2: QuickSort (Fase 2) ---
        contadorLlamadas = 0;
        Stopwatch swQuickSort = Stopwatch.StartNew();
        QuickSort(copiaQuickSort, 0, copiaQuickSort.Length - 1);
        swQuickSort.Stop();
        long msQuickSort = swQuickSort.ElapsedMilliseconds;

        // --- REPORTE COMPARATIVO ---
        Console.WriteLine("============================================================");
        Console.WriteLine($"===== REPORTE COMPARATIVO DE ORDENAMIENTO (n = {tamaño:N0}) =====");
        Console.WriteLine("============================================================");

        Console.WriteLine("Algoritmo : Selección Directa");
        Console.WriteLine($"Registros procesados : {tamaño:N0}");
        Console.WriteLine($"Comparaciones : {contadorComparaciones:N0}");
        Console.WriteLine($"Intercambios : {contadorIntercambios:N0}");
        Console.WriteLine($"Tiempo de ejecución : {msSeleccion:N0} ms");

        Console.WriteLine("------------------------------------------------------------");

        Console.WriteLine("Algoritmo : QuickSort");
        Console.WriteLine($"Registros procesados : {tamaño:N0}");
        Console.WriteLine($"Llamadas recursivas QS : {contadorLlamadas:N0}");
        Console.WriteLine($"Tiempo de ejecución : {msQuickSort:N0} ms");

        Console.WriteLine("------------------------------------------------------------");

        double ratio = (double)msSeleccion / Math.Max(msQuickSort, 1);
        Console.WriteLine($"Ratio de velocidad : QuickSort fue {ratio:N0}x más rápido");

        Console.WriteLine("============================================================");
        Console.WriteLine("============================================================");
    }

    static RegistroDatos[] GenerarArregloAleatorio(int cantidad)
    {
        Random rnd = new Random(42); // Semilla fija para reproducibilidad
        RegistroDatos[] arreglo = new RegistroDatos[cantidad];
        for (int i = 0; i < cantidad; i++)
        {
            arreglo[i] = new RegistroDatos
            {
                Id = rnd.Next(1, 100_001), // Id: 1 a 100000
                HashValidacion = Guid.NewGuid().ToString(), // Hash como GUID string
                PesoBytes = 1.0 + rnd.NextDouble() * 9999 // Peso: 1.0 a 10000.0
            };
        }
        return arreglo;
    }
}

/// Modelo de datos para el experimento de benchmarking.
/// Implementado como struct (tipo valor) para maximizar la localidad de caché en arreglos densos y eliminar overhead del GC.
/// INVARIANTE: No modificar entre Fase 1 y Fase 2.
public struct RegistroDatos
{
    public int Id;
    public string HashValidacion;
    public double PesoBytes;

    /// Constructor con validación de dominio.
    /// Garantiza que ningún registro inválido ingrese al arreglo de prueba.
    /// Las excepciones son fail-fast: detectan errores en tiempo de construcción en lugar de propagar datos corruptos silenciosamente.

    public RegistroDatos(int id, string hashValidacion, double pesoBytes)
    {
        // Validar Id: debe ser positivo (no cero, no negativo)
        if (id <= 0)
        throw new ArgumentException(
        "El Id debe ser un entero positivo mayor que cero.", nameof(id));
        // Validar HashValidacion: no null, no vacío
        if (string.IsNullOrEmpty(hashValidacion))
        throw new ArgumentNullException(
        nameof(hashValidacion),
        "HashValidacion no puede ser null ni una cadena vacía.");
        // Validar PesoBytes: debe ser positivo
        if (pesoBytes <= 0.0)
        throw new ArgumentOutOfRangeException(
        nameof(pesoBytes),
        "PesoBytes debe ser un valor numérico positivo mayor que cero.");
        Id = id;
        HashValidacion = hashValidacion;
        PesoBytes = pesoBytes;
    }

    /// Representación de cadena para depuración y logging.
    /// No usar en rutas de código críticas de rendimiento.
    public override string ToString() =>
    $"[Id={Id}, Hash={HashValidacion[..8]}..., Peso={PesoBytes:F2}B]";
}