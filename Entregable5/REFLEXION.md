**Preguntas De Reflexión**

---

1.	*Si insertas los nodos en este orden: 10, 5, 15, 3, 7, 12, 20, 4... ¿cómo quedaría el árbol visualmente? Dibuja la jerarquía (puedes usar texto ASCII o una imagen). ¿Cuál es la altura del árbol resultante?*
    a.	La altura del árbol resultante sería de 4 nodos (3 aristas) en el trayecto más largo (del 10 al 4).
          
          10
         /  \
        5    15
       / \   / \
      3   7 12 20
       \
        4

---

2.	*Ahora inserta los nodos en este orden: 1, 2, 3, 4, 5, 6, 7. ¿Cómo queda el árbol? ¿Por qué la búsqueda ya no es O(log n) en este caso? ¿Qué nombre recibe este problema y qué solución existe?*
    a.	Debido a que cada nuevo número es mayor al anterior, este siempre será añadido como hijo derecho. A este problema, donde cada nodo tiene solo un hijo, se le conoce como "árbol degenerado", o "árbol patológico". Este tipo de árboles binarios se comporta como una lista enlazada (Wikipedia, 2026), por lo cual la búsqueda pasa a ser O(n). El "arreglar" un árbol degenerado se logra mediante algoritmos de balanceo, con rotaciones que cambian los enlaces entre los nodos (Montero, 2017).

    1
     \
      2
       \
        3
         \
          4
           \
            5
             \
              6
               \
                7

---

3.	*Explica con tus propias palabras la diferencia entre el caso base y elcaso recursivo en la función BuscarNodo. ¿Qué ocurriría si eliminases el caso base? ¿Qué error se produciría en tiempo de ejecución?*
    a.	En la función BuscarNodo, el caso base es aquel que detiene por completo la recursión. El caso recursivo es aquel que llama a la función con un problema más pequeño.
        - Casos Base:
            - *if (raiz == null)...* --> El programa llega a un nodo que no existe (no encuentra el valor), y devuelve un valor nulo.
            - *if (idTarget == raiz.ID)...* --> El programa encuentra el nodo que estaba buscando, por lo cual deja de buscar.
        - Caso Recursivo: 
            - *if (idTarget < raiz.ID)...* --> El programa descarta el lado derecho o izquierdo del árbol si el valor a buscar es menor o mayor a la raíz. Esto para que no busque en todo el árbol.
        Si se eliminan los casos base, la función no tiene una condición para detenerse, por lo cual continuaría por siempre. Se produciría una *StackOverflowException*. En este caso específico, también se puede producir una *NullReferenceException* si la raíz tiene valor nulo.

---

4.	*Nombra dos situaciones del mundo real (fuera de las mencionadas en clase) donde un árbol binario de búsqueda sería más eficiente que una lista ordenada. Justifica por qué la complejidad O(log n) marca la diferencia en esos casos concretos.*
    a. Clasificación: Por ejemplo, en un videojuego, los jugadores se clasifican por puntuación. Para insertar o eliminar una puntuación, un árbol es mucho más eficiente en este aspecto ya que permite encontrar posiciones más rápidamente sin tener que desplazar toda la lista.
    b. Agendas: Donde los elementos se ordenan por fecha y hora. Un árbol binario puede localizar rápidamente dónde encaja una nueva cita sin tener que pasar por cada cita que ya está anotada.

---

**Referencias**
    - Montero, L. (2017). *Árboles (trees)*. Recuperado de https://medium.com/@lupomontero/%C3%A1rboles-trees-51783ba4ebe5
    - Colaboradores de Wikipedia (2026). *Árbol binario de búsqueda*. Recuperado de https://es.wikipedia.org/w/index.php?title=%C3%81rbol_binario_de_b%C3%BAsqueda&oldid=170431614



    