class Program
{
    class Alumno
    {
        public string Nombre { get; set; }
    }

    static void Main()
    {
        Alumno alumno1 = new Alumno { Nombre = "Dany" };
        Alumno alumno2 = alumno1;
        alumno2.Nombre = "3Treum";
        Console.WriteLine(alumno1.Nombre);
        // Imprime: 3Treum 4 ¡No "Dany"!
    }
}