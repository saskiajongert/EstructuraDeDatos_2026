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

        public int TotalRegistros()
        {
            return contadorRegistros;
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