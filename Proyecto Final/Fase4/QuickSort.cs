class QS
{
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
}