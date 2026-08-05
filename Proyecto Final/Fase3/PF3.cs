class Program
{
    static void Main(String[] args)
    {
        // Instanciar la estructura dinámica
        TablaDinamica dataCore = new TablaDinamica();

        // Paso 1: Insertar 15 registros dinámicos
        for (int i = 1; i <= 15; i++) {
            RegistroDatos reg = new RegistroDatos(i, $"Transacción-{i}", (double)(i * 100.0m));
            dataCore.InsertarFinal(reg);
            Console.WriteLine($"[INSERT] Registro {i} añadido a la cadena.");
        }

        // Paso 2: Eliminar 2 registros específicos
        Console.WriteLine("\n--- Eliminando registros con Id 5 y Id 11 ---");
        dataCore.EliminarPorId(5);
        dataCore.EliminarPorId(11);
        Console.WriteLine("Cadena reestructurada exitosamente. Sin NullReferenceException.");

        // Paso 3: Convertir a arreglo y ordenar con QuickSort (Fase 2)
        RegistroDatos[] arreglo = dataCore.ObtenerComoArreglo();
        Console.WriteLine($"\nRegistros en arreglo: {arreglo.Length} (esperado: 13)");
        QuickSort(arreglo, 0, arreglo.Length - 1); // Motor de Fase 2
        Console.WriteLine("\n--- Arreglo ordenado por Id (QuickSort) ---");
        foreach (var r in arreglo)
        Console.WriteLine($" Id: {r.Id} | Nombre: {r.HashValidacion} | Monto: {r.PesoBytes:C}");
    }

    public class TablaDinamica
    {
        private NodoRegistro? cabeza;
        private int contadorRegistros;
        public TablaDinamica()
        {
        cabeza = null;
        contadorRegistros = 0;
        }

        public void InsertarInicio(RegistroDatos nuevoRegistro)
        {
            NodoRegistro nuevoNodo = new NodoRegistro(nuevoRegistro);
            // El nuevo nodo apunta a quien
            // era la cabeza anterior
            nuevoNodo.Siguiente = cabeza;
            // El nuevo nodo ES la nueva cabeza
            cabeza = nuevoNodo;
            contadorRegistros++;
        }

        public void InsertarFinal(RegistroDatos nuevoRegistro)
        {
            NodoRegistro nuevoNodo = new NodoRegistro(nuevoRegistro);
            if (cabeza == null) {
                cabeza = nuevoNodo;
            } 
            else {
                NodoRegistro actual = cabeza;
                // Recorre hasta el último nodo
                while (actual.Siguiente != null)
                actual = actual.Siguiente;
                // Enlaza el nuevo al final
                actual.Siguiente = nuevoNodo;
            }
            contadorRegistros++;
        }

        public void EliminarPorId(int idTarget)
        {
            if (cabeza == null) 
            return;
            // Caso especial: eliminar la cabeza
            if (cabeza.Dato.Id == idTarget) {
                cabeza = cabeza.Siguiente;
                contadorRegistros--;
                return;
            }
            NodoRegistro anterior = cabeza;
            NodoRegistro? actual = cabeza.Siguiente;
            while (actual != null) {
                if (actual.Dato.Id == idTarget) {
                    // Reconecta saltando el nodo
                    anterior.Siguiente =
                    actual.Siguiente;
                    contadorRegistros--;
                    return;
                }
                anterior = actual;
                actual = actual.Siguiente;
            }
        }

        public RegistroDatos[] ObtenerComoArreglo()
        {
            RegistroDatos[] resultado = new RegistroDatos[contadorRegistros];
            NodoRegistro? actual = cabeza;
            int i = 0;
            while (actual != null) {
                resultado[i] = actual.Dato;
                actual = actual.Siguiente;
                i++;
            }
            return resultado;
        }

        public class NodoRegistro
        {
            // El dato que este nodo almacena
            public RegistroDatos Dato { get; set; }
            
            // Referencia al siguiente nodo
            // null si es el último eslabón
            public NodoRegistro? Siguiente { get; set; }

            // Constructor: inicializa el dato
            // Siguiente queda en null por defecto
            public NodoRegistro(RegistroDatos dato)
            {
                Dato = dato;
                Siguiente = null;
            }
        }
    }

    public static void QuickSort(RegistroDatos[] arr, int bajo, int alto)
    {
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