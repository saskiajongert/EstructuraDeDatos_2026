class ProgramaGPS
{
    readonly struct CoordenadaGPS
    {
        public double Latitud { get; }
        public double Longitud { get; }

        public CoordenadaGPS(double lat, double lon)
        {
            // Validación en Módulo C
            if (lat < -90 || lat > 90)
            {
                throw new 
                ArgumentOutOfRangeException(
                    nameof(lat), "Latitud fuera de rango [-90, 90]");
            }

            if (lon < -180 || lon > 180)
            {
                throw new 
                ArgumentOutOfRangeException(
                    nameof(lon), "Longitud fuera de rango [-180, 180]");
            }

            Latitud = lat;
            Longitud = lon;
        }

        public void ImprimirUbicacion()
        {
            Console.WriteLine($"Latitud: {Latitud}, Longitud: {Longitud}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {   
            // Ciudad de México
            CoordenadaGPS c1 = new CoordenadaGPS(19.4326, -99.1332);

            // Copia por valor en el Stack
            CoordenadaGPS c2 = c1;

            // Reasignamos c2 -> Berlín
            c2 = new CoordenadaGPS(52.5200, 13.4050);

            // Imprimimos ambas
            Console.WriteLine("--- c1 ---");
            c1.ImprimirUbicacion();
            Console.WriteLine("--- c2 ---");
            c2.ImprimirUbicacion();

            // Captura
            try
            {
                Console.WriteLine("---------");
                Console.Write("Latitud: ");
                double lat = double.Parse(Console.ReadLine());
                Console.Write("Longitud: ");
                double lon = double.Parse(Console.ReadLine());

                var coord = new CoordenadaGPS(lat, lon);
                coord.ImprimirUbicacion();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }
            catch (FormatException)
            {
                Console.WriteLine("\nError: Introduzca un número válido.");
            }
        }
    }
}