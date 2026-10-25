# Gem Collector

Juego 3D simple hecho en Unity 6 donde el jugador se mueve por una arena y recolecta gemas.

## Controles
- Flechas del teclado (o WASD): mover al jugador.

## Cómo funciona
- **Movimiento (C#):** `PlayerMovement.cs` lee el input en `Update`, aplica la física en `FixedUpdate` y suaviza la velocidad con `Vector3.SmoothDamp`.
- **Recolección (Visual Scripting):** cada gema tiene un Script Machine con este flujo: `On Trigger Enter → Compare Tag (Player) → Set Scene Variable (Score +1) → Debug Log → Destroy`.
- **Puntaje en pantalla (C#):** `ScoreUI.cs` lee la variable `Score` del Visual Scripting y la muestra en un Text (TMP).

## Lógica de Visual Scripting
![Grafo de la gema](docs/visual-scripting-gem.png)

## Reflexión: C# vs Visual Scripting

| Criterio | C# tradicional | Visual Scripting |
|---|---|---|
| Facilidad de implementación | Requiere conocer la sintaxis, pero luego es rápido | Accesible para principiantes, pero buscar nodos puede ser lento |
| Legibilidad | Compacto y claro si está ordenado | Muy visual en lógica simple; con muchos nodos se vuelve confuso |
| Escalabilidad | Excelente (clases, herencia, reutilización) | Difícil de mantener en proyectos grandes |

## Desafíos y soluciones
- El nodo de texto de Visual Scripting no era compatible con TextMeshPro; lo resolví con un script C# pequeño que lee la variable `Score`.
- El Debug Log no se ejecutaba porque no estaba conectado al flujo; lo coloqué entre Set Variable y Destroy.
