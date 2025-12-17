# Changelog 📜
Todas las modificaciones notables a este proyecto serán documentadas en este archivo.

El formato se basa en [Keep a Changelog](https://keepachangelog.com/es-ES/1.0.0/).

## [v0.1.1] - Corrección de Infraestructura - 2025-12-16
### Corregido
* Se solucionó error 404 al intentar acceder a la documentación de la API.
* **Dependencia:** Se instaló el paquete NuGet `Swashbuckle.AspNetCore` para reemplazar la configuración nativa de .NET 9 que no incluía interfaz gráfica.
* **Configuración:** Se actualizó `Program.cs` para habilitar `AddSwaggerGen` y `UseSwaggerUI`.

## [v0.1.0] - Inicio del Proyecto - 2025-12-15
### Agregado
* Estructura inicial de la solución en .NET.
* Modelo `Deuda` con lógica de vencimientos.
* Controlador básico `DeudasController` (Hardcoded).