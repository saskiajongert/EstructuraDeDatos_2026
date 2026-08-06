class Menu
{
    static TablaDinamica dataCore = new TablaDinamica();   
    static void Main(String[] args)
    {
        int opcion = 0;

        do
        {
            MostrarMenu();
            Console.Write("Seleccione una opción: ");
            string input = Console.ReadLine() ?? "";

            try
            {
                opcion = int.Parse(input);
                switch (opcion)
                {
                    case 1: MenuGestionRegistros(); break;
                    case 2: MenuModuloBusqueda(); break;
                    case 3: MenuModuloOrdenamiento(); break;
                    case 4: MenuEstadisticas(); break;
                    case 5: 
                        Console.WriteLine("---------------------------------------------------------");
                        Console.WriteLine("Saliendo..."); 
                        Console.WriteLine("---------------------------------------------------------");
                        break;
                    default: Console.WriteLine("Opción inválida."); break;
                }
            }

            catch (FormatException)
            {
                Console.WriteLine("Error: Ingresa un número válido.");
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
            }
        } while (opcion != 5);
    }

// =====================================================================================================================
// MENÚ PRINCIPAL ======================================================================================================
// =====================================================================================================================

    static void MostrarMenu()
    {
        Console.WriteLine("\n=========================================================");
        Console.WriteLine("============= DATACORE v4.0 — MENÚ MAESTRO =============");
        Console.WriteLine("=========================================================");
        Console.WriteLine("[1] Gestión de Registros");
        Console.WriteLine("[2] Módulo de Búsqueda");
        Console.WriteLine("[3] Módulo de Ordenamiento");
        Console.WriteLine("[4] Estadísticas del Sistema");
        Console.WriteLine("[5] Salir");
        Console.WriteLine("=========================================================");
    }

// =====================================================================================================================
// MENÚ 1: GESTIÓN DE REGISTROS ========================================================================================
// =====================================================================================================================

    static void MenuGestionRegistros()
    {
        int opcion = 0;

        do
        {
            Console.WriteLine("      [1] Insertar nuevo registro");
            Console.WriteLine("      [2] Eliminar registro por clave");
            Console.WriteLine("      [3] Mostrar todos los registros");
            Console.WriteLine("      [4] Regresar");
            Console.WriteLine("=========================================================");

            string input = Console.ReadLine() ?? "";

            try
            {
                opcion = int.Parse(input);
                switch (opcion)
                {
                    case 1: EjecutarInsercion(); break;
                    case 2: EjecutarEliminacion(); break;
                    case 3: EjecutarMostrar(); break;
                    case 4: 
                        Console.WriteLine("---------------------------------------------------------");
                        Console.WriteLine("Regresando..."); 
                        Console.WriteLine("---------------------------------------------------------");
                        break;
                    default: Console.WriteLine("Opción inválida."); break;
                }
            }

            catch (FormatException)
            {
                Console.WriteLine("Error: Ingresa un número válido.");
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
            }
        } while (opcion != 4);        
    }

// =====================================================================================================================
// MENÚ 2: MÓDULO DE BÚSQUEDA ==========================================================================================
// =====================================================================================================================

    static void MenuModuloBusqueda()
    {
        int opcion = 0;

        do
        {
            Console.WriteLine("      [1] Búsqueda lineal (O(n))");
            Console.WriteLine("      [2] Búsqueda binaria indexada (O(log n))");
            Console.WriteLine("      [3] Regresar");
            Console.WriteLine("=========================================================");

            string input = Console.ReadLine() ?? "";

            try
            {
                opcion = int.Parse(input);
                switch (opcion)
                {
                    case 1: EjecutarLineal(); break;
                    case 2: EjecutarBinaria(); break;
                    case 3: 
                        Console.WriteLine("---------------------------------------------------------");
                        Console.WriteLine("Regresando...");
                        Console.WriteLine("---------------------------------------------------------"); 
                        break;
                    default: Console.WriteLine("Opción inválida."); break;
                }
            }

            catch (FormatException)
            {
                Console.WriteLine("Error: Ingresa un número válido.");
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
            }
        } while (opcion != 3);
    }

// =====================================================================================================================
// MENÚ 3: MÓDULO DE ORDENAMIENTO ======================================================================================
// =====================================================================================================================

static void MenuModuloOrdenamiento()
    {
        int opcion = 0;

        do
        {
            Console.WriteLine("      [1] Ordenar por clave (QuickSort)");
            Console.WriteLine("      [2] Regresar");
            Console.WriteLine("=========================================================");

            string input = Console.ReadLine() ?? "";

            try
            {
                opcion = int.Parse(input);
                switch (opcion)
                {
                    case 1: EjecutarQuickSort(); break;
                    case 2: 
                        Console.WriteLine("---------------------------------------------------------");
                        Console.WriteLine("Regresando...");
                        Console.WriteLine("---------------------------------------------------------"); 
                        break;
                    default: Console.WriteLine("Opción inválida."); break;
                }
            }

            catch (FormatException)
            {
                Console.WriteLine("Error: Ingresa un número válido.");
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
            }
        } while (opcion != 2);
    }

// =====================================================================================================================
// MENÚ 4: ESTADÍSTICAS DEL SISTEMA ====================================================================================
// =====================================================================================================================

    static void MenuEstadisticas()
    {
        int opcion = 0;

        do
        {
            Console.WriteLine("      [1] Total de registros en memoria");
            Console.WriteLine("      [2] Uso estimado de memoria (bytes)");
            Console.WriteLine("      [3] Regresar");
            Console.WriteLine("=========================================================");

            string input = Console.ReadLine() ?? "";

            try
            {
                opcion = int.Parse(input);
                switch (opcion)
                {
                    case 1: EjecutarTotalRegistros(); break;
                    case 2: EjecutarUsoMemoria(); break;
                    case 3: 
                        Console.WriteLine("---------------------------------------------------------");
                        Console.WriteLine("Regresando...");
                        Console.WriteLine("---------------------------------------------------------"); 
                        break;
                    default: Console.WriteLine("Opción inválida."); break;
                }
            }

            catch (FormatException)
            {
                Console.WriteLine("Error: Ingresa un número válido.");
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
            }
        } while (opcion != 3);
    }

// =====================================================================================================================
// GESTIÓN DE REGISTROS ================================================================================================
// =====================================================================================================================

    static void EjecutarInsercion()
    {
        Console.WriteLine("---------------------------------------------------------");
        Console.Write("ID: ");
        int id = int.Parse(Console.ReadLine() ?? "0");
        Console.Write("Hash: ");
        string hash = Console.ReadLine() ?? "";
        Console.Write("Peso: ");
        double peso = double.Parse(Console.ReadLine() ?? "0");

        RegistroDatos nuevo = new RegistroDatos(id, hash, peso);
        dataCore.InsertarFinal(nuevo);
        Console.WriteLine("Registro insertado.");
        Console.WriteLine("---------------------------------------------------------");
    }

    static void EjecutarEliminacion()
    {
        Console.WriteLine("---------------------------------------------------------");
        RegistroDatos[] arreglo = dataCore.ObtenerComoArreglo(); // solo para verificar si está vacío
        if (arreglo.Length == 0)
        {
            Console.WriteLine("No hay registros almacenados.");
            Console.WriteLine("=========================================================\n");
            Console.WriteLine("---------------------------------------------------------");
            return;
        }
        Console.Write("ID a eliminar: ");
        int id = int.Parse(Console.ReadLine() ?? "0");
        dataCore.EliminarPorId(id);
        Console.WriteLine("Registro eliminado.");
        Console.WriteLine("---------------------------------------------------------");
    }

    static void EjecutarMostrar()
    {
        RegistroDatos[] arreglo = dataCore.ObtenerComoArreglo();

        Console.WriteLine("---------------------------------------------------------");
        Console.WriteLine("\n======================= REGISTROS =======================");

        if (arreglo.Length == 0)
        {
            Console.WriteLine("No hay registros almacenados.");
            Console.WriteLine("=========================================================\n");
            Console.WriteLine("---------------------------------------------------------");
            return;
        }

        else
        {
            foreach (var r in arreglo)
                Console.WriteLine($"Id: {r.Id} | Hash: {r.HashValidacion} | Peso: {r.PesoBytes} bytes");
            Console.WriteLine("=========================================================\n");
            Console.WriteLine("---------------------------------------------------------");
        }

    }

// =====================================================================================================================
// MÓDULO DE BÚSQUEDA ==================================================================================================
// =====================================================================================================================

    static void EjecutarLineal()
    {
        RegistroDatos[] arreglo = dataCore.ObtenerComoArreglo();

        Console.WriteLine("---------------------------------------------------------");

        if (arreglo.Length == 0)
        {
            Console.WriteLine("No hay registros almacenados.");
            Console.WriteLine("---------------------------------------------------------");
            return;
        }

        Console.Write("ID a buscar: ");
        int id = int.Parse(Console.ReadLine() ?? "0");

        static int BusquedaLineal(RegistroDatos[] arreglo, int objetivo) 
        {
            for (int i = 0; i < arreglo.Length; i++) 
            {
                if (arreglo[i].Id == objetivo) return i;
            }
            return -1;
        }

        int idxLineal = BusquedaLineal(arreglo, id);

        if(idxLineal != -1)
        {
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine($"✓ Registro encontrado");
            Console.WriteLine($"Posición: {idxLineal + 1}");
            Console.WriteLine("---------------------------------------------------------");
        }
        else
        {
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine($"ID {id} no encontrado.");
            Console.WriteLine("---------------------------------------------------------");
        }
    }

    static void EjecutarBinaria()
    {
        RegistroDatos[] arreglo = dataCore.ObtenerComoArreglo();

        Console.WriteLine("---------------------------------------------------------");

        if (arreglo.Length == 0)
        {
            Console.WriteLine("No hay registros almacenados.");
            Console.WriteLine("---------------------------------------------------------");
            return;
        }

        QS.QuickSort(arreglo, 0, arreglo.Length - 1);
        Console.Write("ID a buscar: ");
        int idBuscado = int.Parse(Console.ReadLine() ?? "0");

        var (registro, comparaciones) = BusquedaBinaria.BuscarRegistroIndexado(arreglo, idBuscado);
        if (registro != null)
        {
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine($"✓ Registro encontrado");
            Console.WriteLine($" ID : {registro.Value.Id}");
            Console.WriteLine($" Hash : {registro.Value.HashValidacion}");
            Console.WriteLine($" Peso : {registro.Value.PesoBytes}");
            Console.WriteLine($" Comparaciones: {comparaciones}");
            Console.WriteLine("---------------------------------------------------------");
        }
        else
        {
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine($" ID {idBuscado} no encontrado.");
            Console.WriteLine($" Comparaciones realizadas: {comparaciones}");
            Console.WriteLine("---------------------------------------------------------");
        }
    }

// =====================================================================================================================
// MÓDULO DE ORDENAMIENTO ==============================================================================================
// =====================================================================================================================

    static void EjecutarQuickSort()
    {
        RegistroDatos[] arreglo = dataCore.ObtenerComoArreglo();

        Console.WriteLine("---------------------------------------------------------");

        if (arreglo.Length == 0)
        {
            Console.WriteLine("No hay registros almacenados.");
            Console.WriteLine("---------------------------------------------------------");
            return;
        }

        Console.WriteLine("Ordenando con QuickSort...");
        QS.QuickSort(arreglo, 0, arreglo.Length - 1);

        Console.WriteLine("=========================================================");
        foreach (var r in arreglo)
            Console.WriteLine($"Id: {r.Id} | Hash: {r.HashValidacion} | Peso: {r.PesoBytes} bytes");
        Console.WriteLine("=========================================================");
        Console.WriteLine("Registros ordenados correctamente.");
        Console.WriteLine("---------------------------------------------------------");

    }

// =====================================================================================================================
// ESTADÍSTICAS DEL SISTEMA ============================================================================================
// =====================================================================================================================

    static void EjecutarTotalRegistros()
    {
        Console.WriteLine("---------------------------------------------------------");
        Console.WriteLine($"Total de registros en memoria: {dataCore.TotalRegistros()}");
        Console.WriteLine("---------------------------------------------------------");
    }

    static void EjecutarUsoMemoria()
    {
        double totalBytes = 0;

        foreach (var r in dataCore.ObtenerComoArreglo())
        {
            totalBytes += r.PesoBytes;
        }
        
        Console.WriteLine("---------------------------------------------------------");
        Console.WriteLine($"Uso estimado de memoria: {totalBytes} bytes"); // no hago la operación de la referencia porque lo siento más correcto así
        Console.WriteLine("---------------------------------------------------------");
    }

}