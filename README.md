# Finanzas Personales API 💰

API RESTful desarrollada con .NET Core para la gestión de deudas y finanzas personales.

Este proyecto documenta mi transición profesional de la gestión comercial al desarrollo de software, aplicando buenas prácticas de arquitectura, inyección de dependencias y persistencia de datos real.

## 🚀 Tecnologías
* **Lenguaje:** C# (.NET 8)
* **Framework:** ASP.NET Core Web API
* **ORM:** Entity Framework Core
* **Base de Datos:** SQL Server (LocalDB)
* **Herramientas:** Swagger/OpenAPI, Visual Studio 2022

## ✅ Funcionalidades (Estado del Proyecto)

El sistema cuenta actualmente con un **CRUD completo** para la entidad de Deudas:

- [x] **Create:** Registro de nuevas deudas con validación de tipos de datos.
- [x] **Read:** Listado general y búsqueda específica por ID.
- [x] **Update:** Actualización de montos y estados (con validación de concurrencia).
- [x] **Delete:** Eliminación física de registros en base de datos.
- [x] **Lógica de Negocio:** Cálculo automático de vencimientos.

## 🗂 Estructura de Datos (Modelo: Deuda)

La entidad principal gestiona la siguiente información financiera:
* `Monto` y `CostoFinancieroTotal` (Decimales para precisión monetaria).
* `FechaVencimiento` (Mapeo preciso con SQL Server).
* `Descripcion` (Detalle de la obligación).

## 📅 Historial de Versiones Destacado

### [v0.2.0] - Persistencia y CRUD Completo - 2025-12-22
**Hitos alcanzados:**
* Conexión exitosa a **SQL Server** mediante **Entity Framework Core**.
* Implementación de **DeudasController** con todos los verbos HTTP (GET, POST, PUT, DELETE).
* Manejo de excepciones y códigos de estado HTTP correctos (201 Created, 204 No Content, 404 NotFound).
* Solución de conflictos de tipos de datos (DateTime vs DateTime2).

### [v0.1.0] - Estructura Inicial - 2025-12-15
* Configuración inicial del proyecto y modelo de datos en memoria.

---
*Autor: Jose Armando Lopez*