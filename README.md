# Maquinas de estados en C# y Unity

https://www.canva.com/design/DAG-3_C_XNA/wfzO7OiDkqh2Veuc1AQCNA/edit?utm_content=DAG-3_C_XNA&utm_campaign=designshare&utm_medium=link2&utm_source=sharebutton

## Intro en patrones de diseño
patrones de diseño: soluciones estandarizadas a ciertos problemas recurrentes durante el desarrollo de un programa.

(breve intro a patrones de diseño)

Quiza explicar brevemente singleton o alguno de los faciles

## ¿Que problema soluciona la maquina de estados?

Maquina de estados finita, de modelo matemático a código 

Implementación mala:

- Switch/if statements
    * Intuitivo
    * No-escalable
    * Alto mantenimiento
    * Baja legibilidad del código

## Solución
¡OJO! se requiere saber Herencia, Interfaces y Poliformismo!

- Separar cada estado (state) único en una clase diferente, que implementen la misma interfaz
- La maquina que cambia de estados(Context) contiene por composición su estado actual
-Toda la lógica de la clase Context se delega a su estado actual.



## Aplicaciones

Siempre que tengas una objeto que puede comportarse de manera diferente, una maquina de estados va a ser aplicable. Cuantos mas comportamientos diferentes existan, mas te beneficiará implementar este patrón correctamente.

## Ejemplo de implementación

(ejemplos de codigo del juego )
