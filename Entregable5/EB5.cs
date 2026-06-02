class ArbolesBinarios
{
    public class Nodo
    {
        // Identificador único para ordenar el árbol
        public int ID { get; set; }

        // Información que almacena el nodo
        public string Dato { get; set; } = string.Empty;

        // Referencias recursivas a los hijos
        // Son nullable (?) porque un nodo hoja
        // no tiene hijos 4 apuntan a null
        public Nodo? HijoIzquierdo { get; set; }
        public Nodo? HijoDerecho { get; set; }

        // Constructor para crear nodos fácilmente
        public Nodo(int id, string dato)
        {
            ID = id;
            Dato = dato;
        }
    }

    public static Nodo InsertarNodo(Nodo? raiz,Nodo nuevoNodo)
    {
        // CASO BASE: posición vacía encontrada
        // Colocamos el nuevo nodo aquí
        if (raiz == null)
            return nuevoNodo;

        // CASO RECURSIVO: decidir la dirección
        if (nuevoNodo.ID < raiz.ID)
        {
            // El nuevo nodo es menor ³ va a la izquierda
            // Llamada recursiva con el subárbol izquierdo
            raiz.HijoIzquierdo = InsertarNodo(
            raiz.HijoIzquierdo,
            nuevoNodo);
        }

        else if (nuevoNodo.ID > raiz.ID)
        {
            // El nuevo nodo es mayor ³ va a la derecha
            raiz.HijoDerecho = InsertarNodo(
            raiz.HijoDerecho,
            nuevoNodo);
        }
        
        // Si ID == raiz.ID, el nodo ya existe (ignorar)
        return raiz; // Devolvemos la raíz actualizada
    }

    public static string? BuscarNodo(Nodo? raiz, int idTarget)
    {
        // CASO BASE 1: posición vacía
        // El nodo no existe en el árbol
        if (raiz == null)
            return null;

        // CASO BASE 2: ¡encontrado!
        // El ID coincide con lo que buscamos
        if (idTarget == raiz.ID)
            return raiz.Dato;

        // CASO RECURSIVO: decidir la dirección
        if (idTarget < raiz.ID)
        {
            // El target es menor ³ busca a la izquierda
            // DESCARTAMOS todo el subárbol derecho 7
            return BuscarNodo(raiz.HijoIzquierdo, idTarget);
        }

        else
        {
            // El target es mayor ³ busca a la derecha
            // DESCARTAMOS todo el subárbol izquierdo 7
            return BuscarNodo(raiz.HijoDerecho, idTarget);
        }
    }
    
    static void Main(string[] args)
    {
        // Ejemplo de uso en Program.cs:
        var raiz = new Nodo(5, "Raíz");
        raiz = InsertarNodo(raiz, new Nodo(3, "Izquierda"));
        raiz = InsertarNodo(raiz, new Nodo(7, "Derecha"));
        string? resultado = BuscarNodo(raiz, 3);
        Console.WriteLine(resultado ?? "No encontrado");
    }


}