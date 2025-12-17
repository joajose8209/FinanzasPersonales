# Changelog 📜
Todas las modificaciones notables a este proyecto serán documentadas en este archivo.

El formato se basa en [Keep a Changelog](https://keepachangelog.com/es-ES/1.0.0/).

## [v0.3.0] - Conexión a Base de Datos - 2025-12-17
### Agregado
* **Persistencia Real:** Se conectó la API a una base de datos SQL Server (LocalDB). Ahora los datos sobreviven al reinicio de la aplicación.
* **ORM:** Se implementó **Entity Framework Core** como traductor entre C# y SQL.
* **Infraestructura:** Se creó la tabla `Deudas` y se configuró la inyección de dependencias en `Program.cs` y `appsettings.json`.

### Cambiado
* **Controlador:** Se eliminó la lista `static` (memoria RAM) de `DeudasController` y se reemplazó por llamadas asíncronas (`async/await`) a la base de datos.



## [v0.2.0] - Persistencia en Memoria - 2025-12-17
### Agregado
* **Endpoint POST:** Se habilitó la creación de nuevas deudas mediante `POST /api/Deudas`.
* **Persistencia Estática:** Se implementó una lista `static` para mantener los datos en memoria mientras la aplicación corre, permitiendo que los datos sobrevivan entre distintas peticiones.

### Cambiado
* **Endpoint GET:** Se modificó para leer los datos de la lista compartida (`_repositorioDeudas`) en lugar de generar instancias nuevas en cada llamada.


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