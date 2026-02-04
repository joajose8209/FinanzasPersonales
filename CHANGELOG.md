# Changelog 📜
Todas las modificaciones notables a este proyecto serán documentadas en este archivo.

El formato se basa en [Keep a Changelog](https://keepachangelog.com/es-ES/1.0.0/).

### [2026-02-03]
- **Nueva Funcionalidad:** Ahora el sistema puede distinguir entre diferentes tipos de deuda (Fija, Bimestral, Variable, etc.) gracias a la implementación de `TipoDeuda`.
- **Mejora Lógica:** Se agregó la capacidad de detectar automáticamente si un gasto es recurrente (`EsGastoRecurrente`), lo que servirá para calcular presupuestos mensuales con mayor precisión.

## [2026-01-18]
[Seguridad] Implementación de validaciones para asegurar la  Integridad de Datos (evitando montos negativos y fechas futuras).
[Rendimiento] Optimización del endpoint mediante el patrón Fail-Fast para reducir llamadas innecesarias a la base de datos.


## [2026-01-17] - Gestión de Pagos
### Añadido 🚀
- Endpoint `POST /api/Pagos`: Permite registrar nuevos pagos validando la existencia de la deuda.
- Endpoint `GET /api/Pagos/{deudaId}`: Permite consultar el historial de pagos filtrado por deuda.
- Lógica de negocio para descontar el monto pagado del saldo de la deuda.


## [2026-01-16] 

### Added
- Creación de la tabla `Pagos` en la base de datos con la estructura definida (Id, DeudaId, Monto, MedioPago, FechaPago).

### Fixed
- Solucionado conflicto de migración: la tabla `Pagos` existía en el *Snapshot* de EF pero no en la base de datos real.

## [2026-01-07] - Lógica de Negocio en Pagos
### Añadido
- **Controlador de Pagos:** Creación de `PagosController` con inyección de dependencias.
- **Lógica de Transacción:** Implementación del método `RegistrarPago` para descontar montos.
- **Reglas de Negocio:** Validación para rechazar pagos que superen el monto de la deuda (Integridad de datos).

## [2026-01-04] - Seguridad e Integridad de Datos
### Añadido
- **Manifesto del Desarrollador:** Creación de `MANIFESTO.md` con los 6 principios rectores del proyecto.
- **DTOs de Seguridad:** Implementación de `ActualizarDeudaDto`, `DeudaDto` y `RegistrarPagoDto` para proteger la entidad de dominio.
- **Validaciones (Data Annotations):**
  - Reglas de negocio para `CrearDeudaDto` y `ActualizarDeudaDto` (Required, StringLength, Range).
  - Pruebas de seguridad realizadas en Swagger (respuestas 400 Bad Request confirmadas).
- **Refactorización:** Limpieza del `DeudasController` para usar los nuevos DTOs.

### Pendiente
- Implementación de la lógica en `PagosController` (Estructura definida, código pendiente).

## [2025-12-22]
### Añadido
- Método `PutDeuda` en `DeudasController` para permitir la actualización de registros existentes.
- Método auxiliar `DeudaExists` para validaciones de concurrencia.

### Corregido
- Solucionado error de mapeo en JSON: Los campos `nombre` y `fecha` ahora se reciben correctamente como `descripcion` y `fechaVencimiento` para coincidir con la base de datos SQL.
- Solucionado conflicto de tipos de datos `datetime` vs `datetime2` asegurando el envío de fechas válidas en el JSON.


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