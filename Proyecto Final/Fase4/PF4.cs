/*
// Opción A: desestructuración directa
 var (registro, comparaciones) = BuscarRegistroIndexado(indice, idBuscado);
if (registro != null)
{
    Console.WriteLine($"✓ Registro encontrado:");
    Console.WriteLine($" ID : {registro.Id}");
    Console.WriteLine($" Nombre : {registro.Nombre}");
    Console.WriteLine($" Dato : {registro.Dato}");
    Console.WriteLine($" Comparaciones: {comparaciones}");
}
else
{
    Console.WriteLine($" ID {idBuscado} no encontrado.");
    Console.WriteLine($" Comparaciones realizadas: {comparaciones}");
}

////

// Opción B: acceso por nombre de campo de tupla
var resultado = BuscarRegistroIndexado(indice, idBuscado);

// Registrar métricas independientemente del resultado
RegistrarMetrica(operacion: "BusquedaBinaria", comparaciones: resultado.comparaciones, exito: resultado.registro != null);

// Mostrar resultado al usuario
MostrarResultado(resultado.registro);

////

// Opción C: pattern matching (C# 8+)
if (BuscarRegistroIndexado(indice, id) is ({ } reg, var comps))
{
    // reg es no-null garantizado aquí
    ProcesarRegistro(reg, comps);
} 
*/

////


class BusquedaBinaria
{
    /// Busca un registro en un arreglo ordenado usando búsqueda binaria.
    /// Complejidad temporal: O(log n) | Complejidad espacial: O(1)

    /// <param name="arrOrdenado">Arreglo de RegistroDatos ordenado por Id ascendente.</param>
    /// <param name="idBuscado">El Id entero del registro a localizar.</param>
    /// <returns>Tupla con el registro encontrado (o null) y el número de comparaciones.</returns>
    public static (RegistroDatos? registro, int comparaciones)
    BuscarRegistroIndexado(RegistroDatos[] arrOrdenado, int idBuscado)
    {
        // GUARDIA INICIAL: si el arreglo es null o vacío, retornamos inmediatamente.
        // Evita NullReferenceException e IndexOutOfRangeException sin costo alguno.
        if (arrOrdenado == null || arrOrdenado.Length == 0)
            return (null, 0);

        // Inicializamos los punteros de los extremos del espacio de búsqueda.
        // 'izq' apunta al primer índice válido; 'der' al último.
        int izq = 0;
        int der = arrOrdenado.Length - 1;

        // Contador de comparaciones: se incrementa una vez por iteración del bucle,
        // ya que cada iteración realiza exactamente una comparación de Ids.
        int comparaciones = 0;

        // INVARIANTE DEL BUCLE: si el elemento existe, se encuentra en el
        // subarreglo [izq..der]. El bucle continúa mientras haya al menos
        // un elemento en ese subarreglo.
        while (izq <= der)
        {
            // Calculamos el punto medio. Se usa (izq + der) / 2 que es seguro
            // en C# para int porque el desbordamiento aritmético en int
            // se puede evitar con: int medio = izq + (der - izq) / 2;
            // Usamos la forma alternativa para mayor claridad conceptual.
            int medio = izq + (der - izq) / 2;

            // Registramos la comparación ANTES de realizarla,
            // ya que el acceso al arreglo es la operación costosa.
            comparaciones++;

            // CASO 1 — ÉXITO: el elemento del medio es exactamente el buscado.
            // Retornamos inmediatamente con la tupla (registro, comparaciones).
            if (arrOrdenado[medio].Id == idBuscado)
            return (arrOrdenado[medio], comparaciones);

            // CASO 2 — BUSCAR EN LA MITAD DERECHA: el objetivo es mayor
            // que el elemento del medio. Todo el subarreglo [izq..medio] queda
            // descartado porque está ordenado y todos sus valores son menores.
            else if (arrOrdenado[medio].Id < idBuscado)
            izq = medio + 1;

            // CASO 3 — BUSCAR EN LA MITAD IZQUIERDA: el objetivo es menor
            // que el elemento del medio. Todo el subarreglo [medio..der] queda
            // descartado porque todos sus valores son mayores.
            else
            der = medio - 1;

            // PROGRESO GARANTIZADO: en cada iteración, el espacio de búsqueda
            // se reduce al menos a la mitad. Nunca puede ocurrir un bucle infinito.
        }

        // CASO FINAL — ELEMENTO NO ENCONTRADO: el bucle terminó con izq > der,
        // lo que significa que el espacio de búsqueda quedó vacío sin encontrar
        // el ID. Retornamos null pero siempre incluimos el contador de comparaciones
        // para que el llamador pueda registrar el costo de la búsqueda fallida.
        return (null, comparaciones);
    }
}

