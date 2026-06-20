using System.Linq;

public class Producto
{
    public int ID { get; set; }
    public string Nombre { get; set; }
    public double Precio { get; set; }
    public int Cantidad { get; set; }
    // Constructor opcional para facilitar la creación
    public Producto(int id, string nombre,
    double precio, int cantidad)
    {
        ID = id;
        Nombre = nombre;
        Precio = precio;
        Cantidad = cantidad;
    }
    // Override para mostrar info en consola
    public override string ToString()
    {
        return $"[{ID}] {Nombre} - " +
        $"${Precio:F2} | Stock: {Cantidad}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Sintaxis 1: Inicializador de colección (forma más compacta y legible)
        List<Producto> inventario = new List<Producto>
         {
            new Producto(1, "Laptop Lenovo", 15999.00, 10),
            new Producto(2, "Mouse Inalámbrico", 349.00, 25),
            new Producto(3, "Teclado Mecánico", 899.00, 0),
            new Producto(4, "Monitor 24\"", 4500.00, 5),
            new Producto(5, "Audífonos Sony", 1200.00, 0)
        };

        // Sintaxis 2: Agregar elementos después de crear la lista
        inventario.Add(new Producto(6, "Webcam HD", 750.00, 12));

        // Sintaxis 3: Con var (inferencia de tipo) en C# moderno
        var otroProducto = new Producto(7, "Hub USB-C", 450.00, 8);
        inventario.Add(otroProducto);

        // Ver cuántos productos hay
        Console.WriteLine($"Total en inventario: {inventario.Count} productos\n");

        // Productos ordenados de mayor a menor precio
        var porPrecio = inventario.OrderByDescending(p => p.Precio).ToList();
        Console.WriteLine("=== Productos por Precio ===");
        foreach (var p in porPrecio)
        {
            Console.WriteLine(p); // usa ToString()
        }
        Console.WriteLine();

        // Solo productos con Cantidad == 0
        var agotados = inventario.Where(p => p.Cantidad == 0).ToList();
        Console.WriteLine("=== Productos Agotados ===");
        if (agotados.Count == 0)
        {
            Console.WriteLine("Sin productos agotados.");
        }
        else
        {
            agotados.ForEach(p => Console.WriteLine(p));
        }
        Console.WriteLine();

        // Construir el diccionario desde la lista existente
        Dictionary<int, Producto> catalogo = inventario.ToDictionary(p => p.ID, p => p);

        // Llamada a la función de búsqueda rápida
        BuscarPorID(catalogo);
    }

    // Función de búsqueda rápida por ID
    static void BuscarPorID(Dictionary<int, Producto> catalogo)
    {
        Console.Write("Ingresa el ID del producto a buscar: ");
        if (int.TryParse(Console.ReadLine(), out int idBuscado))
        {
            if (catalogo.TryGetValue(idBuscado, out Producto encontrado))
            {
                Console.WriteLine($"\nProducto encontrado: {encontrado}");
            }
            else
            {
                Console.WriteLine("\nProducto no encontrado.");
            }
        }
        else
        {
            Console.WriteLine("\nEl ID no es válido. Ingrese un número entero.");
        }
    }
}