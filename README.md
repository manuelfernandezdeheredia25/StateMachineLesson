# Maquinas de estados en C# y Unity

## Intro

Maquina de estados: patron de diseño de comportamiento
patrones de diseño: soluciones estandarizadas a ciertos problemas recurrentes durante el desarrollo de un programa.

## ¿Que problema soluciona la maquina de estados?

Maquina de estados finita, de modelo matemático a código, 

¿Cuál es la mejor manera de implementarla?

- Switch/if statements
    * Intuitivo
    * No-escalable
    * Alto mantenimiento
    * Baja legibilidad del código

## Solución

- Separar cada estado (state) único en una clase diferente, que implementen la misma interfaz
- La maquina que cambia de estados(Context) contiene por composición su estado actual
-Toda la logíca de la clase Context se delega a su estado actual.

https://www.canva.com/design/DAG-3_C_XNA/wfzO7OiDkqh2Veuc1AQCNA/edit?utm_content=DAG-3_C_XNA&utm_campaign=designshare&utm_medium=link2&utm_source=sharebutton
